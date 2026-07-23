# MarketByOrder

**完整名称**: `ATAS.DataFeedsCore.MarketByOrder`
**类型**: 类
**继承自**: `ATAS.DataFeedsCore.IEntity`

## 描述

Market by Order (MBO) describes an order-based data feed that provides the ability to view individual queue position, full depth of book and the size of individual orders at each price level.

## 公共方法

  - `override string ToString()`

## 属性

  - `Security? Security { set; }`
    - Gets or sets the security associated with the market by order entry.
  - `DateTime Time { set; }`
    - Gets or sets the date and time of the market by order entry.
  - `MarketByOrderUpdateTypes Type { set; }`
    - Type of market by order update.
  - `MarketDataType Side { set; }`
    - Side of the order.
  - `long Priority { set; }`
    - Priority of this order in the exchange's matching engine queue.
  - `long ExchangeOrderId { set; }`
    - Exchange order id of this order.
  - `decimal Price { set; }`
    - Price associated with this order.
  - `decimal Volume { set; }`
    - Volume associated with this order.
  - `EntityType EntityType { get; }`
    - Gets the type of the entity.
