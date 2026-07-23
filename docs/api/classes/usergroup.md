# UserGroup

**完整名称**: `ATAS.DataFeedsCore.UserGroup`
**类型**: 类
**继承自**: `ATAS.DataFeedsCore.IEntity`

## 公共方法

  - ` UserGroup()`
  - `override string ToString()`
    - Returns a string that represents the current object.

## 保护方法

  - `virtual void OnPropertyChanged(string propertyName)`

## 属性

  - `long Id { set; }`
  - `string Code { set; }`
  - `int LastPortfolioNumber { set; }`
  - `string Name { set; }`
  - `string Description { set; }`
  - `bool AllowLogonWithWrongPassword { set; }`
  - `TimeSpan? DefaultExpiration { set; }`
  - `string? StatisticsServerUrl { set; }`
  - `long? ParentId { set; }`
  - `UserGroup Parent { set; }`
  - `List< Exchange > Exchanges { set; }`
  - `long? TradingOptionsId { set; }`
  - `TradingOptions TradingOptions { set; }`
  - `EntityType EntityType { get; }`
    - Gets the type of the entity.
  - `EntityType EntityType { get; }`
    - Gets the type of the entity.

## 事件

  - `event PropertyChangedEventHandler PropertyChanged`
