# Filter< TValue >

**完整名称**: `ATAS.Indicators.Filter< TValue >`
**类型**: 类
**继承自**: `ATAS.Indicators.Filter< TValue, Filter< TValue > >`

## 描述

Generic filter class that implements the IFilterValue interface. Represents a filter with a decimal value type. Inherits from Filter<TValue, TFilter> where TValue is set to decimal and TFilter is set to Filter. The filter's JSON serialization is handled by the custom converter FilterJsonConverter. Represents a filter with a specific value type TValue . Inherits from Filter<TValue, TFilter> where TFilter is set to Filter<TValue>. Template Parameters TValueThe type of the filter value. TFilterThe type of the derived filter. Template Parameters TValueThe type of value held by the filter.

## 公共方法

  - `override bool Equals(object? obj)`
  - `override int GetHashCode()`
  - `bool SetValueSilently(TValue value)`
    - Sets value of Value property. Returns false when new value equals new value.
  - ` Filter(bool enabledVisible, bool asScale=false)`
    - Initializes a new instance of the Filter<TValue, TFilter> class with the specified parameters.
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
  - ` Filter(bool enabledVisible, bool asScalar=false)`
    - Initializes a new instance of the Filter<TValue> class with the specified visibility of the Enabled property and scalar value.
  - ` Filter()`
    - Initializes a new instance of the Filter class with default visibility settings.
  - ` Filter(bool enableVisible, bool asScalar=false)`
    - Initializes a new instance of the Filter class with the specified visibility of the Enabled property and scalar value.
  - ` Filter()`
    - Initializes a new instance of the Filter class with default visibility settings.
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
  - `abstract object Clone()`
  - `string GetStringValue()`
    - Gets the string representation of value of the filter.
  - `static bool operator==(Filter< TValue, TFilter >? left, Filter< TValue, TFilter >? right)`
  - `static bool operator!=(Filter< TValue, TFilter >? left, Filter< TValue, TFilter >? right)`
  - `static operator TValue(Filter< TValue, TFilter > other)`
    - Converts the Filter<TValue, TFilter> to its value of type TValue .
  - `static bool operator==(Filter< TValue, TFilter >? left, Filter< TValue, TFilter >? right)`
  - `static bool operator!=(Filter< TValue, TFilter >? left, Filter< TValue, TFilter >? right)`
  - `static operator TValue(Filter< TValue, TFilter > other)`
    - Converts the Filter<TValue, TFilter> to its value of type TValue .

## 保护方法

  - `bool Equals(Filter< TValue, TFilter > other)`
  - `virtual ? TValue GetRealValue(TValue? value)`
  - `void RaiseValueOnChanged()`
    - Raises the NotifyPropertyChangedBase.PropertyChanged event for the Value property and invokes the value changed action.
  - `virtual TValue ValueOnChanging(TValue? oldValue, TValue? newValue)`
    - Invoked when the value of the filter is changing.
  - `virtual TFilter CreateNew()`
    - Creates a new instance of the derived filter type.
  - `bool Equals(Filter< TValue, TFilter > other)`
  - `virtual ? TValue GetRealValue(TValue? value)`
  - `virtual TValue ValueOnChanging(TValue? oldValue, TValue? newValue)`
    - Invoked when the value of the filter is changing.
  - `void RaiseValueOnChanged()`
    - Raises the NotifyPropertyChangedBase.PropertyChanged event for the Value property and invokes the value changed action.
  - `virtual TFilter CreateNew()`
    - Creates a new instance of the derived filter type.
  - ` FilterBase(bool enabledVisible, bool asScalar)`
    - Initializes a new instance of the FilterBase class with the specified parameters.
  - ` FilterBase()`
    - Initializes a new instance of the FilterBase class with default parameters.
  - `void RaisePropertyChanged([CallerMemberName] string? propertyName=null!)`
    - Raises the PropertyChanged event for the specified property name.
  - `void SetProperty< TProperty >(ref TProperty store, TProperty value, [CallerMemberName] string? propertyName=null, Action? onChanged=null)`

## 属性

  - `TValue Value { set; }`
    - Gets or sets the value of the filter.
  - `TValue Value { set; }`
    - Gets or sets the value of the filter.
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
  - `object Value { set; }`
    - Gets or sets the value of the filter. The value can hold data of any type.
  - `readonly bool _asScalar `
  - `PropertyChangedEventHandler? PropertyChanged `
    - Event that is raised when a property value changes.
