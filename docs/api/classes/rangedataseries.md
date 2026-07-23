# RangeDataSeries

**完整名称**: `ATAS.Indicators.RangeDataSeries`
**类型**: 类
**继承自**: `ATAS.Indicators.BaseDataSeries< RangeValue >`

## 描述

Represents a data series of range values, each element is a RangeValue.

## 公共方法

  - ` RangeDataSeries(string id, string name)`
    - Initializes a new instance of the RangeDataSeries class with the specified unique and constant data series ID for data serialization and unique name.
  - ` RangeDataSeries(string id)`
    - Initializes a new instance of the RangeDataSeries class with the specified unique and constant data series ID for data serialization.
  - `override void Clear()`
  - `virtual void Clear()`
  - `override string ToString()`

## 属性

  - `override bool IsVisible { get; }`
  - `System.Drawing.Color RenderColor { set; }`
  - `CrossColor RangeColor { set; }`
    - Gets or sets the color of the range data series.
  - `bool ScaleIt { set; }`
    - Gets or sets whether to scale the data series on the chart.
  - `bool Visible { set; }`
    - Gets or sets the visibility of the range data series.
  - `override int Count { get; }`
  - `override RangeValue this[int index] { set; }`
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
