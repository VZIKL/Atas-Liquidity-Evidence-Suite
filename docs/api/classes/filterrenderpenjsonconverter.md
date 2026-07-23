# FilterRenderPenJsonConverter

**完整名称**: `ATAS.Indicators.Filters.Converters.FilterRenderPenJsonConverter`
**类型**: 类
**继承自**: `ATAS.Indicators.Filters.Converters.FilterJsonConverterBase< FilterRenderPen, PenSettings >`

## 保护方法

  - `override FilterRenderPen Create(bool enabledVisible, bool enabled)`
  - `override void WriteValue(JsonWriter writer, PenSettings value)`
  - `override FilterRenderPen ReadFromObject(JsonReader reader, FilterRenderPen? filter)`
  - `override? PenSettings ReadValue(JsonReader reader)`
  - `abstract TFilter Create(bool enabledVisible, bool enabled)`
  - `TFilter CreateFromValue(TFilter? filter, TValue? value)`
  - `virtual TFilter ReadFromObject(JsonReader reader, TFilter? filter)`
  - `virtual ? TValue ReadValue(JsonReader reader)`
  - `virtual ? object CreateStoredValue(TValue value)`
  - `virtual void WriteValue(JsonWriter writer, TValue value)`

## 属性

  - `string ColorPropertyName { get; }`
  - `string LineStylePropertyName { get; }`
  - `string WidthPropertyName { get; }`
  - `string ValuePropertyName { get; }`
  - `string EnabledPropertyName { get; }`
  - `string EnabledVisiblePropertyName { get; }`
  - `override void WriteJson `
  - `override? object ReadJson `
  - `override bool CanConvert `
