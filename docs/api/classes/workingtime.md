# WorkingTime

**完整名称**: `ATAS.DataFeedsCore.WorkingTime`
**类型**: 类
**继承自**: `ATAS.DataFeedsCore.IEntity`

## 公共方法

  - ` WorkingTime()`
  - `bool IsWorkingTime(DateTime time)`
  - `WorkingTime Clone()`
  - `override string ToString()`
    - Returns a string that represents the current object.

## 保护方法

  - `virtual void OnPropertyChanged(string propertyName)`

## 属性

  - `string Exchange { set; }`
  - `DayOfWeek StartDay { set; }`
  - `TimeSpan StartTime { set; }`
  - `DayOfWeek EndDay { set; }`
  - `TimeSpan EndTime { set; }`
  - `EntityType EntityType { get; }`
    - Gets the type of the entity.
  - `EntityType EntityType { get; }`
    - Gets the type of the entity.

## 事件

  - `event PropertyChangedEventHandler PropertyChanged`
