# MarketDataArg

**完整名称**: `ATAS.Indicators.MarketDataArg`
**类型**: 类
**继承自**: `ATAS.DataFeedsCore.IEntity`

## 描述

Represents a data point in the market.

## 公共方法

  - ` MarketDataArg()`
    - Initializes a new instance of the MarketDataArg class.

## 属性

  - `decimal Price { set; }`
    - Price of the market data.
  - `decimal OriginPrice { set; }`
    - Original, not scaled price of the market data.
  - `decimal Volume { set; }`
    - Volume associated with the market data.
  - `DateTime Time { set; }`
    - Time at which the market data occurred.
  - `TradeDirection Direction { set; }`
    - Trade direction of the market data (Buy, Sell, or Between).
  - `MarketDataType DataType { set; }`
    - Type of the market data (Bid, Ask, or Trade).
  - `decimal OpenInterest { set; }`
    - Open interest associated with the market data.
  - `bool IsAsk { get; }`
    - Gets a value indicating whether the market data is of type Ask.
  - `bool IsBid { get; }`
    - Gets a value indicating whether the market data is of type Bid.
  - `long? AggressorExchangeOrderId { set; }`
    - Gets or sets the aggressor exchange order id (see the MarketByOrder.ExchangeOrderId property) associated with this trade.
  - `long? ExchangeOrderId { set; }`
    - Gets or sets the exchange order id (see the MarketByOrder.ExchangeOrderId property) associated with this trade.
  - `EntityType EntityType { get; }`
    - Gets the type of the entity.
