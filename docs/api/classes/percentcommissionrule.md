# PercentCommissionRule

**完整名称**: `ATAS.DataFeedsCore.Commissions.PercentCommissionRule`
**类型**: 类
**继承自**: `ATAS.DataFeedsCore.Commissions.CommissionRule`

## 公共方法

  - `override decimal Process(MyTrade trade)`
  - `virtual decimal Process(Order order)`
  - `virtual decimal Process(MyTrade trade)`
  - `virtual void Load(string value)`
  - `virtual string Save()`
  - `override string ToString()`
    - Returns a string that represents the current object.
  - `decimal Process(Order order)`
  - `decimal Process(MyTrade trade)`
  - `void Load(string value)`
  - `string Save()`

## 属性

  - `decimal Percent { set; }`
  - `bool NeedSave { set; }`
  - `string Name { set; }`
  - `bool NeedSave { get; }`
  - `string Name { set; }`
  - ` CommissionRule `
  - `virtual void OnPropertyChanged `
  - `PropertyChangedEventHandler PropertyChanged `
