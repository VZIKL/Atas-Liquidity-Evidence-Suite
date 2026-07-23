# PortfolioState

**完整名称**: `ATAS.DataFeedsCore.PortfolioState`
**类型**: 类
**继承自**: `ATAS.DataFeedsCore.IEntity`

## 公共方法

  - ` PortfolioState()`

## 属性

  - `long Id { set; }`
  - `string AccountId { set; }`
  - `DateTime Date { set; }`
  - `decimal Balance { set; }`
  - `decimal UnrealizedPnL { set; }`
  - `string CommissionState { set; }`
  - `List< PositionState > Positions { set; }`
  - `EntityType EntityType { get; }`
    - Gets the type of the entity.
  - `EntityType EntityType { get; }`
    - Gets the type of the entity.
