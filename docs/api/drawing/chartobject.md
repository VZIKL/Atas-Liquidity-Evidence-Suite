# ChartObject

**完整名称**: `ATAS.Indicators.ChartObject`
**类型**: 类
**继承自**: `ATAS.Indicators.Filters.TrackedPropertyBase`

## 描述

Base class for objects in a chart.

## 公共方法

  - `virtual bool ProcessMouseClick(RenderControlMouseEventArgs e)`
    - Processes a mouse click event on the chart object.
  - `virtual bool ProcessMouseWheel(int delta)`
    - Processes a mouse wheel event on the chart object.
  - `virtual bool ProcessMouseDown(RenderControlMouseEventArgs e)`
    - Processes a mouse down event on the chart object.
  - `virtual bool ProcessMouseUp(RenderControlMouseEventArgs e)`
    - Processes a mouse up event on the chart object.
  - `virtual bool ProcessMouseMove(RenderControlMouseEventArgs e)`
    - Processes a mouse move event on the chart object.
  - `virtual bool ProcessMouseDoubleClick(RenderControlMouseEventArgs e)`
    - Processes a mouse double click event on the chart object.
  - `virtual StdCursor GetCursor(RenderControlMouseEventArgs e)`
    - Gets the cursor to display when the mouse is over the chart object.
  - `virtual bool ProcessKeyDown(CrossKeyEventArgs e)`
    - Processes a key down event on the chart object.
  - `virtual bool ProcessKeyUp(CrossKeyEventArgs e)`
    - Processes a key up event on the chart object.

## 保护方法

  - `virtual void OnVisibleChanged()`
    - Called when the Visible property changes.
  - `virtual void LockedOnChanged()`
    - Called when the Locked property changes.
  - `void SetProperty< TProperty >(ref TProperty store, TProperty value, Action? onChanged=null, Func< TProperty, bool >? onChanging=null, [CallerMemberName] string propertyName="")`
    - Sets the value of a property and notifies subscribers if the value has changed.
  - `void SetTrackedProperty< TProperty >(ref TProperty store, TProperty value, Action< string >? onChanged=null, [CallerMemberName] string propertyName="")`
    - Sets the value of a property that implements the INotifyPropertyChanged interface and notifies subscribers if the value has changed.
  - `virtual void OnChangeProperty([CallerMemberName] string propertyName="")`
    - Notifies subscribers when a property value changes.

## 属性

  - `bool Visible { set; }`
    - Gets or sets a value indicating whether the chart object is visible.
  - `bool Locked { set; }`
    - Gets or sets a value indicating whether the chart object is locked.
  - `bool AllowedInteraction { get; }`
    - Gets a value indicating whether interaction with the chart object is allowed.
  - `PropertyChangedEventHandler? PropertyChanged `
