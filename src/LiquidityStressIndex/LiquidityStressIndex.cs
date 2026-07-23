using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ATAS.Indicators;
using ATAS.Indicators.Drawing;

namespace ATAS.CustomIndicators;

/// <summary>
/// Composite liquidity stress index combining multiple microstructure channels:
///   1. Depth erosion (bid/ask DOM decay rate)
///   2. Trade clustering intensity (branching ratio proxy)
///   3. Spread pressure (BBO widening trend)
///   4. Order flow imbalance volatility
///
/// Uses MAX aggregation with a rising-edge condition and adaptive thresholding.
/// The score is a heuristic market-quality signal, not a crash probability.
///
/// Output series:
///   - StressIndex (0-100): composite liquidity stress score
///   - DepthErosion: bid/ask depth erosion channel (0-100)
///   - TradeClustering: trade arrival clustering intensity
///   - SpreadPressure: spread widening pressure (0-100)
/// </summary>
[DisplayName("Liquidity Stress Index")]
[Category("Order Flow")]
public class LiquidityStressIndex : Indicator
{
    // -- Parameters -------------------------------------------
    private int _emaPeriod = 20;
    private decimal _stressWarningLevel = 60m;
    private decimal _stressCriticalLevel = 80m;
    private int _risingEdgeBars = 3;
    private int _minimumBaselineSamples = 20;
    private int _minimumConfirmingChannels = 2;
    private decimal _channelActivationScore = 20m;
    private decimal _spreadStressRatio = 1.5m;
    private decimal _ofiVolatilityRatio = 2m;
    private int _depthLevels = 10;
    private int _bboPairMaxSkewMilliseconds = 500;
    private int _dataStaleSeconds = 5;
    private bool _useAdaptiveThreshold = true;
    private bool _showChannelBreakdown = false;
    private bool _enableAlerts = false;

    [Display(Name = "EMA Smoothing", GroupName = "Signal")]
    [Range(5, 100)]
    public int EmaPeriod
    {
        get => _emaPeriod;
        set => _emaPeriod = value;
    }

    [Display(Name = "Warning Level", GroupName = "Thresholds")]
    [Range(30, 90)]
    public decimal StressWarningLevel
    {
        get => _stressWarningLevel;
        set => _stressWarningLevel = value;
    }

    [Display(Name = "Critical Level", GroupName = "Thresholds")]
    [Range(50, 100)]
    public decimal StressCriticalLevel
    {
        get => _stressCriticalLevel;
        set => _stressCriticalLevel = value;
    }

    [Display(Name = "Rising Edge Bars", GroupName = "Signal",
        Description = "Consecutive rising bars to confirm uptrend")]
    [Range(2, 10)]
    public int RisingEdgeBars
    {
        get => _risingEdgeBars;
        set => _risingEdgeBars = value;
    }

    [Display(Name = "Minimum Baseline Samples", GroupName = "Signal",
        Description = "Samples required before a channel contributes to alerts")]
    [Range(5, 200)]
    public int MinimumBaselineSamples
    {
        get => _minimumBaselineSamples;
        set => _minimumBaselineSamples = value;
    }

    [Display(Name = "Minimum Confirming Channels", GroupName = "Signal",
        Description = "Ready channels that must independently show abnormal stress")]
    [Range(2, 4)]
    public int MinimumConfirmingChannels
    {
        get => _minimumConfirmingChannels;
        set => _minimumConfirmingChannels = value;
    }

    [Display(Name = "Channel Activation Score", GroupName = "Signal",
        Description = "Minimum channel score counted as independent confirmation")]
    [Range(1, 100)]
    public decimal ChannelActivationScore
    {
        get => _channelActivationScore;
        set => _channelActivationScore = value;
    }

    [Display(Name = "Spread Stress Ratio", GroupName = "Signal",
        Description = "Spread / baseline ratio mapped to a score of 100")]
    [Range(1.1, 5.0)]
    public decimal SpreadStressRatio
    {
        get => _spreadStressRatio;
        set => _spreadStressRatio = value;
    }

    [Display(Name = "OFI Volatility Ratio", GroupName = "Signal",
        Description = "Short-term / baseline OFI volatility ratio mapped to a score of 100")]
    [Range(1.1, 5.0)]
    public decimal OfiVolatilityRatio
    {
        get => _ofiVolatilityRatio;
        set => _ofiVolatilityRatio = value;
    }

