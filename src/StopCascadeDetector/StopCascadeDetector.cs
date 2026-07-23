using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ATAS.Indicators;
using ATAS.Indicators.Drawing;

namespace ATAS.CustomIndicators;

/// <summary>
/// Detects stop-loss cascade events using:
///   1. Key level breakthrough (swing highs/lows + round numbers)
///   2. Volume spike relative to baseline
///   3. CumulativeTrade pre/post bid-ask spread widening
///   4. Order book depth erosion (periodic snapshot comparison)
///
/// Output series:
///   - CascadeScore (0-100): heuristic evidence score, not a probability
///   - CascadeDirection (-1=down, 0=none, +1=up): breakout direction
///   - RegimeLabel (0=stable, 1=build-up, 2=stress): market regime
///   - VolumeSpikeRatio: current volume / baseline volume average
/// </summary>
[DisplayName("Stop Cascade Detector")]
[Category("Order Flow")]
public class StopCascadeDetector : Indicator
{
    // -- Parameters -------------------------------------------
    private int _swingLookback = 20;
    private decimal _roundIncrement = 1.00m;
    private decimal _breakthroughThreshold = 0.1m;    // % beyond level to trigger
    private decimal _volumeSpikeMultiplier = 2.5m;
    private int _volumeBaselinePeriod = 50;
    private int _cascadeConsecutiveBars = 3;
    private decimal _spreadWideningRatio = 1.5m;
    private decimal _depthErosionThreshold = 0.35m;   // 35% depth loss
    private int _depthCheckSeconds = 3;
    private int _depthLevels = 10;
    private int _depthStaleSeconds = 6;
    private int _levelProximityTicks = 2;
    private bool _showKeyLevels = true;
    private bool _enableAlerts = false;
    private bool _depthTimerSubscribed;

    [Display(Name = "Swing Lookback", GroupName = "Key Levels")]
    [Range(5, 100)]
    public int SwingLookback
    {
        get => _swingLookback;
        set
        {
            _swingLookback = value;
            RecreateLevelCalculator();
            RecalculateKeyLevels();
        }
    }

    [Display(Name = "Round Increment", GroupName = "Key Levels",
        Description = "Price interval for round-number levels")]
    [Range(0.01, 100000)]
    public decimal RoundIncrement
    {
        get => _roundIncrement;
        set
        {
            _roundIncrement = value;
            RecreateLevelCalculator();
            RecalculateKeyLevels();
        }
    }

    [Display(Name = "Breakthrough %", GroupName = "Key Levels",
        Description = "Price must exceed level by this % to trigger")]
    [Range(0.01, 1.0)]
    public decimal BreakthroughThreshold
    {
        get => _breakthroughThreshold;
        set => _breakthroughThreshold = value;
    }

    [Display(Name = "Volume Spike x", GroupName = "Volume")]
    [Range(1.5, 10)]
    public decimal VolumeSpikeMultiplier
    {
        get => _volumeSpikeMultiplier;
        set => _volumeSpikeMultiplier = value;
    }

    [Display(Name = "Volume Baseline Bars", GroupName = "Volume")]
    [Range(10, 500)]
    public int VolumeBaselinePeriod
    {
        get => _volumeBaselinePeriod;
        set
        {
            _volumeBaselinePeriod = value;
            _volumeHistory = new RingBuffer<decimal>(_volumeBaselinePeriod);
        }
    }

    [Display(Name = "Cascade Consecutive Bars", GroupName = "Detection")]
    [Range(2, 10)]
    public int CascadeConsecutiveBars
    {
        get => _cascadeConsecutiveBars;
        set => _cascadeConsecutiveBars = value;
    }

    [Display(Name = "Spread Widening Ratio", GroupName = "Detection")]
    [Range(1.1, 5.0)]
    public decimal SpreadWideningRatio
    {
        get => _spreadWideningRatio;
        set => _spreadWideningRatio = value;
    }

    [Display(Name = "Depth Erosion %", GroupName = "Depth")]
    [Range(0.10, 0.80)]
    public decimal DepthErosionThreshold
    {
        get => _depthErosionThreshold;
        set => _depthErosionThreshold = value;
    }

