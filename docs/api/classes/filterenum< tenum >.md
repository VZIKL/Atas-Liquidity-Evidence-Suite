# FilterEnum< TEnum >

**完整名称**: `ATAS.Indicators.FilterEnum< TEnum >`
**类型**: 类
**继承自**: `ATAS.Indicators.Filter< TEnum, FilterEnum< TEnum > >`

## 公共方法

  - ` FilterEnum(bool enabledVisible, bool asScalar=false)`
  - ` FilterEnum()`
  - `override string GetStringValue()`
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

## 属性

  - `Type EnumType { get; }`
  - `TValue Value { set; }`
    - Gets or sets the value of the filter.
  - `Type EnumType { get; }`
  - `bool Enabled { set; }`
    - Gets or sets a value indicating whether the filter is enabled.
  - `bool EnabledVisible { get; }`
    - Gets a value indicating whether the visibility of the "Enabled" property is visible to users.
  - `bool AsScalar { get; }`
    - Gets a value indicating whether the filter operates in scalar mode.
  - `static bool operator== `
  - `static bool operator!= `
  - `static operator TValue `
    - Converts the Filter<TValue, TFilter> to its value of type TValue .
  - `bool Equals `
  - `virtual ? TValue GetRealValue `
  - `virtual TValue ValueOnChanging `
    - Invoked when the value of the filter is changing.
  - `void RaiseValueOnChanged `
    - Raises the NotifyPropertyChangedBase.PropertyChanged event for the Value property and invokes the value changed action.
  - `virtual TFilter CreateNew `
    - Creates a new instance of the derived filter type.
