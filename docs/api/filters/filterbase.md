# FilterBase

**完整名称**: `ATAS.Indicators.FilterBase`
**类型**: 类
**继承自**: `ATAS.Indicators.NotifyPropertyChangedBase`

## 描述

Base class for filters implementing the IFilter interface.

## 公共方法

  - `abstract object Clone()`

## 保护方法

  - ` FilterBase(bool enabledVisible, bool asScalar)`
    - Initializes a new instance of the FilterBase class with the specified parameters.
  - ` FilterBase()`
    - Initializes a new instance of the FilterBase class with default parameters.
  - `void RaisePropertyChanged([CallerMemberName] string? propertyName=null!)`
    - Raises the PropertyChanged event for the specified property name.
  - `void SetProperty< TProperty >(ref TProperty store, TProperty value, [CallerMemberName] string? propertyName=null, Action? onChanged=null)`
  - `readonly bool _asScalar()`

## 属性

  - `bool Enabled { set; }`
    - Gets or sets a value indicating whether the filter is enabled.
  - `bool EnabledVisible { get; }`
    - Gets a value indicating whether the visibility of the "Enabled" property is visible to users.
  - `bool Enabled { set; }`
    - Gets or sets a value indicating whether the filter is enabled.
  - `bool EnabledVisible { get; }`
    - Gets a value indicating whether the visibility of the "Enabled" property is visible to users.
  - `bool AsScalar { get; }`
    - Gets a value indicating whether the filter operates in scalar mode.
  - `PropertyChangedEventHandler? PropertyChanged `
    - Event that is raised when a property value changes.