    [Display(Name = "Depth Check (s)", GroupName = "Depth")]
    [Range(1, 30)]
    public int DepthCheckSeconds
    {
        get => _depthCheckSeconds;
        set
        {
            if (_depthTimerSubscribed)
                UnsubscribeFromTimer(TimeSpan.FromSeconds(_depthCheckSeconds), CheckDepthErosion);
            _depthCheckSeconds = value;
            if (_depthTimerSubscribed)
                SubscribeToTimer(TimeSpan.FromSeconds(_depthCheckSeconds), CheckDepthErosion);
        }
    }

    [Display(Name = "Depth Levels", GroupName = "Depth",
        Description = "Near-touch levels summed on each side of the order book")]
    [Range(1, 50)]
    public int DepthLevels
    {
        get => _depthLevels;
        set => _depthLevels = value;
    }

    [Display(Name = "Depth Stale Timeout (s)", GroupName = "Depth",
        Description = "Ignore DOM evidence when no newer snapshot is received")]
    [Range(1, 60)]
    public int DepthStaleSeconds
    {
        get => _depthStaleSeconds;
        set => _depthStaleSeconds = value;
    }

    [Display(Name = "Level Proximity (ticks)", GroupName = "Key Levels",
        Description = "Trade distance from a key level accepted as order-flow evidence")]
    [Range(1, 100)]
    public int LevelProximityTicks
    {
        get => _levelProximityTicks;
        set => _levelProximityTicks = value;
    }

    [Display(Name = "Show Key Levels", GroupName = "Display")]
    public bool ShowKeyLevels
    {
        get => _showKeyLevels;
        set => _showKeyLevels = value;
    }

    [Display(Name = "Enable Alerts", GroupName = "Alerts")]
    public bool EnableAlerts
    {
        get => _enableAlerts;
        set => _enableAlerts = value;
    }

    // -- Data Series ------------------------------------------
    private readonly ValueDataSeries _cascadeScore;
    private readonly ValueDataSeries _cascadeDirection;
    private readonly ValueDataSeries _regimeLabel;
    private readonly ValueDataSeries _volumeSpikeRatio;
    private readonly ValueDataSeries _depthErosionScore;

    // -- Runtime State ----------------------------------------
    private List<decimal> _keyLevels = new();
    private HashSet<decimal> _keyLevelSet = new();
    private KeyLevelCalculator? _levelCalc;
    private RingBuffer<decimal>? _volumeHistory;
    private decimal _baselineVolume;
    private int _consecutiveStressBars;
    private decimal _upwardSpreadScore;
    private decimal _downwardSpreadScore;
    private int _intrabarEvidenceBar = -1;
    private int _lastRegimeBar = -1;
    private int _lastFinalizedRegimeBar = -1;
    private int _lastLevelUpdateBar = -1;
    // Depth erosion tracking
    private decimal _baselineBidDepth;
    private decimal _baselineAskDepth;
    private decimal _currentBidDepth;
    private decimal _currentAskDepth;
    private decimal _latestDepthErosion;
    private decimal _latestBidErosion;
    private decimal _latestAskErosion;
    private DateTime _lastDepthMarketTime = DateTime.MinValue;
    private DateTime _lastDepthReceipt = DateTime.MinValue;

    // Active cascade tracking
    public enum RegimeState { Stable = 0, BuildUp = 1, Stress = 2 }
    public enum CascadeDirection { None = 0, Down = -1, Up = 1 }
    private RegimeState _currentRegime = RegimeState.Stable;
    private DateTime? _regimeStartTime;
    private bool _alertSent;

    public StopCascadeDetector() : base(useCandles: true)
    {
        // Keep the ID for backward compatibility with existing ATAS templates.
        _cascadeScore = new ValueDataSeries("CascadeProb", "Cascade Score");
        _cascadeDirection = new ValueDataSeries("CascadeDirection", "Cascade Direction");
        _regimeLabel = new ValueDataSeries("Regime");
        _volumeSpikeRatio = new ValueDataSeries("VolumeSpike");
        _depthErosionScore = new ValueDataSeries("DepthErosion");

        DataSeries.Add(_cascadeScore);
        DataSeries.Add(_cascadeDirection);
        DataSeries.Add(_regimeLabel);
        DataSeries.Add(_volumeSpikeRatio);
        DataSeries.Add(_depthErosionScore);

        Panel = IndicatorDataProvider.NewPanel;
    }