    [Display(Name = "Depth Levels", GroupName = "Signal",
        Description = "Near-touch levels summed on each side of the order book")]
    [Range(1, 50)]
    public int DepthLevels
    {
        get => _depthLevels;
        set => _depthLevels = value;
    }

    [Display(Name = "BBO Pair Max Skew (ms)", GroupName = "Signal",
        Description = "Maximum bid/ask timestamp gap accepted for a spread sample")]
    [Range(10, 5000)]
    public int BboPairMaxSkewMilliseconds
    {
        get => _bboPairMaxSkewMilliseconds;
        set => _bboPairMaxSkewMilliseconds = value;
    }

    [Display(Name = "Data Stale Timeout (s)", GroupName = "Signal",
        Description = "Ignore a channel when its source has not updated recently")]
    [Range(1, 60)]
    public int DataStaleSeconds
    {
        get => _dataStaleSeconds;
        set => _dataStaleSeconds = value;
    }

    [Display(Name = "Adaptive Threshold", GroupName = "Signal")]
    public bool UseAdaptiveThreshold
    {
        get => _useAdaptiveThreshold;
        set => _useAdaptiveThreshold = value;
    }

    [Display(Name = "Show Channels", GroupName = "Display")]
    public bool ShowChannelBreakdown
    {
        get => _showChannelBreakdown;
        set => _showChannelBreakdown = value;
    }

    [Display(Name = "Enable Alerts", GroupName = "Alerts")]
    public bool EnableAlerts
    {
        get => _enableAlerts;
        set => _enableAlerts = value;
    }

    // -- Data Series ------------------------------------------
    private readonly ValueDataSeries _stressIndex;
    private readonly ValueDataSeries _depthErosion;
    private readonly ValueDataSeries _tradeClustering;
    private readonly ValueDataSeries _spreadPressure;
    private readonly ValueDataSeries _adaptThreshold;
    private readonly ValueDataSeries _dataReadiness;
    private readonly ValueDataSeries _confirmingChannels;

    // -- Channels ---------------------------------------------
    // Channel 1: Depth erosion (bid/ask DOM decay)
    private decimal _baselineBidDepth;
    private decimal _baselineAskDepth;
    private decimal _currentBidDepth;
    private decimal _currentAskDepth;
    private DateTime _lastDepthReceipt = DateTime.MinValue;
    private DateTime _lastDepthMarketTime = DateTime.MinValue;
    private int _depthSamples;
    private decimal _latestBidErosion;
    private decimal _latestAskErosion;

    // Channel 2: Trade clustering (inter-trade interval)
    private DateTime _lastTradeTime = DateTime.MinValue;
    private DateTime _lastTradeReceipt = DateTime.MinValue;
    private RingBuffer<double>? _interTradeMs;
    private double _baselineInterTradeMs;
    private const int InterTradeWindow = 200;

    // Channel 3: Spread pressure
    private decimal _baselineSpread;
    private decimal _currentSpread;
    private decimal _bestBidPrice;
    private decimal _bestAskPrice;
    private DateTime _lastBboReceipt = DateTime.MinValue;
    private DateTime _lastBidMarketTime = DateTime.MinValue;
    private DateTime _lastAskMarketTime = DateTime.MinValue;
    private RingBuffer<decimal>? _spreadHistory;

    // Channel 4: OFI volatility
    private decimal _ofiSum;
    private decimal _intervalTradeVolume;
    private RingBuffer<decimal>? _ofiHistory;

    // -- Adaptive threshold -----------------------------------
    private decimal _adaptiveThreshold = 30m;
    private decimal _emaStressIndex;
    private RingBuffer<decimal>? _stressHistory;

    // -- State ------------------------------------------------
    private int _risingEdgeCount;
    private decimal _prevStressIndex;
    private bool _warningSent;
    private bool _criticalSent;
    private int _readyChannelCount;
    private int _confirmingChannelCount;

    // -- Timer subscriptions ----------------------------------
    private bool _timersSubscribed;

