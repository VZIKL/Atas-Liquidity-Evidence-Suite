# TrackedPropertyBase

**完整名称**: `ATAS.Indicators.Filters.TrackedPropertyBase`
**类型**: 类

## 描述

A base class for tracking property changes and notifying subscribers when a property value is modified.

## 保护方法

  - `void SetProperty< TProperty >(ref TProperty store, TProperty value, Action? onChanged=null, Func< TProperty, bool >? onChanging=null, [CallerMemberName] string propertyName="")`
    - Sets the value of a property and notifies subscribers if the value has changed.
  - `void SetTrackedProperty< TProperty >(ref TProperty store, TProperty value, Action< string >? onChanged=null, [CallerMemberName] string propertyName="")`
    - Sets the value of a property that implements the INotifyPropertyChanged interface and notifies subscribers if the value has changed.
  - `virtual void OnChangeProperty([CallerMemberName] string propertyName="")`
    - Notifies subscribers when a property value changes.

## 事件

  - `event PropertyChangedEventHandler? PropertyChanged`
