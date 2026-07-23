# MyTrade

**完整名称**: `ATAS.DataFeedsCore.MyTrade`
**类型**: 类
**继承自**: `ATAS.DataFeedsCore.IEntity`

## 描述

Represents a trade entity in the system.

## 公共方法

  - `override string ToString()`
  - `string Display()`
  - `MyTrade Clone()`

## 保护方法

  - `void OnPropertyChanged(string name)`
    - Notifies subscribers that a property value has changed.

## 属性

  - `EntityType EntityType { get; }`
  - `string Route { set; }`
    - Gets or sets the route associated with the trade.
  - `string AccountID { set; }`
    - Gets or sets the account ID associated with the trade.
  - `string SecurityId { set; }`
    - Gets or sets the security ID associated with the trade.
  - `string Id { set; }`
    - Gets or sets the unique ID of the trade.
  - `string OrderId { set; }`
    - Gets or sets the ID of the order associated with the trade.
  - `OrderDirections OrderDirection { set; }`
    - Gets or sets the direction of the order (Buy or Sell) associated with the trade.
  - `decimal Price { set; }`
    - Gets or sets the price at which the trade was executed.
  - `DateTime Time { set; }`
    - Gets or sets the timestamp of the trade.
  - `decimal Volume { set; }`
    - Gets or sets the volume of the trade.
  - `decimal OpenVolume { set; }`
    - Gets or sets the open volume of the trade.
  - `Order Order { set; }`
    - Gets or sets the order associated with the trade.
  - `Security Security { set; }`
    - Gets or sets the security associated with the trade.
  - `Portfolio Portfolio { set; }`
    - Gets or sets the portfolio associated with the trade.
  - `object Parent { set; }`
    - Gets or sets the parent object associated with the trade.
  - `decimal? Commission { set; }`
    - Gets or sets the commission amount of the trade.
  - `string? CommissionCurrency { set; }`
    - Gets or sets the currency of the commission for the trade.
  - `bool? IsMaker { set; }`
    - Gets or sets whether the trade is a maker trade.
  - `bool IsNew { set; }`
    - Gets or sets a flag indicating whether the trade is new.
  - `EntityType EntityType { get; }`
    - Gets the type of the entity.

## 事件

  - `event PropertyChangedEventHandler PropertyChanged`