    // ---------------------------------------------------------
    //  Lifecycle
    // ---------------------------------------------------------

    protected override void OnInitialize()
    {
        var tickSize = InstrumentInfo?.TickSize ?? 0.01m;
        _levelCalc = new KeyLevelCalculator(_swingLookback, tickSize, _roundIncrement);

        // Initialize volume ring buffer
        _volumeHistory = new RingBuffer<decimal>(_volumeBaselinePeriod);

        // Start periodic depth checking
        SubscribeToTimer(
            TimeSpan.FromSeconds(_depthCheckSeconds),
            CheckDepthErosion);
        _depthTimerSubscribed = true;
    }

    protected override void OnRecalculate()
    {
        _keyLevels.Clear();
        _keyLevelSet.Clear();
        ResetSessionState();
        _lastRegimeBar = -1;
        _lastFinalizedRegimeBar = -1;
        _lastLevelUpdateBar = -1;
    }

    protected override void OnCalculate(int bar, decimal value)
    {
        if (bar == 0)
            return;

        if (IsNewSession(bar))
        {
            ResetSessionState();
            _lastRegimeBar = -1;
            _lastFinalizedRegimeBar = -1;
        }

        var candle = GetCandle(bar);
        AddCausallyConfirmedLevels(bar, candle.Close);

        // Exclude the current candle from its own baseline.
        _baselineVolume = _volumeHistory!.Count > 0
            ? _volumeHistory.Average(v => v)
            : 0m;
        _volumeHistory.Add(candle.Volume);

        // Compute volume spike ratio
        var ratio = _baselineVolume > 0
            ? candle.Volume / _baselineVolume
            : 1.0m;
        _volumeSpikeRatio[bar] = ratio;

        var direction = GetBreakoutDirection(GetCandle(bar - 1).Close, candle.Close);
        var breakoutScore = direction == CascadeDirection.None ? 0m : 1m;
        var volumeScore = Normalize(ratio, 1m, _volumeSpikeMultiplier);
        var depthIsFresh = IsDepthFresh();
        var directionalErosion = depthIsFresh ? (direction switch
        {
            CascadeDirection.Up => _latestAskErosion,
            CascadeDirection.Down => _latestBidErosion,
            _ => 0m
        }) : 0m;
        var depthScore = Normalize(directionalErosion, 0m, _depthErosionThreshold);
        var spreadScore = _intrabarEvidenceBar == bar
            ? direction switch
            {
                CascadeDirection.Up => _upwardSpreadScore,
                CascadeDirection.Down => _downwardSpreadScore,
                _ => 0m
            }
            : 0m;
        var supportCount = (volumeScore > 0 ? 1 : 0) + (depthScore > 0 ? 1 : 0) + (spreadScore > 0 ? 1 : 0);
        var hasDirectionalSupport = depthScore > 0 || spreadScore > 0;

        // A level break must be corroborated by same-direction liquidity or
        // aggressor evidence. Volume remains useful, but cannot qualify alone.
        var score = breakoutScore > 0 && hasDirectionalSupport && supportCount > 0
            ? 100m * (0.35m * breakoutScore + 0.25m * volumeScore +
                      0.20m * depthScore + 0.20m * spreadScore)
            : 0m;
        _cascadeScore[bar] = score;
        _cascadeDirection[bar] = (decimal)(int)direction;

        // Finalize a bar only when the next one begins. OnCalculate is also
        // invoked intra-bar, so updating here on every tick would inflate the
        // consecutive-bar counters.
        if (_lastRegimeBar >= 0 && _lastRegimeBar != bar && _lastRegimeBar != _lastFinalizedRegimeBar)
        {
            UpdateRegime(_lastRegimeBar, _cascadeScore[_lastRegimeBar]);
            _lastFinalizedRegimeBar = _lastRegimeBar;
        }
        _lastRegimeBar = bar;
        _regimeLabel[bar] = (decimal)(int)_currentRegime;

        // Store latest depth erosion
        _depthErosionScore[bar] = depthIsFresh ? _latestDepthErosion : 0m;

        if (_enableAlerts && score >= 80m && !_alertSent)
        {
            AddAlert("cascade_alert", InstrumentInfo?.Instrument ?? "",
                $"Stop cascade candidate: direction={direction} | score={score:F0} | " +
                $"Price={candle.Close:F2} | Volume={ratio:F1}x | Depth={directionalErosion:P0}",
                System.Drawing.Color.Red, System.Drawing.Color.White);
            _alertSent = true;
        }
    }