    public LiquidityStressIndex() : base(useCandles: true)
    {
        _stressIndex = new ValueDataSeries("StressIndex", "Liquidity Stress Score");
        _depthErosion = new ValueDataSeries("DepthErosion");
        _tradeClustering = new ValueDataSeries("TradeClustering");
        _spreadPressure = new ValueDataSeries("SpreadPressure");
        _adaptThreshold = new ValueDataSeries("AdaptThreshold");
        _dataReadiness = new ValueDataSeries("DataReadiness", "Ready Channels");
        _confirmingChannels = new ValueDataSeries("ConfirmingChannels", "Confirming Channels");

        DataSeries.Add(_stressIndex);
        DataSeries.Add(_depthErosion);
        DataSeries.Add(_tradeClustering);
        DataSeries.Add(_spreadPressure);
        DataSeries.Add(_adaptThreshold);
        DataSeries.Add(_dataReadiness);
        DataSeries.Add(_confirmingChannels);

        Panel = IndicatorDataProvider.NewPanel;
    }

    // ---------------------------------------------------------
    //  Lifecycle
    // ---------------------------------------------------------

    protected override void OnInitialize()
    {
        _interTradeMs = new RingBuffer<double>(InterTradeWindow);
        var historyCapacity = Math.Max(_emaPeriod * 2, 200);
        _spreadHistory = new RingBuffer<decimal>(historyCapacity);
        _ofiHistory = new RingBuffer<decimal>(historyCapacity);
        _stressHistory = new RingBuffer<decimal>(historyCapacity);

        if (!_timersSubscribed)
        {
            // Depth check: every 2 seconds
            SubscribeToTimer(TimeSpan.FromSeconds(2), CheckDepthChannel);
            // Full stress recalculation: every second.
            SubscribeToTimer(TimeSpan.FromSeconds(1), ComputeStressIndex);
            _timersSubscribed = true;
        }
    }

    protected override void OnRecalculate()
    {
        ResetSessionState();
    }

    protected override void OnCalculate(int bar, decimal value)
    {
        if (bar > 0 && IsNewSession(bar))
            ResetSessionState();

        // Live values are computed by the timer because every channel is sampled at 1 Hz.
        // Historical bars have no equivalent DOM/MBO stream and remain at their default value.
        _adaptThreshold[bar] = _useAdaptiveThreshold ? _adaptiveThreshold : _stressWarningLevel;
        _dataReadiness[bar] = _readyChannelCount;
        _confirmingChannels[bar] = _confirmingChannelCount;
    }

    protected override void OnDispose()
    {
        if (_timersSubscribed)
        {
            UnsubscribeFromTimer(TimeSpan.FromSeconds(2), CheckDepthChannel);
            UnsubscribeFromTimer(TimeSpan.FromSeconds(1), ComputeStressIndex);
            _timersSubscribed = false;
        }
    }

    // ---------------------------------------------------------
    //  Tick-level data collection
    // ---------------------------------------------------------

    protected override void OnNewTrade(MarketDataArg trade)
    {
        // Channel 2: inter-trade interval
        if (_lastTradeTime != DateTime.MinValue && _interTradeMs != null)
        {
            var interval = (trade.Time - _lastTradeTime).TotalMilliseconds;
            if (interval > 0)
            {
                _interTradeMs.Add(interval);
                _baselineInterTradeMs = _interTradeMs.Average(v => v);
            }
        }
        _lastTradeTime = trade.Time;
        _lastTradeReceipt = DateTime.Now;

        // Channel 4: order-flow imbalance accumulated over the 1 Hz sample.
        _ofiSum += trade.Direction == TradeDirection.Buy ? trade.Volume
                 : trade.Direction == TradeDirection.Sell ? -trade.Volume
                 : 0;
        _intervalTradeVolume += trade.Volume;
    }

    protected override void OnBestBidAskChanged(MarketDataArg depth)
    {
        if (depth.IsAsk)
        {
            _bestAskPrice = depth.Price;
            _lastAskMarketTime = depth.Time;
        }
        else if (depth.IsBid)
        {
            _bestBidPrice = depth.Price;
            _lastBidMarketTime = depth.Time;
        }

        var bboIsCoherent = _lastBidMarketTime != DateTime.MinValue &&
                            _lastAskMarketTime != DateTime.MinValue &&
                            Math.Abs((_lastAskMarketTime - _lastBidMarketTime).TotalMilliseconds) <= _bboPairMaxSkewMilliseconds;
        if (bboIsCoherent && _bestAskPrice > 0 && _bestBidPrice > 0 && _bestAskPrice >= _bestBidPrice)
        {
            _currentSpread = _bestAskPrice - _bestBidPrice;
            _lastBboReceipt = DateTime.Now;
        }

    }

    // ---------------------------------------------------------
    //  Channel Computations (timer-driven)
    // ---------------------------------------------------------

