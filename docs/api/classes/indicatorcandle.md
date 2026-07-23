# IndicatorCandle

**完整名称**: `ATAS.Indicators.IndicatorCandle`
**类型**: 类
**继承自**: `ATAS.Indicators.ISupportedPriceInfo`

## 描述

Represents an Indicator Candle.

## 公共方法

  - ` IndicatorCandle(ISupportedPriceInfo dataprovider, IIntCandle parentCandle, decimal tickSize)`
    - Constructor for the IndicatorCandle class.
  - `IEnumerable< PriceVolumeInfo > GetAllPriceLevels()`
    - Gets all available price levels with associated volume information.ReturnsAn enumerable collection of PriceVolumeInfo objects representing all price levels.
  - `IEnumerable< PriceVolumeInfo > GetAllPriceLevels(PriceVolumeInfo cacheItem)`
    - Gets all available price levels with associated volume information and caches the data of the last element in the specified cacheItem.Parameters cacheItemA PriceVolumeInfo object to caching. ReturnsAn enumerable collection of PriceVolumeInfo objects representing all price levels.
  - `PriceVolumeInfo GetPriceVolumeInfo(decimal price)`
    - Gets the PriceVolumeInfo object associated with the specified price.Parameters priceThe price for which the PriceVolumeInfo object is to be retrieved. ReturnsThe PriceVolumeInfo object representing the specified price.
  - `PriceVolumeInfo GetPriceVolumeInfo(decimal price, PriceVolumeInfo cacheItem)`
    - Gets the PriceVolumeInfo object associated with the specified price.Parameters priceThe price for which the PriceVolumeInfo object is to be retrieved. cacheItemA PriceVolumeInfo object to caching. ReturnsThe PriceVolumeInfo object representing the specified price.
  - `IEnumerable< PriceVolumeInfo > GetAllPriceLevels()`
    - Gets all available price levels with associated volume information.
  - `IEnumerable< PriceVolumeInfo > GetAllPriceLevels(PriceVolumeInfo cacheItem)`
    - Gets all available price levels with associated volume information and caches the data of the last element in the specified cacheItem.
  - `PriceVolumeInfo GetPriceVolumeInfo(decimal price)`
    - Gets the PriceVolumeInfo object associated with the specified price.
  - `PriceVolumeInfo GetPriceVolumeInfo(decimal price, PriceVolumeInfo cacheItem)`
    - Gets the PriceVolumeInfo object associated with the specified price.

## 属性

  - `decimal Open { get; }`
    - The opening price of the candle.
  - `decimal High { get; }`
    - The highest price in the candle.
  - `decimal Low { get; }`
    - The lowest price in the candle.
  - `decimal Close { get; }`
    - The closing price of the candle.
  - `decimal Volume { get; }`
    - The total number of traded lots in the candle.
  - `decimal Bid { get; }`
    - The number of traded lots at the best bid price in the candle.
  - `decimal Ask { get; }`
    - The number of traded lots at the best offer price in the candle.
  - `decimal Betweens { get; }`
    - The number of traded lots at the price between bids and asks in the candle.
  - `decimal Ticks { get; }`
    - The number of price changes in the candle.
  - `decimal Delta { get; }`
    - The difference between the number of buys and the number of sales in the candle.
  - `DateTime Time { get; }`
    - Candle opening time.
  - `DateTime LastTime { get; }`
    - The time when the last trade in the candle occurred.
  - `decimal MaxDelta { get; }`
    - The maximum value of the delta that was during the period of the candle.
  - `decimal MinDelta { get; }`
    - The minimum value of the delta that was during the period of the candle.
  - `decimal MaxOI { get; }`
    - The maximum value of open positions that was during the period of the candle.
  - `decimal MinOI { get; }`
    - The minimum value of open positions that was during the period of the candle.
  - `decimal OI { get; }`
    - The number of open positions in the candle.
  - `decimal VWAP { get; }`
    - Volume-weighted average price of the candle.
  - `PriceVolumeInfo MaxVolumePriceInfo { get; }`
    - Gets the PriceVolumeInfo object with the maximum volume.
  - `PriceVolumeInfo MaxTickPriceInfo { get; }`
    - Gets the PriceVolumeInfo object with the maximum tick count.
  - `PriceVolumeInfo MaxAskPriceInfo { get; }`
    - Gets the PriceVolumeInfo object with the maximum ask price.
  - `PriceVolumeInfo MaxBidPriceInfo { get; }`
    - Gets the PriceVolumeInfo object with the maximum bid price.
  - `PriceVolumeInfo MaxTimePriceInfo { get; }`
    - Gets the PriceVolumeInfo object with the maximum time.
  - `PriceVolumeInfo MaxPositiveDeltaPriceInfo { get; }`
    - Gets the PriceVolumeInfo object with the maximum positive delta.
  - `PriceVolumeInfo MaxNegativeDeltaPriceInfo { get; }`
    - Gets the PriceVolumeInfo object with the maximum negative delta.
  - `ValueArea ValueArea { get; }`
    - Gets the ValueArea object which represents value are of candle.
  - `PriceVolumeInfo MaxVolumePriceInfo { get; }`
    - Gets the PriceVolumeInfo object with the maximum volume.
  - `PriceVolumeInfo MaxTickPriceInfo { get; }`
    - Gets the PriceVolumeInfo object with the maximum tick count.
  - `PriceVolumeInfo MaxAskPriceInfo { get; }`
    - Gets the PriceVolumeInfo object with the maximum ask price.
  - `PriceVolumeInfo MaxBidPriceInfo { get; }`
    - Gets the PriceVolumeInfo object with the maximum bid price.
  - `PriceVolumeInfo MaxTimePriceInfo { get; }`
    - Gets the PriceVolumeInfo object with the maximum time.
  - `PriceVolumeInfo MaxPositiveDeltaPriceInfo { get; }`
    - Gets the PriceVolumeInfo object with the maximum positive delta.
  - `PriceVolumeInfo MaxNegativeDeltaPriceInfo { get; }`
    - Gets the PriceVolumeInfo object with the maximum negative delta.
  - `ValueArea ValueArea { get; }`
    - Gets the ValueArea object which represents value are of candle.
