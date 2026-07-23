# Order

**完整名称**: `ATAS.DataFeedsCore.Order`
**类型**: 类
**继承自**: `ATAS.DataFeedsCore.IEntity`

## 描述

Represents an order for trading on a financial exchange.

## 公共方法

  - `Order Clone()`
    - Creates a shallow copy of the current order.
  - `override string ToString()`
    - Returns a string that represents the current order.

## 保护方法

  - `void OnPropertyChanged(string name)`
    - Raises the PropertyChanged event with the specified property name.

## 属性

  - `EntityType EntityType { get; }`
    - Gets the type of the entity.
  - `string? Id { set; }`
    - Gets or sets the ID of the order on the exchange.
  - `long ExtId { set; }`
    - Gets or sets the additional identifier for the order.
  - `long UserExtId { set; }`
    - Gets or sets the user's identifier associated with the order.
  - `string? AccountID { set; }`
    - Gets or sets the ID of the account associated with this order.
  - `string? RoutedAccountId { set; }`
    - Gets or sets the routed account ID for this order.
  - `string? SecurityId { set; }`
    - Gets or sets the ID of the security associated with this order.
  - `Security? Security { set; }`
    - Gets or sets the security associated with this order.
  - `Portfolio? Portfolio { set; }`
    - Gets or sets the portfolio associated with this order.
  - `OrderTypes Type { set; }`
    - Gets or sets the type of the order.
  - `OrderDirections Direction { set; }`
    - Gets or sets the direction of the order.
  - `decimal TriggerPrice { set; }`
    - Gets or sets the trigger price of the order.
  - `decimal Price { set; }`
    - Gets or sets the price of the order.
  - `decimal QuantityToFill { set; }`
    - Gets or sets the volume (quantity) to be filled for the order.
  - `decimal Unfilled { set; }`
    - Gets the remaining unfilled volume of the order.
  - `DateTime? ExpiryDate { set; }`
    - Gets or sets the expiry date of the order.
  - `TimeInForce TimeInForce { set; }`
    - Gets or sets the time in force for the order.
  - `string? Route { set; }`
    - Gets or sets the routing information for the order.
  - `string? OCOGroup { set; }`
    - Gets or sets the OCO (One-Cancels-the-Other) group for the order.
  - `string? Comment { set; }`
    - Gets or sets the comment for the order.
  - `DateTime Time { set; }`
    - Gets or sets the timestamp of when the order was created or modified.
  - `OrderStates State { set; }`
    - Gets or sets the current state of the order.
  - `TriggerPriceType TriggerPriceType { set; }`
    - Gets or sets the type of trigger price associated with the order.
  - `object? Parent { set; }`
    - Gets or sets the parent object associated with this order.
  - `bool IsInPosition { set; }`
    - Gets or sets a value indicating whether the order is in a position.
  - `bool WasActive { set; }`
    - Gets or sets a value indicating whether the order was active.
  - `bool Canceled { get; }`
    - Gets a value indicating whether the order is canceled.
  - `decimal AmountBefore { set; }`
    - Gets or sets the amount before the order.
  - `bool? IsAttached { set; }`
    - Gets or sets a value indicating whether the order is attached to another order.
  - `OrderExtendedOptions? ExtendedOptions { set; }`
    - Allows setting special options for the order. Use ISecurityTradingOptions.CreateMarketOrderFlagsObject and similar methods obtained by calling the IDataFeedConnector.GetSecurityTradingOptions method to get the object that you can populate and pass here.
  - `int? ExtendedOptionsFlags { set; }`
    - Gets or sets the flags representation of the ExtendedOptions.
  - `decimal? QuoteVolume { set; }`
    - Gets or sets the quote volume associated with the order.
  - `TimeSpan Latency { set; }`
    - Returns the time spent between sending the order to the server and receiving a response about it's registration or cancellation.
  - `bool AutoCancel { set; }`
    - Gets or sets a value indicating whether the order must be cancelled on position closed or reverted.
  - `EntityType EntityType { get; }`
    - Gets the type of the entity.

## 事件

  - `event PropertyChangedEventHandler? PropertyChanged`
