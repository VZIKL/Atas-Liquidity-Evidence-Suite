namespace ATAS.CustomIndicators;

/// <summary>
/// Evidence state machine for iceberg candidates.
/// A synthetic candidate requires an observed resting level, an aggressive trade,
/// a subsequent depth reduction, and a same-side replenishment within a short window.
///
/// States:
///   Idle → Suspected (1st replenish) → Confirmed (3+ replenishes) → Exhausted (stopped replenishing)
/// </summary>
public class IcebergStateMachine
{
    public enum State { Idle, Suspected, Confirmed, Exhausted }

    public class PriceLevelTracker
    {
        public decimal Price;
        public State CurrentState = State.Idle;
        public int ReplenishCount;
        public decimal ReplenishSize;       // the tip size
        public decimal CumulativeFilled;     // total volume filled at this level
        public DateTime FirstSeen;
        public DateTime LastReplenish;
        public DateTime LastActivity;
        public DateTime? ExhaustedAt;
        public long? ExchangeOrderId;        // for native iceberg (MBO-based)
        public bool IsNative;                // true = exchange-managed, false = synthetic (ISV)
        public bool IsBid;

        // This is an evidence score, not a calibrated probability.
        public decimal EvidenceScore => CurrentState switch
        {
            State.Confirmed => Math.Min(100m, 60m + Math.Max(0, ReplenishCount - 3) * 10m + (IsNative ? 20m : 0m)),
            State.Suspected => IsNative ? 40m : 25m,
            _ => 0m
        };

        /// <summary>
        /// Lower-bound estimate of hidden quantity already consumed. Remaining hidden
        /// quantity is not observable from public depth data.
        /// </summary>
        public decimal EstimatedConsumedHidden => Math.Max(0m, CumulativeFilled - ReplenishSize);
    }

    private sealed class DepthObservation
    {
        public decimal Volume;
        public DateTime Time;
    }

    private sealed class PendingSyntheticFill
    {
        public decimal FilledVolume;
        public decimal ObservedDepthBeforeTrade;
        public DateTime Time;
        public bool SawDepthReduction;
    }

    private readonly Dictionary<(decimal Price, bool IsBid), PriceLevelTracker> _levels = new();
    private readonly Dictionary<long, PriceLevelTracker> _nativeLevels = new();
    private readonly Dictionary<(decimal Price, bool IsBid), DepthObservation> _depthByLevel = new();
    private readonly Dictionary<(decimal Price, bool IsBid), PendingSyntheticFill> _pendingSyntheticFills = new();
    private readonly decimal _tickSize;
    private readonly int _confirmThreshold;  // replenishments to confirm
    private readonly TimeSpan _exhaustTimeout;
    private readonly decimal _sizeTolerance;  // % tolerance for replenish size matching

    public IcebergStateMachine(
        decimal tickSize = 0.01m,
        int confirmThreshold = 3,
        TimeSpan? exhaustTimeout = null,
        decimal sizeTolerance = 0.15m)
    {
        _tickSize = tickSize;
        _confirmThreshold = confirmThreshold;
        _exhaustTimeout = exhaustTimeout ?? TimeSpan.FromSeconds(30);
        _sizeTolerance = sizeTolerance;
    }

    public IReadOnlyCollection<PriceLevelTracker> ActiveLevels => _levels.Values
        .Concat(_nativeLevels.Values)
        .Where(l => l.CurrentState is State.Suspected or State.Confirmed)
        .ToList();

    /// <summary>
    /// Call when a trade consumes a resting bid or ask at this price.
    /// </summary>
    public void OnTrade(decimal price, decimal volume, DateTime time, bool? restingIsBid)
    {
        if (!restingIsBid.HasValue || volume <= 0)
            return;

        var p = RoundPrice(price);
        var key = (p, restingIsBid.Value);
        if (_depthByLevel.TryGetValue(key, out var depth) && depth.Volume > 0)
        {
            if (_pendingSyntheticFills.TryGetValue(key, out var pending) &&
                time >= pending.Time && time - pending.Time <= _exhaustTimeout)
            {
                pending.FilledVolume += volume;
                pending.Time = time;
            }
            else
            {
                _pendingSyntheticFills[key] = new PendingSyntheticFill
                {
                    FilledVolume = volume,
                    ObservedDepthBeforeTrade = depth.Volume,
                    Time = time
                };
            }
        }

        if (_levels.TryGetValue(key, out var tracker))
        {
            tracker.CumulativeFilled += volume;
            tracker.LastActivity = time;
        }
    }

