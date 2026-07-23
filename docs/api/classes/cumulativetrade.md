# CumulativeTrade

**完整名称**: `ATAS.Indicators.CumulativeTrade`
**类型**: 类

## 描述

Represents a cumulative trade, which is a trade that includes multiple prints or executions.

## 公共方法

  - `override string ToString()`
    - Returns a string representation of the CumulativeTrade object.

## 属性

  - `decimal FirstPrice { set; }`
    - Gets or sets the first price of the trade.
  - `decimal Lastprice { set; }`
    - Gets or sets the last price of the trade.
  - `decimal Volume { set; }`
    - Gets or sets the cumulative volume of the trade.
  - `DateTime Time { set; }`
    - Gets or sets the time of the trade.
  - `TradeDirection Direction { set; }`
    - Gets or sets the trade direction (Buy or Sell).
  - `List< MarketDataArg > Ticks { set; }`
    - Gets or sets the list of individual ticks (MarketDataArg) included in the cumulative trade.
  - `MarketDataArg PreviousAsk { set; }`
    - Gets or sets the best ask before the trade.
  - `MarketDataArg PreviousBid { set; }`
    - Gets or sets the best bid before the trade.
  - `MarketDataArg NewAsk { set; }`
    - Gets or sets the best ask after the trade.
  - `MarketDataArg NewBid { set; }`
    - Gets or sets the best bid after the trade.
