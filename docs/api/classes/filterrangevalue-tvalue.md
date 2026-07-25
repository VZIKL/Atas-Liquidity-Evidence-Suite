# FilterRangeValue< TValue >

**完整名称**: `ATAS.Indicators.FilterRangeValue< TValue >`
**类型**: 类
**继承自**: `ATAS.Indicators.NotifyPropertyChangedBase`

## 描述

Represents a range of values of type TValue with support for property change notifications. Template Parameters TValueThe type of values the range can hold.

## 属性

  - `TValue? Start { set; }`
    - Gets or sets the start value of the range.
  - `TValue? End { set; }`
    - Gets or sets the end value of the range.
  - `void RaisePropertyChanged `
    - Raises the PropertyChanged event for the specified property name.
  - `void SetProperty< TProperty > `
  - `PropertyChangedEventHandler? PropertyChanged `
    - Event that is raised when a property value changes.
