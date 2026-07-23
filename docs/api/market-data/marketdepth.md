# MarketDepth

**完整名称**: `ATAS.DataFeedsCore.MarketDepth`
**类型**: 类
**继承自**: `ATAS.DataFeedsCore.IEntity`

## 描述

Represents a market depth entry.

## 公共方法

  - ` MarketDepth()`
    - Initializes a new instance of the MarketDepth class.
  - `IMarketDepth Clone()`
    - Creates a new instance of the IMarketDepth interface that is a copy of the current instance.ReturnsA new instance that is a copy of the current instance.
  - `override string ToString()`
    - Returns a string representation of the market depth entry.
  - `IMarketDepth Clone()`
    - Creates a new instance of the IMarketDepth interface that is a copy of the current instance.

## 属性

  - `EntityType EntityType { get; }`
    - Gets the entity type, which is EntityType.MarketDepth.
  - `string ECN { set; }`
    - Gets or sets the Electronic Communication Network (ECN) associated with the market depth entry.
  - `decimal Price { set; }`
    - Gets or sets the price of the market depth entry.
  - `decimal Volume { set; }`
    - Gets or sets the volume of the market depth entry.
  - `int OrdersCount { set; }`
    - Gets or sets the number of orders at the market depth entry.
  - `DateTime Time { set; }`
    - Gets or sets the date and time of the market depth entry.
  - `MarketDataType Type { set; }`
    - Gets or sets the market data type of the market depth entry.
  - `Security Security { set; }`
    - Gets or sets the security associated with the market depth entry.
  - `bool IsAsk { get; }`
    - Gets a value indicating whether the market depth entry represents an ask (sell) order.
  - `bool IsBid { get; }`
    - Gets a value indicating whether the market depth entry represents a bid (buy) order.
  - `EntityType EntityType { get; }`
    - Gets the type of the entity.
  - `DateTime Time { set; }`
    - Gets or sets the date and time of the market depth entry.
  - `int Type { set; }`
    - Gets or sets the type of the market depth entry. This property is used to distinguish different types of orders or market depth information.
  - `decimal Price { set; }`
    - Gets or sets the price of the market depth entry.
  - `decimal Volume { set; }`
    - Gets or sets the volume of the market depth entry.
  - `bool IsAsk { get; }`
    - Gets a value indicating whether the market depth entry represents an ask (sell) order.
  - `bool IsBid { get; }`
    - Gets a value indicating whether the market depth entry represents a bid (buy) order.
