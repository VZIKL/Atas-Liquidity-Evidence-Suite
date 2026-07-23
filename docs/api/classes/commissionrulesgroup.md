# CommissionRulesGroup

**完整名称**: `ATAS.DataFeedsCore.Commissions.CommissionRulesGroup`
**类型**: 类

## 公共方法

  - ` CommissionRulesGroup(Portfolio portfolio)`
  - `void Init(CommissionGroup group)`
  - `decimal Process(Order order)`
  - `decimal Process(MyTrade trade)`
  - `void SaveState()`

## 属性

  - `Portfolio Portfolio { get; }`
  - `CommissionGroup Commission { get; }`
