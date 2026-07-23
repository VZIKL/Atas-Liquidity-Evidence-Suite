# FilterJsonConverterBase< TFilter, TValue >

**完整名称**: `ATAS.Indicators.Filters.Converters.FilterJsonConverterBase< TFilter, TValue >`
**类型**: 类

## 公共方法

  - `override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)`
  - `override? object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)`
  - `override bool CanConvert(Type objectType)`

## 保护方法

  - `abstract TFilter Create(bool enabledVisible, bool enabled)`
  - `TFilter CreateFromValue(TFilter? filter, TValue? value)`
  - `virtual TFilter ReadFromObject(JsonReader reader, TFilter? filter)`
  - `virtual ? TValue ReadValue(JsonReader reader)`
  - `virtual ? object CreateStoredValue(TValue value)`
  - `virtual void WriteValue(JsonWriter writer, TValue value)`

## 属性

  - `string ValuePropertyName { get; }`
  - `string EnabledPropertyName { get; }`
  - `string EnabledVisiblePropertyName { get; }`
