# NotifyPropertyChangedBase

**完整名称**: `ATAS.Indicators.NotifyPropertyChangedBase`
**类型**: 类

## 描述

Base class for implementing the INotifyPropertyChanged interface.

## 保护方法

  - `void RaisePropertyChanged([CallerMemberName] string? propertyName=null!)`
    - Raises the PropertyChanged event for the specified property name.
  - `void SetProperty< TProperty >(ref TProperty store, TProperty value, [CallerMemberName] string? propertyName=null, Action? onChanged=null)`

## 事件

  - `event PropertyChangedEventHandler? PropertyChanged`
    - Event that is raised when a property value changes.
