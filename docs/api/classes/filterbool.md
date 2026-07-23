# FilterBool

**完整名称**: `ATAS.Indicators.FilterBool`
**类型**: 类
**继承自**: `ATAS.Indicators.Filter< bool, FilterBool >`

## 描述

Represents a filter with a boolean value type. Inherits from Filter<TValue, TFilter> where TValue is set to bool and TFilter is set to FilterBool.

## 公共方法

  - ` FilterBool(bool enableVisible, bool asScalar=false)`
    - Initializes a new instance of the FilterBool class with the specified visibility of the FilterBase.Enabled property and scalar value.
  - ` FilterBool()`
    - Initializes a new instance of the FilterBool class with default visibility settings.
  - `override bool Equals(object? obj)`
  - `override int GetHashCode()`
  - `bool SetValueSilently(TValue value)`
    - Sets value of Value property. Returns false when new value equals new value.
  - ` Filter(bool enabledVisible, bool asScale=false)`
    - Initializes a new instance of the Filter<TValue, TFilter> class with the specified parameters.
  - ` Filter()`
    - Initializes a new instance of the Filter class with default visibility settings.
  - ` Filter(bool enabledVisible, bool asScalar=false)`
    - Initializes a new instance of the Filter<TValue> class with the specified visibility of the Enabled property and scalar value.
  - ` Filter()`
    - Initializes a new instance of the Filter class with default visibility settings.
  - ` Filter(bool enableVisible, bool asScalar=false)`
    - Initializes a new instance of the Filter class with the specified visibility of the Enabled property and scalar value.
  - ` Filter()`
    - Initializes a new instance of the Filter class with default visibility settings.
  - `TFilter ValueOnChanging(Func< ValueChangingEventArgs< TValue >, TValue > onChanging)`
    - Sets a function to be invoked when the value of the filter is changing.
  - `TFilter ValueOnChanged(Action< TValue > onChanged)`
    - Sets an action to be invoked when the value of the filter has changed.
  - `override string ToString()`
    - Converts the filter to its string representation.
  - `virtual string GetStringValue()`
  - `override object Clone()`
  - `static bool operator==(Filter< TValue, TFilter >? left, Filter< TValue, TFilter >? right)`
  - `static bool operator!=(Filter< TValue, TFilter >? left, Filter< TValue, TFilter >? right)`
  - `static operator TValue(Filter< TValue, TFilter > other)`
    - Converts the Filter<TValue, TFilter> to its value of type TValue .
  - `bool Equals(Filter< TValue, TFilter > other)`
  - `virtual ? TValue GetRealValue(TValue? value)`
  - `virtual TValue ValueOnChanging(TValue? oldValue, TValue? newValue)`
    - Invoked when the value of the filter is changing.
  - `void RaiseValueOnChanged()`
    - Raises the NotifyPropertyChangedBase.PropertyChanged event for the Value property and invokes the value changed action.
  - `virtual TFilter CreateNew()`
    - Creates a new instance of the derived filter type.
  - `TValue Value()`
    - Gets or sets the value of the filter.
