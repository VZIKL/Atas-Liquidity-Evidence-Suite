# SecurityTradingOptions

**完整名称**: `ATAS.DataFeedsCore.SecurityTradingOptions`
**类型**: 类
**继承自**: `ATAS.DataFeedsCore.ISecurityTradingOptions`

## 描述

Each connector may have different order placement settings like TimeInForce or ReduceOnly etc. This class shows connector configuration.

## 公共方法

  - `OrderExtendedOptions? CreateMarketOrderFlagsObject()`
    - Returns an object containing all possible options for creating a market order, to be passed as Order.ExtendedOptions.
  - `OrderExtendedOptions? CreateLimitOrderFlagsObject()`
    - Returns an object containing all possible options for creating a limit order, to be passed as Order.ExtendedOptions.
  - `OrderExtendedOptions? CreateConditionalMarketOrderFlagsObject()`
    - Returns an object containing all possible options for creating a conditional market (stop) order, to be passed as Order.ExtendedOptions.
  - `OrderExtendedOptions? CreateConditionalLimitOrderFlagsObject()`
    - Returns an object containing all possible options for creating a conditional limit (stop) order, to be passed as Order.ExtendedOptions.
  - `OrderExtendedOptions? CreateMarketOrderFlagsObject()`
    - Gets an object of all possible marker order options passed as Order.ExtendedOptions.
  - `OrderExtendedOptions? CreateLimitOrderFlagsObject()`
    - Gets an object of all possible limit order options passed as Order.ExtendedOptions.
  - `OrderExtendedOptions? CreateConditionalMarketOrderFlagsObject()`
    - Gets an object of all possible conditional market (stop) order options passed as Order.ExtendedOptions.
  - `OrderExtendedOptions? CreateConditionalLimitOrderFlagsObject()`
    - Gets an object of all possible conditional limit (stop) order options passed as Order.ExtendedOptions.

## 属性

  - `TimeInForce TimeInForce { get; }`
    - Gets or sets the available TimeInForce values supported by the connector when opening an order.
  - `TriggerPriceType TriggerPriceTypes { get; }`
    - Gets or sets the available TriggerPriceTypes when opening a conditional order by the connector.
  - `TimeInForce TimeInForce { get; }`
    - Gets a value which contains all possible TimeInForce values supported by the connector when opening an order.
  - `TriggerPriceType TriggerPriceTypes { get; }`
    - Gets a value which contains all possible TriggerPriceTypes when opening a conditional order by the connector.