    protected override void OnFinishRecalculate()
    {
        if (_lastRegimeBar >= 0 && _lastRegimeBar != _lastFinalizedRegimeBar)
        {
            UpdateRegime(_lastRegimeBar, _cascadeScore[_lastRegimeBar]);
            _lastFinalizedRegimeBar = _lastRegimeBar;
        }
        // Levels are added as their confirming bar closes in OnCalculate.
    }

    protected override void OnDispose()
    {
        if (_depthTimerSubscribed)
        {
            UnsubscribeFromTimer(TimeSpan.FromSeconds(_depthCheckSeconds), CheckDepthErosion);
            _depthTimerSubscribed = false;
        }
    }

    // ---------------------------------------------------------
    //  Tick-level: CumulativeTrade (richest signal)
    // ---------------------------------------------------------

    protected override void OnCumulativeTrade(CumulativeTrade trade)
    {
        // Pre/post spread analysis
        if (trade.PreviousAsk != null && trade.PreviousBid != null &&
            trade.NewAsk != null && trade.NewBid != null)
        {
            var preSpread = trade.PreviousAsk.Price - trade.PreviousBid.Price;
            var postSpread = trade.NewAsk.Price - trade.NewBid.Price;

            // Spread widening is supporting evidence, not proof of a stop cascade.
            if (preSpread > 0 && postSpread > preSpread * _spreadWideningRatio)
            {
                if (IsNearKeyLevel(trade.Lastprice))
                {
                    var bar = CurrentBar;
                    if (bar >= 0)
                    {
                        if (_intrabarEvidenceBar != bar)
                        {
                            _intrabarEvidenceBar = bar;
                            _upwardSpreadScore = 0m;
                            _downwardSpreadScore = 0m;
                        }

                        var score = Normalize(postSpread / preSpread, 1m, _spreadWideningRatio);
                        if (trade.Direction == TradeDirection.Buy)
                            _upwardSpreadScore = Math.Max(_upwardSpreadScore, score);
                        else if (trade.Direction == TradeDirection.Sell)
                            _downwardSpreadScore = Math.Max(_downwardSpreadScore, score);
                    }
                }
            }
        }

    }

    // ---------------------------------------------------------
    //  Depth Erosion Check (timer-based)
    // ---------------------------------------------------------

