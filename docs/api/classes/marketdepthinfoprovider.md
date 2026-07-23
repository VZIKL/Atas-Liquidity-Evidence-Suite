# MarketDepthInfoProvider

**完整名称**: `ATAS.Indicators.MarketDepthInfoProvider`
**类型**: 类
**继承自**: `ATAS.Indicators.IMarketDepthInfoProvider`

## 描述

A class that implements the IMarketDepthInfoProvider interface to provide market depth information.

## 公共方法

  - ` MarketDepthInfoProvider(IOnlineDataProvider onlineDataProvider)`
    - Initializes a new instance of the MarketDepthInfoProvider class.
  - `IEnumerable< MarketDataArg > GetMarketDepthSnapshot()`
    - Gets a snapshot of the market depth data at the moment of request.ReturnsAn enumerable collection of MarketDataArg representing the market depth.
  - `IEnumerable< MarketDataArg > GetMarketDepthSnapshot()`
    - Gets a snapshot of the market depth data at the moment of request.

## 属性

  - `decimal CumulativeDomAsks { get; }`
    - Gets the cumulative sum of the ask volumes in the DOM (Depth of Market).
  - `decimal CumulativeDomBids { get; }`
    - Gets the cumulative sum of the bid volumes in the DOM (Depth of Market).
  - `decimal CumulativeDomAsks { get; }`
    - Gets the cumulative sum of the ask volumes in the DOM (Depth of Market).
  - `decimal CumulativeDomBids { get; }`
    - Gets the cumulative sum of the bid volumes in the DOM (Depth of Market).