    /// <summary>
    /// Call when market depth changes. Check if new depth at a price is a replenishment.
    /// </summary>
    public void OnDepthChanged(decimal price, decimal volume, DateTime time, bool isBid)
    {
        var p = RoundPrice(price);

        var key = (p, isBid);
        _depthByLevel.TryGetValue(key, out var observation);
        var previousVolume = observation?.Volume ?? 0m;
        _depthByLevel[key] = new DepthObservation { Volume = Math.Max(0m, volume), Time = time };

        if (!_pendingSyntheticFills.TryGetValue(key, out var pending))
            return;

        if (time < pending.Time || time - pending.Time > _exhaustTimeout)
        {
            _pendingSyntheticFills.Remove(key);
            return;
        }

        if (!pending.SawDepthReduction && volume < pending.ObservedDepthBeforeTrade)
        {
            pending.SawDepthReduction = true;
            return;
        }

        // An increase is a replenishment only after an observed reduction caused
        // by a recent aggressive trade. The first snapshot cannot qualify.
        if (!pending.SawDepthReduction || volume <= 0 || volume <= previousVolume)
            return;

        if (!_levels.TryGetValue(key, out var tracker))
        {
            tracker = new PriceLevelTracker
            {
                Price = p,
                IsBid = isBid,
                FirstSeen = time,
                CumulativeFilled = pending.FilledVolume,
                LastActivity = time
            };
            _levels[key] = tracker;
        }

        if (tracker.CurrentState != State.Exhausted)
        {
            bool sameSize = tracker.ReplenishCount == 0 ||
                Math.Abs(volume - tracker.ReplenishSize) / Math.Max(volume, tracker.ReplenishSize) <= _sizeTolerance;

            if (sameSize)
            {
                tracker.ReplenishCount++;
                tracker.ReplenishSize = volume;
                tracker.LastReplenish = time;
                tracker.LastActivity = time;

                if (tracker.ReplenishCount >= _confirmThreshold)
                    tracker.CurrentState = State.Confirmed;
                else if (tracker.ReplenishCount >= 1)
                    tracker.CurrentState = State.Suspected;
            }
        }

        _pendingSyntheticFills.Remove(key);
    }

    /// <summary>
    /// Call only after a same-order MBO reduction is followed by a replenishment.
    /// </summary>
    public void OnMboNativeIceberg(long exchangeOrderId, decimal price, decimal visibleVolume,
        decimal filledVolume, bool isBid, DateTime time)
    {
        var p = RoundPrice(price);
        if (!_nativeLevels.TryGetValue(exchangeOrderId, out var tracker))
        {
            tracker = new PriceLevelTracker
            {
                Price = p,
                IsBid = isBid,
                FirstSeen = time,
                ExchangeOrderId = exchangeOrderId
            };
            _nativeLevels[exchangeOrderId] = tracker;
        }

        tracker.ExchangeOrderId = exchangeOrderId;
        tracker.IsNative = true;
        tracker.ReplenishCount++;
        tracker.ReplenishSize = visibleVolume;
        tracker.CumulativeFilled += Math.Max(0m, filledVolume);
        tracker.LastReplenish = time;
        tracker.LastActivity = time;

        if (tracker.ReplenishCount >= _confirmThreshold)
            tracker.CurrentState = State.Confirmed;
        else
            tracker.CurrentState = State.Suspected;
    }

    /// <summary>
    /// Periodic check: expire levels that haven't had activity.
    /// </summary>
    public void CheckTimeout(DateTime now)
    {
        foreach (var tracker in _levels.Values.Concat(_nativeLevels.Values))
        {
            if (tracker.CurrentState is State.Confirmed or State.Suspected &&
                (now - tracker.LastReplenish) > _exhaustTimeout)
            {
                tracker.CurrentState = State.Exhausted;
                tracker.ExhaustedAt = now;
            }
        }

        foreach (var key in _pendingSyntheticFills
                     .Where(pair => now - pair.Value.Time > _exhaustTimeout)
                     .Select(pair => pair.Key)
                     .ToList())
            _pendingSyntheticFills.Remove(key);

        var retention = _exhaustTimeout + _exhaustTimeout;
        foreach (var key in _levels
                     .Where(pair => pair.Value.CurrentState == State.Exhausted && now - pair.Value.LastActivity > retention)
                     .Select(pair => pair.Key)
                     .ToList())
            _levels.Remove(key);
        foreach (var key in _nativeLevels
                     .Where(pair => pair.Value.CurrentState == State.Exhausted && now - pair.Value.LastActivity > retention)
                     .Select(pair => pair.Key)
                     .ToList())
            _nativeLevels.Remove(key);
        foreach (var key in _depthByLevel
                     .Where(pair => now - pair.Value.Time > retention)
                     .Select(pair => pair.Key)
                     .ToList())
            _depthByLevel.Remove(key);
    }

    /// <summary>
    /// Aggregate evidence score at current bar: max score across all active levels.
    /// </summary>
    public decimal AggregateScore()
    {
        return _levels.Values.Concat(_nativeLevels.Values)
            .Where(l => l.CurrentState is State.Suspected or State.Confirmed)
            .Select(l => l.EvidenceScore)
            .DefaultIfEmpty(0)
            .Max();
    }

    /// <summary>
    /// Lower-bound estimate of hidden quantity already consumed across confirmed icebergs.
    /// </summary>
    public decimal TotalEstimatedHidden()
    {
        return _levels.Values.Concat(_nativeLevels.Values)
            .Where(l => l.CurrentState == State.Confirmed)
            .Sum(l => l.EstimatedConsumedHidden);
    }

    public void Clear()
    {
        _levels.Clear();
        _nativeLevels.Clear();
        _pendingSyntheticFills.Clear();
        _depthByLevel.Clear();
    }

    private decimal RoundPrice(decimal p) =>
        _tickSize > 0 ? Math.Round(p / _tickSize) * _tickSize : p;
}
