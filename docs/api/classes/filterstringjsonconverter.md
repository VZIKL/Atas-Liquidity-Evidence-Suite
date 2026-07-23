# FilterStringJsonConverter

**完整名称**: `ATAS.Indicators.Filters.Converters.FilterStringJsonConverter`
**类型**: 类
**继承自**: `ATAS.Indicators.Filters.Converters.FilterJsonConverterBase< FilterString, string >`

## 保护方法

  - `override FilterString Create(bool enabledVisible, bool enabled)`
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
