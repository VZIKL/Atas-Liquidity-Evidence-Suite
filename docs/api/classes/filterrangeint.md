# FilterRangeInt

**完整名称**: `ATAS.Indicators.FilterRangeInt`
**类型**: 类
**继承自**: `ATAS.Indicators.FilterRangeBase< int, FilterRangeInt >`

## 描述

Represents a filter that represents a range of integer values with custom JSON serialization/deserialization.

## 公共方法

  - ` FilterRangeInt(bool enabledVisible, bool asScale=false)`
    - Initializes a new instance of the FilterRangeInt class with the specified settings.
  - ` FilterRangeInt()`
    - Initializes a new instance of the FilterRangeInt class with default settings.
  - ` FilterRangeBase(bool enabledVisible, bool asScale=false)`
    - Initializes a new instance of the FilterRangeBase<TValue, TFilter> class with the specified settings.
  - ` FilterRangeBase()`
    - Initializes a new instance of the FilterRangeBase<TValue, TFilter> class with default settings.
  - `override FilterRangeValue< TValue > ValueOnChanging(FilterRangeValue< TValue >? oldValue, FilterRangeValue< TValue >? newValue)`