    private void CheckDepthErosion()
    {
        try
        {
            var snapshot = GetMarketDepthSnapshot();
            if (snapshot == null) return;

            var entries = snapshot.ToList();
            if (entries.Count == 0)
                return;

            var latestMarketTime = entries.Max(depth => depth.Time);
            if (latestMarketTime <= _lastDepthMarketTime)
                return;

            _lastDepthMarketTime = latestMarketTime;
            var tickSize = InstrumentInfo?.TickSize ?? 0.01m;
            var bidEntries = entries.Where(depth => depth.IsBid).ToList();
            var askEntries = entries.Where(depth => depth.IsAsk).ToList();
            if (bidEntries.Count == 0 || askEntries.Count == 0)
                return;

            var bestBid = bidEntries.Max(depth => depth.Price);
            var bestAsk = askEntries.Min(depth => depth.Price);
            _currentBidDepth = bidEntries
                .Where(depth => depth.Price >= bestBid - (_depthLevels - 1) * tickSize)
                .Sum(depth => depth.Volume);
            _currentAskDepth = askEntries
                .Where(depth => depth.Price <= bestAsk + (_depthLevels - 1) * tickSize)
                .Sum(depth => depth.Volume);
            _lastDepthReceipt = DateTime.Now;

            // Initialize baselines
            if (_baselineBidDepth == 0 || _baselineAskDepth == 0)
            {
                if (_currentBidDepth <= 0m || _currentAskDepth <= 0m)
                    return;
                _baselineBidDepth = _currentBidDepth;
                _baselineAskDepth = _currentAskDepth;
                _latestDepthErosion = 0m;
                _latestBidErosion = 0m;
                _latestAskErosion = 0m;
                return;
            }

            // Evaluate against the pre-update baseline so the signal is not
            // muted by the same sample that caused the erosion.
            _latestBidErosion = ComputeBidErosion();
            _latestAskErosion = ComputeAskErosion();
            _latestDepthErosion = Math.Max(_latestBidErosion, _latestAskErosion);

            // Update adaptive baseline via EMA
            const decimal emaAlpha = 0.05m;  // slow adaptation
            _baselineBidDepth = emaAlpha * _currentBidDepth + (1 - emaAlpha) * _baselineBidDepth;
            _baselineAskDepth = emaAlpha * _currentAskDepth + (1 - emaAlpha) * _baselineAskDepth;

        }
        catch
        {
            // ponytail: silent fail on snapshot errors (race with data feed restart)
        }
    }

    private decimal ComputeBidErosion() => _baselineBidDepth > 0
        ? Math.Max(0m, 1m - _currentBidDepth / _baselineBidDepth)
        : 0m;

    private decimal ComputeAskErosion() => _baselineAskDepth > 0
        ? Math.Max(0m, 1m - _currentAskDepth / _baselineAskDepth)
        : 0m;

    // ---------------------------------------------------------
    //  Regime State Machine
    // ---------------------------------------------------------

    private void UpdateRegime(int bar, decimal score)
    {
        switch (_currentRegime)
        {
            case RegimeState.Stable:
                if (score >= 50m)
                {
                    _currentRegime = RegimeState.BuildUp;
                    _regimeStartTime = GetCandle(bar).Time;
                    _consecutiveStressBars = score >= 70m ? 1 : 0;
                    _alertSent = false;
                }
                break;

            case RegimeState.BuildUp:
                if (score >= 70m)
                {
                    _consecutiveStressBars++;
                    if (_consecutiveStressBars >= _cascadeConsecutiveBars)
                    {
                        _currentRegime = RegimeState.Stress;
                    }
                }
                else
                {
                    _consecutiveStressBars = 0;
                    var now = GetCandle(bar).Time;
                    if (score < 20m && (now - (_regimeStartTime ?? now)).TotalSeconds > 30)
                    {
                        _currentRegime = RegimeState.Stable;
                    }
                }
                break;

            case RegimeState.Stress:
                if (score < 30m)
                {
                    _consecutiveStressBars++;
                    if (_consecutiveStressBars >= _cascadeConsecutiveBars)
                    {
                        _currentRegime = RegimeState.Stable;
                        _consecutiveStressBars = 0;
                        _alertSent = false;
                    }
                }
                else
                {
                    _consecutiveStressBars = 0;
                }
                break;
        }
    }

    // ---------------------------------------------------------
    //  Key Level Management
    // ---------------------------------------------------------

    private bool IsNearKeyLevel(decimal price)
    {
        if (_keyLevels.Count == 0 || _levelCalc == null) return false;
        var tickSize = InstrumentInfo?.TickSize ?? 0.01m;
        return _keyLevels.Any(level => Math.Abs(price - level) <= _levelProximityTicks * tickSize);
    }

    private void AddCausallyConfirmedLevels(int bar, decimal price)
    {
        if (_levelCalc == null)
            return;

        if (_lastLevelUpdateBar == bar)
            return;

        _lastLevelUpdateBar = bar;
        foreach (var level in _levelCalc.ConfirmedLevelsAt(this, bar))
            _keyLevelSet.Add(level);
        foreach (var level in _levelCalc.RoundLevelsAround(price))
            _keyLevelSet.Add(level);
        _keyLevels = _keyLevelSet.OrderBy(level => level).ToList();
    }

