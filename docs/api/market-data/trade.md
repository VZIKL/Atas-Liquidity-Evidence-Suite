# Trade

**完整名称**: `ATAS.DataFeedsCore.Trade`
**类型**: 类
**继承自**: `ATAS.DataFeedsCore.IEntity`

## 描述

Represents an tick on a financial exchange.

## 公共方法

  - ` Trade()`
    - Initializes a new instance of the Trade class.
  - `override string ToString()`

## 属性

  - `EntityType EntityType { get; }`
    - Gets the type of the entity.
  - `long Id { set; }`
    - Gets or sets the id of the trade.
  - `TradeDirection OrderDirection { set; }`
    - Gets or sets the side of the trade.
  - `decimal Price { set; }`
    - Gets or sets the price associated with this trade.
  - `Security Security { set; }`
    - Gets or sets the security associated with the trade entry.
  - `DateTime Time { set; }`
    - Gets or sets the date and time of the trade entry.
  - `decimal Volume { set; }`
    - Gets or sets the volume associated with this trade.
  - `decimal OpenInterest { set; }`
    - Gets or sets the open interest associated with this trade.
  - `string ECN { set; }`
    - Gets or sets the Electronic Communication Network (ECN) associated with the trade entry.
  - `long? AggressorExchangeOrderId { set; }`
    - Gets or sets the aggressor exchange order id (see the MarketByOrder.ExchangeOrderId property) associated with this trade.
  - `long? ExchangeOrderId { set; }`
    - Gets or sets the exchange order id (see the MarketByOrder.ExchangeOrderId property) associated with this trade.
  - `EntityType EntityType { get; }`
    - Gets the type of the entity.
