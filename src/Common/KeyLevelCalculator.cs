using ATAS.Indicators;

namespace ATAS.CustomIndicators;

/// <summary>
/// Detects key price levels: swing highs/lows, round numbers, high-volume nodes.
/// Used by StopCascadeDetector to identify where stop-loss orders cluster.
/// </summary>
public class KeyLevelCalculator
{
    private readonly int _swingLookback;
    private readonly decimal _tickSize;
    private readonly decimal _roundIncrement;

    public KeyLevelCalculator(int swingLookback = 20, decimal tickSize = 0.01m, decimal roundIncrement = 1.00m)
    {
        _swingLookback = swingLookback;
        _tickSize = tickSize;
        _roundIncrement = roundIncrement;
    }

    /// <summary>
    /// Returns only swing levels that become knowable when <paramref name="bar"/>
    /// closes. A swing at bar - lookback is confirmed with no future candles.
    /// </summary>
    public IEnumerable<decimal> ConfirmedLevelsAt(Indicator indicator, int bar)
    {
        var candidateBar = bar - _swingLookback;
        if (candidateBar < _swingLookback)
            return Enumerable.Empty<decimal>();

        var candle = indicator.GetCandle(candidateBar);
        var levels = new List<decimal>(2);
        if (IsSwingHigh(indicator, candidateBar))
            levels.Add(RoundToTick(candle.High));
        if (IsSwingLow(indicator, candidateBar))
            levels.Add(RoundToTick(candle.Low));
        return levels;
    }

    /// <summary>
    /// Returns nearby round-number levels without deriving them from future bars.
    /// </summary>
    public IEnumerable<decimal> RoundLevelsAround(decimal price, int steps = 1)
    {
        if (_roundIncrement <= 0)
            return Enumerable.Empty<decimal>();

        var center = Math.Round(price / _roundIncrement) * _roundIncrement;
        return Enumerable.Range(-steps, steps * 2 + 1)
            .Select(offset => center + offset * _roundIncrement)
            .Where(level => level > 0)
            .Select(RoundToTick)
            .Distinct();
    }

    /// <summary>
    /// Live-mode: check if a price is near any key level.
    /// </summary>
    public bool IsNearLevel(decimal price, IEnumerable<decimal> levels, decimal thresholdPercent = 0.1m)
    {
        return levels.Any(l => l != 0m &&
            Math.Abs(price - l) / Math.Abs(l) * 100m <= thresholdPercent);
    }

    /// <summary>
    /// Get nearest key level below/above a price.
    /// </summary>
    public decimal? NearestLevelBelow(decimal price, IEnumerable<decimal> levels)
    {
        var below = levels.Where(l => l < price);
        return below.Any() ? below.Max() : null;
    }

    public decimal? NearestLevelAbove(decimal price, IEnumerable<decimal> levels)
    {
        var above = levels.Where(l => l > price);
        return above.Any() ? above.Min() : null;
    }

    private bool IsSwingHigh(Indicator indicator, int bar)
    {
        var candle = indicator.GetCandle(bar);
        for (int i = bar - _swingLookback; i <= bar + _swingLookback; i++)
        {
            if (i == bar) continue;
            if (indicator.GetCandle(i).High >= candle.High)
                return false;
        }
        return true;
    }

    private bool IsSwingLow(Indicator indicator, int bar)
    {
        var candle = indicator.GetCandle(bar);
        for (int i = bar - _swingLookback; i <= bar + _swingLookback; i++)
        {
            if (i == bar) continue;
            if (indicator.GetCandle(i).Low <= candle.Low)
                return false;
        }
        return true;
    }

    private decimal RoundToTick(decimal price) =>
        Math.Round(price / _tickSize) * _tickSize;

}
