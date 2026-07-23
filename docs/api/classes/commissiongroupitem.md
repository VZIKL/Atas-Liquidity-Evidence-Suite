# CommissionGroupItem

**完整名称**: `ATAS.DataFeedsCore.Commissions.CommissionGroupItem`
**类型**: 类

## 公共方法

  - `override string ToString()`
    - Returns a string that represents the current object.

## 保护方法

  - `virtual void OnPropertyChanged(string propertyName)`

## 属性

  - `long GroupId { set; }`
  - `string TypeName { set; }`
  - `string Settings { set; }`
  - `ICommissionRule Rule { set; }`

## 事件

  - `event PropertyChangedEventHandler PropertyChanged`