    private void ResetSessionState()
    {
        _volumeHistory?.Clear();
        _baselineVolume = 0m;
        _baselineBidDepth = 0m;
        _baselineAskDepth = 0m;
        _currentBidDepth = 0m;
        _currentAskDepth = 0m;
        _latestDepthErosion = 0m;
        _latestBidErosion = 0m;
        _latestAskErosion = 0m;
        _lastDepthMarketTime = DateTime.MinValue;
        _lastDepthReceipt = DateTime.MinValue;
        _upwardSpreadScore = 0m;
        _downwardSpreadScore = 0m;
        _intrabarEvidenceBar = -1;
        _currentRegime = RegimeState.Stable;
        _regimeStartTime = null;
        _consecutiveStressBars = 0;
        _alertSent = false;
    }

    private void RecreateLevelCalculator()
    {
        _levelCalc = new KeyLevelCalculator(
            _swingLookback,
            InstrumentInfo?.TickSize ?? 0.01m,
            _roundIncrement);
    }

    private CascadeDirection GetBreakoutDirection(decimal previousClose, decimal close)
    {
        if (_keyLevels.Count == 0)
            return CascadeDirection.None;

        var threshold = _breakthroughThreshold / 100m;
        foreach (var level in _keyLevels)
        {
            if (previousClose <= level && close > level * (1m + threshold))
                return CascadeDirection.Up;
            if (previousClose >= level && close < level * (1m - threshold))
                return CascadeDirection.Down;
        }

        return CascadeDirection.None;
    }

    private static decimal Normalize(decimal value, decimal minimum, decimal maximum)
    {
        if (maximum <= minimum)
            return 0m;

        return Math.Clamp((value - minimum) / (maximum - minimum), 0m, 1m);
    }

    private void RecalculateKeyLevels()
    {
        try
        {
            var totalBars = CurrentBar + 1;
            if (_levelCalc != null && totalBars > 0)
            {
                _keyLevelSet.Clear();
                for (var bar = 0; bar < totalBars; bar++)
                {
                    foreach (var level in _levelCalc.ConfirmedLevelsAt(this, bar))
                        _keyLevelSet.Add(level);
                    foreach (var level in _levelCalc.RoundLevelsAround(GetCandle(bar).Close))
                        _keyLevelSet.Add(level);
                }
                _keyLevels = _keyLevelSet.OrderBy(level => level).ToList();
                _lastLevelUpdateBar = CurrentBar;
            }
        }
        catch
        {
            _keyLevels = new List<decimal>();
            _keyLevelSet.Clear();
        }
    }

    private bool IsDepthFresh() => _lastDepthReceipt != DateTime.MinValue &&
        (DateTime.Now - _lastDepthReceipt).TotalSeconds <= _depthStaleSeconds;

    // ---------------------------------------------------------
    //  Rendering
    // ---------------------------------------------------------

    protected override void OnRender(RenderContext context, DrawingLayouts layout)
    {
        if (!_showKeyLevels || layout != DrawingLayouts.Panel)
            return;

        // Draw key levels as horizontal lines
        foreach (var level in _keyLevels)
        {
            var tag = $"kl_{level:F4}";
            if (!Labels.ContainsKey(tag))
            {
                AddText(tag, $"KL {level:F2}", true,
                    CurrentBar, level, 0, 0,
                    System.Drawing.Color.Gray,
                    System.Drawing.Color.Transparent,
                    System.Drawing.Color.Transparent,
                    8, DrawingText.TextAlign.Left);
            }
        }

        // Draw regime indicator
        var regimeColor = _currentRegime switch
        {
            RegimeState.Stress => System.Drawing.Color.Red,
            RegimeState.BuildUp => System.Drawing.Color.Orange,
            _ => System.Drawing.Color.Green
        };

        var regimeText = _currentRegime switch
        {
            RegimeState.Stress => "⚠ STRESS",
            RegimeState.BuildUp => "◉ BUILD-UP",
            _ => "● STABLE"
        };

        AddText("regime_label", regimeText, false,
            CurrentBar, 0, -40, 0,
            System.Drawing.Color.White,
            System.Drawing.Color.Black,
            regimeColor, 12, DrawingText.TextAlign.Left);
    }
}