    private void CheckDepthChannel()
    {
        try
        {
            var snapshot = GetMarketDepthSnapshot();
            if (snapshot == null) return;

            var entries = snapshot.ToList();
            if (entries.Count == 0)
                return;

            var latestMarketTime = entries.Max(d => d.Time);
            if (latestMarketTime <= _lastDepthMarketTime)
                return;

            _lastDepthMarketTime = latestMarketTime;
            var bidEntries = entries.Where(depth => depth.IsBid).ToList();
            var askEntries = entries.Where(depth => depth.IsAsk).ToList();
            if (bidEntries.Count == 0 || askEntries.Count == 0)
                return;

            var tickSize = InstrumentInfo?.TickSize ?? 0.01m;
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
                _depthSamples = 1;
                return;
            }

            // Capture erosion against the prior baseline, then adapt it. This
            // prevents the sample that caused stress from muting its own score.
            _latestBidErosion = _baselineBidDepth > 0
                ? Math.Max(0m, 1m - _currentBidDepth / _baselineBidDepth)
                : 0m;
            _latestAskErosion = _baselineAskDepth > 0
                ? Math.Max(0m, 1m - _currentAskDepth / _baselineAskDepth)
                : 0m;

            // EMA update for future samples.
            var alpha = 2m / (_emaPeriod + 1m);
            _baselineBidDepth = alpha * _currentBidDepth + (1 - alpha) * _baselineBidDepth;
            _baselineAskDepth = alpha * _currentAskDepth + (1 - alpha) * _baselineAskDepth;
            _depthSamples++;
        }
        catch { /* silent */ }
    }

    private void ComputeStressIndex()
    {
        if (CurrentBar < 0) return;

        // --- Channel 1: Depth Erosion (0-100) ---
        var now = DateTime.Now;
        var depthReady = _depthSamples >= _minimumBaselineSamples && IsFresh(_lastDepthReceipt, now);
        var tradesReady = _interTradeMs?.Count >= _minimumBaselineSamples && IsFresh(_lastTradeReceipt, now);
        var spreadReady = _spreadHistory?.Count >= _minimumBaselineSamples && IsFresh(_lastBboReceipt, now);
        var ofiReady = _ofiHistory?.Count >= _minimumBaselineSamples && IsFresh(_lastTradeReceipt, now);
        _readyChannelCount = (depthReady ? 1 : 0) + (tradesReady ? 1 : 0) +
                             (spreadReady ? 1 : 0) + (ofiReady ? 1 : 0);

        var bidErosion = depthReady ? _latestBidErosion : 0m;
        var askErosion = depthReady ? _latestAskErosion : 0m;
        var depthChannel = Math.Max(bidErosion, askErosion) * 100m;  // MAX aggregation

        // --- Channel 2: Trade Clustering (0-100) ---
        // Clustering = inverse of normalized inter-trade time
        // Faster trades = higher clustering = more stress
        double clusterChannel = 0;
        if (tradesReady && _interTradeMs != null && _baselineInterTradeMs > 0)
        {
            var recentAvg = _interTradeMs.GetRecent(10).Average();
            clusterChannel = Math.Max(0, 100 * (1 - recentAvg / _baselineInterTradeMs));
        }

        // --- Channel 3: Spread Pressure (0-100) ---
        var spreadChannel = spreadReady && _baselineSpread > 0
            ? NormalizeRatio(_currentSpread / Math.Max(_baselineSpread, TickSize), _spreadStressRatio)
            : 0m;

        // --- Channel 4: OFI Volatility (0-100) ---
        var ofiChannel = 0m;
        if (ofiReady && _ofiHistory != null)
        {
            var baselineVolatility = StandardDeviation(_ofiHistory.GetRecent(_ofiHistory.Count));
            var currentSample = _intervalTradeVolume > 0m ? _ofiSum / _intervalTradeVolume : 0m;
            var recent = _ofiHistory.GetRecent(9).Append(currentSample);
            var shortTermVolatility = StandardDeviation(recent);
            if (baselineVolatility > 0m)
                ofiChannel = NormalizeRatio(shortTermVolatility / baselineVolatility, _ofiVolatilityRatio);
        }
        if (_intervalTradeVolume > 0m)
            _ofiHistory?.Add(_ofiSum / _intervalTradeVolume);
        _ofiSum = 0m;
        _intervalTradeVolume = 0m;

        if (IsFresh(_lastBboReceipt, now) && _currentSpread > 0m)
        {
            _spreadHistory?.Add(_currentSpread);
            _baselineSpread = _spreadHistory?.Average(value => value) ?? 0m;
        }

        _confirmingChannelCount = (depthReady && depthChannel >= _channelActivationScore ? 1 : 0) +
                                  (tradesReady && clusterChannel >= (double)_channelActivationScore ? 1 : 0) +
                                  (spreadReady && spreadChannel >= _channelActivationScore ? 1 : 0) +
                                  (ofiReady && ofiChannel >= _channelActivationScore ? 1 : 0);

        var rawIndex = Math.Max(
            Math.Max(depthChannel, (decimal)clusterChannel),
            Math.Max(spreadChannel, ofiChannel));
        if (_readyChannelCount >= 2)
        {
            // Learn the threshold from prior samples before appending this one.
            UpdateAdaptiveThreshold();
            var emaAlpha = 2m / (_emaPeriod + 1m);
            _emaStressIndex = emaAlpha * rawIndex + (1m - emaAlpha) * _emaStressIndex;
            _stressHistory?.Add(rawIndex);
        }

        // Readiness is not corroboration. A signal needs independent abnormal
        // evidence from the configured number of ready channels.
        if (_readyChannelCount < 2 || _confirmingChannelCount < _minimumConfirmingChannels)
        {
            _stressIndex[CurrentBar] = 0m;
            _depthErosion[CurrentBar] = depthChannel;
            _tradeClustering[CurrentBar] = (decimal)clusterChannel;
            _spreadPressure[CurrentBar] = spreadChannel;
            _adaptThreshold[CurrentBar] = _useAdaptiveThreshold ? _adaptiveThreshold : _stressWarningLevel;
            _dataReadiness[CurrentBar] = _readyChannelCount;
            _confirmingChannels[CurrentBar] = _confirmingChannelCount;
            return;
        }

        // Rising edge, smoothing, and threshold all use the same 1 Hz samples.
        if (rawIndex > _prevStressIndex + 0.5m)
            _risingEdgeCount++;
        else if (rawIndex < _prevStressIndex - 0.5m)
            _risingEdgeCount = 0;
        _prevStressIndex = rawIndex;

        // Rising-edge condition: only count if signal is rising
        var finalIndex = _risingEdgeCount >= _risingEdgeBars
            ? rawIndex  // confirmed uptrend → full signal
            : rawIndex * 0.7m;  // dampen if not rising

        var bar = CurrentBar;
        _stressIndex[bar] = finalIndex;
        _depthErosion[bar] = depthChannel;
        _tradeClustering[bar] = (decimal)clusterChannel;
        _spreadPressure[bar] = spreadChannel;
        _adaptThreshold[bar] = _useAdaptiveThreshold ? _adaptiveThreshold : _stressWarningLevel;
        _dataReadiness[bar] = _readyChannelCount;
        _confirmingChannels[bar] = _confirmingChannelCount;

        // --- Alerts ---
        if (_enableAlerts)
        {
            var threshold = _useAdaptiveThreshold ? _adaptiveThreshold : _stressWarningLevel;

            if (finalIndex > _stressCriticalLevel && !_criticalSent)
            {
                AddAlert("stress_critical", InstrumentInfo?.Instrument ?? "",
                    $"CRITICAL liquidity stress: {finalIndex:F0} | Depth={depthChannel:F0} | "
                    + $"Cluster={clusterChannel:F0} | Spread={spreadChannel:F0}",
                    System.Drawing.Color.Red, System.Drawing.Color.White);
                _criticalSent = true;
            }
            else if (finalIndex > threshold && !_warningSent && !_criticalSent)
            {
                AddAlert("stress_warning", InstrumentInfo?.Instrument ?? "",
                    $"Liquidity stress warning: {finalIndex:F0} (threshold: {threshold:F0})",
                    System.Drawing.Color.Orange, System.Drawing.Color.Black);
                _warningSent = true;
            }

            // Reset alert flags when stress drops
            if (finalIndex < _stressWarningLevel * 0.5m)
            {
                _warningSent = false;
                _criticalSent = false;
            }
        }
    }

    private void UpdateAdaptiveThreshold()
    {
        if (!_useAdaptiveThreshold || _stressHistory == null || _stressHistory.Count == 0)
        {
            _adaptiveThreshold = _stressWarningLevel;
            return;
        }

        var recent = _stressHistory.GetRecent(_emaPeriod).ToList();
        var average = recent.Average();
        var variance = recent.Sum(v => (v - average) * (v - average)) / recent.Count;
        var deviation = (decimal)Math.Sqrt((double)variance);
        _adaptiveThreshold = Math.Max(_stressWarningLevel, _emaStressIndex + 2m * deviation);
    }

    private bool IsFresh(DateTime lastReceipt, DateTime now) =>
        lastReceipt != DateTime.MinValue && (now - lastReceipt).TotalSeconds <= _dataStaleSeconds;

    private void ResetSessionState()
    {
        _baselineBidDepth = 0m;
        _baselineAskDepth = 0m;
        _currentBidDepth = 0m;
        _currentAskDepth = 0m;
        _depthSamples = 0;
        _latestBidErosion = 0m;
        _latestAskErosion = 0m;
        _lastDepthReceipt = DateTime.MinValue;
        _lastDepthMarketTime = DateTime.MinValue;
        _lastTradeTime = DateTime.MinValue;
        _lastTradeReceipt = DateTime.MinValue;
        _interTradeMs?.Clear();
        _baselineInterTradeMs = 0d;
        _bestBidPrice = 0m;
        _bestAskPrice = 0m;
        _lastBidMarketTime = DateTime.MinValue;
        _lastAskMarketTime = DateTime.MinValue;
        _currentSpread = 0m;
        _baselineSpread = 0m;
        _lastBboReceipt = DateTime.MinValue;
        _spreadHistory?.Clear();
        _ofiSum = 0m;
        _intervalTradeVolume = 0m;
        _ofiHistory?.Clear();
        _stressHistory?.Clear();
        _adaptiveThreshold = _stressWarningLevel;
        _emaStressIndex = 0m;
        _prevStressIndex = 0m;
        _risingEdgeCount = 0;
        _readyChannelCount = 0;
        _confirmingChannelCount = 0;
        _warningSent = false;
        _criticalSent = false;
    }

    // ---------------------------------------------------------
    //  Rendering
    // ---------------------------------------------------------

    protected override void OnRender(RenderContext context, DrawingLayouts layout)
    {
        if (layout != DrawingLayouts.Panel)
            return;

        // Background zone coloring
        // ponytail: simple text labels instead of filled zone rects
        var stress = _stressIndex[CurrentBar];

        string status;
        System.Drawing.Color statusColor;

        if (stress > _stressCriticalLevel)
        {
            status = "🔴 CRITICAL";
            statusColor = System.Drawing.Color.Red;
        }
        else if (stress > _stressWarningLevel)
        {
            status = "🟡 WARNING";
            statusColor = System.Drawing.Color.Orange;
        }
        else if (_risingEdgeCount >= _risingEdgeBars)
        {
            status = "🟠 RISING";
            statusColor = System.Drawing.Color.Orange;
        }
        else
        {
            status = "🟢 STABLE";
            statusColor = System.Drawing.Color.Green;
        }

        AddText("stress_status", $"LSI: {stress:F0} {status}", false,
            CurrentBar, 0, -30, 0,
            System.Drawing.Color.White, System.Drawing.Color.Black,
            statusColor, 12, DrawingText.TextAlign.Left);

        if (_showChannelBreakdown)
        {
            var channels = $"D:{_depthErosion[CurrentBar]:F0} "
                         + $"C:{_tradeClustering[CurrentBar]:F0} "
                         + $"S:{_spreadPressure[CurrentBar]:F0} "
                         + $"Ready:{_readyChannelCount}/4 "
                         + $"Confirm:{_confirmingChannelCount}/4";
            AddText("stress_channels", channels, false,
                CurrentBar, 0, -50, 0,
                System.Drawing.Color.Gray, System.Drawing.Color.Transparent,
                System.Drawing.Color.Transparent,
                9, DrawingText.TextAlign.Left);
        }
    }

    private static decimal NormalizeRatio(decimal ratio, decimal stressRatio)
    {
        if (stressRatio <= 1m)
            return 0m;

        return Math.Clamp((ratio - 1m) / (stressRatio - 1m) * 100m, 0m, 100m);
    }

    private static decimal StandardDeviation(IEnumerable<decimal> values)
    {
        var samples = values.ToList();
        if (samples.Count == 0)
            return 0m;

        var average = samples.Average();
        var variance = samples.Sum(value => (value - average) * (value - average)) / samples.Count;
        return (decimal)Math.Sqrt((double)variance);
    }
}
