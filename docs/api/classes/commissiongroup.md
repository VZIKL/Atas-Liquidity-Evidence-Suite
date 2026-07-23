# CommissionGroup

**完整名称**: `ATAS.DataFeedsCore.Commissions.CommissionGroup`
**类型**: 类
**继承自**: `ATAS.DataFeedsCore.IEntity`

## 公共方法

  - ` CommissionGroup()`
  - `override string ToString()`
    - Returns a string that represents the current object.

## 保护方法

  - `virtual void OnPropertyChanged(string propertyName)`

## 属性

  - `long Id { set; }`
  - `long GroupId { set; }`
  - `string Name { set; }`
  - `List< CommissionGroupItem > Rules { set; }`
  - `EntityType EntityType { get; }`
    - Gets the type of the entity.
  - `EntityType EntityType { get; }`
    - Gets the type of the entity.

## 事件

  - `event PropertyChangedEventHandler PropertyChanged`
