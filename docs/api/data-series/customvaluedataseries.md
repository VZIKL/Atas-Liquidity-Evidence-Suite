# CustomValueDataSeries

**完整名称**: `ATAS.Indicators.CustomValueDataSeries`
**类型**: 类
**继承自**: `ATAS.Indicators.BaseDataSeries< CustomValue >`

## 描述

Represents a custom data series that holds CustomValue objects.

## 公共方法

  - ` CustomValueDataSeries(string id, string name)`
    - Initializes a new instance of the CustomValueDataSeries class with the specified unique and constant data series ID for data serialization and unique name.
  - ` CustomValueDataSeries(string id)`
    - Initializes a new instance of the CustomValueDataSeries class with the specified identifier.
  - `override void Clear()`
  - `virtual void Clear()`
  - `override string ToString()`

## 属性

  - `bool ScaleIt { set; }`
    - Gets or sets a value indicating whether the data series should be scaled.
  - `override int Count { get; }`
  - `override CustomValue this[int index] { set; }`
    - Gets or sets the CustomValue object at the specified bar index.
  - `bool DrawAbovePrice { set; }`
  - `bool IgnoredByAlerts { set; }`
  - `string Id { set; }`
    - Gets or sets the unique and constant data series ID for data serialization.
  - `string RenderId { get; }`
    - Unique series id for all panels and indicators.
  - `virtual bool IsVisible { get; }`
    - Gets a value is should series drawn.
  - `DataSeriesType Type { get; }`
  - `string Name { set; }`
  - `string DescriptionKey { set; }`
  - `abstract int Count { get; }`
  - `abstract T this[int index] { set; }`
    - Gets or sets the element at the specified index.
  - `bool IsHidden { set; }`
  - `bool ShowTooltip { set; }`
  - `bool UseMinimizedModeIfEnabled { set; }`
  - `bool ResetAlertsOnNewBar { set; }`
  - `bool ShowNameOnMouseOver { set; }`
  - `void RaiseChanged `
  - `virtual void RaisePropertyChanged `
  - `virtual void RaisePanelPropertyChanged `
  - ` BaseDataSeries `
  - ` BaseDataSeries `
  - ` BaseDataSeries `
  - `Action< int >? Changed `
  - `PropertyChangedEventHandler? PropertyChanged `
  - `PropertyChangedEventHandler? PanelPropertyChanged `
