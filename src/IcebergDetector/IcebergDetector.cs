using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ATAS.Indicators;
using ATAS.Indicators.Drawing;

namespace ATAS.CustomIndicators;

/// <summary>
/// Detects iceberg (hidden) orders using order book replenishment patterns.
///
/// Methods:
///   - Synthetic candidates: same-side depth replenishment after an aggressive trade
///   - Native candidates: same MBO order ID replenishes after a partial reduction
///
/// Output series:
///   - IcebergScore (0-100): heuristic evidence score, not a probability
///   - HiddenVolume: lower-bound estimate of already consumed hidden volume
///   - ActiveCount: number of price levels with suspected/confirmed icebergs
/// </summary>
[DisplayName("Iceberg Detector")]
[Category("Order Flow")]
public class IcebergDetector : Indicator
{
    private IcebergStateMachine _fsm = null!;

    // -- Parameters -------------------------------------------
    private int _confirmThreshold = 3;
    private int _exhaustSeconds = 30;
    private decimal _sizeTolerance = 0.15m;
    private bool _showLabels = true;
    private bool _useMboData = true;
    private int _nativeReplenishWindowMs = 1000;

    [Display(Name = "Confirm Threshold", GroupName = "Detection",
        Description = "Number of replenishments to confirm iceberg")]
    [Range(2, 10)]
    public int ConfirmThreshold
    {
        get => _confirmThreshold;
        set { _confirmThreshold = value; RecreateFsm(); }
    }

    [Display(Name = "Exhaust Timeout (s)", GroupName = "Detection",
        Description = "Seconds without replenishment before marking exhausted")]
    [Range(5, 120)]
    public int ExhaustSeconds
    {
        get => _exhaustSeconds;
        set { _exhaustSeconds = value; RecreateFsm(); }
    }

    [Display(Name = "Size Tolerance", GroupName = "Detection",
        Description = "Max % deviation in replenish size to match")]
    [Range(0.05, 0.50)]
    public decimal SizeTolerance
    {
        get => _sizeTolerance;
        set { _sizeTolerance = value; RecreateFsm(); }
    }

    [Display(Name = "Show Price Labels", GroupName = "Display")]
    public bool ShowLabels
    {
        get => _showLabels;
        set => _showLabels = value;
    }

    [Display(Name = "Use MBO Data", GroupName = "Data Source",
        Description = "Enable Market-By-Order tracking for native iceberg detection")]
    public bool UseMboData
    {
        get => _useMboData;
        set
        {
            var wasUsingMboData = _useMboData;
            _useMboData = value;
            if (value && !wasUsingMboData && _timeoutTimerSubscribed)
                _ = SubscribeMarketByOrderData();
        }
    }

    [Display(Name = "Native Replenish Window (ms)", GroupName = "Data Source",
        Description = "Maximum delay between an MBO reduction and same-ID replenishment")]
    [Range(50, 5000)]
    public int NativeReplenishWindowMs
    {
        get => _nativeReplenishWindowMs;
        set => _nativeReplenishWindowMs = value;
    }

    // -- Data Series ------------------------------------------
    private readonly ValueDataSeries _icebergScore;
    private readonly ValueDataSeries _hiddenVolume;
    private readonly ValueDataSeries _activeCount;

    // -- Runtime State ----------------------------------------
    private sealed class MboOrderState
    {
        public decimal Price;
        public decimal Volume;
        public bool IsBid;
        public decimal PendingFillVolume;
        public DateTime PendingFillTime;
    }

    private readonly Dictionary<long, MboOrderState> _mboOrders = new();
    private bool _timeoutTimerSubscribed;

    public IcebergDetector() : base(useCandles: true)
    {
        _icebergScore = new ValueDataSeries("IcebergScore");
        _hiddenVolume = new ValueDataSeries("HiddenVolume");
        _activeCount = new ValueDataSeries("ActiveCount");

        DataSeries.Add(_icebergScore);
        DataSeries.Add(_hiddenVolume);
        DataSeries.Add(_activeCount);

        // Plot in separate panel below price
        Panel = IndicatorDataProvider.NewPanel;
    }

    // ---------------------------------------------------------
    //  Lifecycle
    // ---------------------------------------------------------

    protected override void OnInitialize()
    {
        RecreateFsm();

        if (UseMboData)
        {
            // The ATAS API returns a Task and starts the subscription immediately.
            _ = SubscribeMarketByOrderData();
        }

        SubscribeToTimer(TimeSpan.FromSeconds(1), ExpireInactiveLevels);
        _timeoutTimerSubscribed = true;
    }

    protected override void OnRecalculate()
    {
        if (_fsm is not null)
            _fsm.Clear();
        _mboOrders.Clear();
    }

    protected override void OnCalculate(int bar, decimal value)
    {
        if (bar > 0 && IsNewSession(bar))
        {
            _fsm.Clear();
            _mboOrders.Clear();
        }

        // Called for each bar (historical + live).
        // Store current aggregated state at this bar.
        _icebergScore[bar] = _fsm.AggregateScore();
        _hiddenVolume[bar] = _fsm.TotalEstimatedHidden();
        _activeCount[bar] = _fsm.ActiveLevels.Count(l => l.CurrentState == IcebergStateMachine.State.Confirmed);
    }

    protected override void OnFinishRecalculate()
    {
        if (CurrentBar >= 0)
            _fsm.CheckTimeout(GetCandle(CurrentBar).Time);
    }

