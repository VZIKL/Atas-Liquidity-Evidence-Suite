# FilterRangeJsonConverterBase< TFilter, TValue >

**完整名称**: `ATAS.Indicators.Filters.Converters.FilterRangeJsonConverterBase< TFilter, TValue >`
**类型**: 类
**继承自**: `ATAS.Indicators.Filters.Converters.FilterJsonConverterBase< TFilter, FilterRangeValue< TValue > >`

## 保护方法

  - `override TFilter ReadFromObject(JsonReader reader, TFilter? filter)`
  - `abstract TFilter Create(bool enabledVisible, bool enabled)`
  - `TFilter CreateFromValue(TFilter? filter, TValue? value)`
  - `virtual TFilter ReadFromObject(JsonReader reader, TFilter? filter)`
  - `virtual ? TValue ReadValue(JsonReader reader)`
  - `virtual ? object CreateStoredValue(TValue value)`
  - `virtual void WriteValue(JsonWriter writer, TValue value)`
  - `override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)`
  - `override? object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)`
  - `override bool CanConvert(Type objectType)`
  - `string ValuePropertyName()`
  - `string EnabledPropertyName()`
  - `string EnabledVisiblePropertyName()`
