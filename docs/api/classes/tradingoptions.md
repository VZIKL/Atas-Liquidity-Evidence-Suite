# TradingOptions

**完整名称**: `ATAS.DataFeedsCore.TradingOptions`
**类型**: 类
**继承自**: `ATAS.DataFeedsCore.IEntity`

## 公共方法

  - ` TradingOptions()`
  - `override string ToString()`
    - Returns a string that represents the current object.

## 保护方法

  - `virtual void OnPropertyChanged(string propertyName)`

## 属性

  - `long Id { set; }`
  - `long? CommissionId { set; }`
  - `CommissionGroup Commission { set; }`
  - `TimeSpan ResetPnlTime { set; }`
  - `SecurityRouteCache SecurityRoutes { get; }`
  - `TimeSpan SessionBeginTime { set; }`
  - `TimeSpan SessionEndTime { set; }`
  - `decimal Leverage { set; }`
  - `decimal IntradayLeverage { set; }`
  - `bool IsIsolatedMargin { set; }`
  - `List< string > AvailableSecurities { set; }`
  - `bool OvernightPositions { set; }`
  - `int MaxPositions { set; }`
  - `int MaxPositionSize { set; }`
  - `int MaxTotalPositionSize { set; }`
  - `int MaxOpenOrders { set; }`
  - `int MaxOrderSize { set; }`
  - `decimal BlockBalance { set; }`
  - `decimal MaxDrawdown { set; }`
  - `bool SuspendOnDrawdown { set; }`
  - `decimal MaxUnrealizedPnL { set; }`
  - `decimal TrailingDrawdown { set; }`
  - `bool ApplyOvernightSwap { set; }`
  - `bool StopEvaluationOnMaxTotalPositionSize { set; }`
  - `EntityType EntityType { get; }`
    - Gets the type of the entity.
  - `EntityType EntityType { get; }`
    - Gets the type of the entity.

## 事件

  - `event PropertyChangedEventHandler PropertyChanged`