    // ---------------------------------------------------------
    //  Tick-level event handlers
    // ---------------------------------------------------------

    protected override void OnNewTrade(MarketDataArg trade)
    {
        _fsm.CheckTimeout(trade.Time);
        bool? restingIsBid = trade.Direction switch
        {
            TradeDirection.Buy => false,
            TradeDirection.Sell => true,
            _ => null
        };
        _fsm.OnTrade(trade.Price, trade.Volume, trade.Time, restingIsBid);

        // Update current bar's values
        if (CurrentBar >= 0)
        {
            _icebergScore[CurrentBar] = _fsm.AggregateScore();
            _hiddenVolume[CurrentBar] = _fsm.TotalEstimatedHidden();
            _activeCount[CurrentBar] = _fsm.ActiveLevels.Count(
                l => l.CurrentState == IcebergStateMachine.State.Confirmed);
        }
    }

    protected override void MarketDepthChanged(MarketDataArg depth)
    {
        _fsm.CheckTimeout(depth.Time);
        _fsm.OnDepthChanged(depth.Price, depth.Volume, depth.Time, depth.IsBid);
    }

    protected override void MarketDepthsChanged(IEnumerable<MarketDataArg> depths)
    {
        foreach (var d in depths)
        {
            _fsm.CheckTimeout(d.Time);
            _fsm.OnDepthChanged(d.Price, d.Volume, d.Time, d.IsBid);
        }
    }

    protected override void OnMarketByOrdersChanged(IEnumerable<MarketByOrder> values)
    {
        if (!_useMboData) return;

        foreach (var mbo in values)
        {
            var isBid = mbo.Side == MarketDataType.Bid;
            if (_mboOrders.TryGetValue(mbo.ExchangeOrderId, out var prev))
            {
                if (prev.PendingFillVolume > 0 &&
                    (mbo.Time - prev.PendingFillTime).TotalMilliseconds > _nativeReplenishWindowMs)
                {
                    prev.PendingFillVolume = 0;
                }

                if (mbo.Volume <= 0)
                {
                    // Order removed (cancel/delete/filled).
                    _mboOrders.Remove(mbo.ExchangeOrderId);
                }
                else if (mbo.Volume < prev.Volume)
                {
                    // A reduction alone is not iceberg evidence. Wait for a same-ID refill.
                    prev.PendingFillVolume += prev.Volume - mbo.Volume;
                    prev.PendingFillTime = mbo.Time;
                }
                else if (mbo.Volume > prev.Volume && prev.PendingFillVolume > 0 &&
                    mbo.Price == prev.Price && isBid == prev.IsBid &&
                    (mbo.Time - prev.PendingFillTime).TotalMilliseconds is >= 0 and <= _nativeReplenishWindowMs)
                {
                    _fsm.OnMboNativeIceberg(
                        mbo.ExchangeOrderId,
                        mbo.Price,
                        mbo.Volume,
                        prev.PendingFillVolume,
                        isBid,
                        mbo.Time);
                    prev.PendingFillVolume = 0;
                }
            }

            if (mbo.Volume > 0)
            {
                if (!_mboOrders.TryGetValue(mbo.ExchangeOrderId, out var state))
                {
                    state = new MboOrderState();
                    _mboOrders[mbo.ExchangeOrderId] = state;
                }

                state.Price = mbo.Price;
                state.Volume = mbo.Volume;
                state.IsBid = isBid;
            }
        }
    }

    // ---------------------------------------------------------
    //  Rendering
    // ---------------------------------------------------------

    protected override void OnRender(RenderContext context, DrawingLayouts layout)
    {
        if (layout != DrawingLayouts.Panel || !_showLabels)
            return;

        // Draw iceberg labels at confirmed price levels
        foreach (var level in _fsm.ActiveLevels)
        {
            if (level.CurrentState != IcebergStateMachine.State.Confirmed)
                continue;

            var color = level.IsNative
                ? System.Drawing.Color.Cyan
                : System.Drawing.Color.Orange;

            var label = level.IsNative
                ? $"ICE(N) {level.Price:F2} E{level.EvidenceScore:F0} x{level.ReplenishCount} H>={level.EstimatedConsumedHidden:F0}"
                : $"ICE(S) {level.Price:F2} E{level.EvidenceScore:F0} x{level.ReplenishCount} H>={level.EstimatedConsumedHidden:F0}";

            // Label at price level, offset to right
            AddText($"ice_{level.Price:F4}_{level.ExchangeOrderId ?? 0}", label, false,
                CurrentBar, level.Price, 0, 20,
                System.Drawing.Color.White,
                System.Drawing.Color.Black,
                color, 10,
                DrawingText.TextAlign.Left);
        }
    }

    // ---------------------------------------------------------
    //  Helpers
    // ---------------------------------------------------------

    private void RecreateFsm()
    {
        var tickSize = InstrumentInfo?.TickSize ?? 0.01m;
        _fsm = new IcebergStateMachine(
            tickSize: tickSize,
            confirmThreshold: _confirmThreshold,
            exhaustTimeout: TimeSpan.FromSeconds(_exhaustSeconds),
            sizeTolerance: _sizeTolerance);
    }

    protected override void OnDispose()
    {
        if (_timeoutTimerSubscribed)
        {
            UnsubscribeFromTimer(TimeSpan.FromSeconds(1), ExpireInactiveLevels);
            _timeoutTimerSubscribed = false;
        }
    }

    private void ExpireInactiveLevels() => _fsm.CheckTimeout(DateTime.Now);
}
