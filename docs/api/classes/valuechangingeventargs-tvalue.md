# ValueChangingEventArgs< TValue >

**完整名称**: `ATAS.Indicators.ValueChangingEventArgs< TValue >`
**类型**: 类

## 描述

Provides event arguments for a value changing event. Template Parameters TValueThe type of the value.

## 公共方法

  - ` ValueChangingEventArgs(TValue oldValue, TValue newValue)`
    - Initializes a new instance of the ValueChangingEventArgs<TValue> class with the specified old and new values.

## 属性

  - `TValue OldValue { get; }`
    - Gets the old value before the change.
  - `TValue NewValue { get; }`
    - Gets the new value after the change.
