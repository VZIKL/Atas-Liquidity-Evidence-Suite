# LineSeries

**完整名称**: `ATAS.Indicators.LineSeries`
**类型**: 类
**继承自**: `ATAS.Indicators.BaseDataSeries< decimal >`

## 描述

Represents a horizontal line with a single value.

## 公共方法

  - ` LineSeries(string id, string name)`
    - Initializes a new instance of the LineSeries class with the specified unique and constant data series ID for data serialization and unique name.
  - ` LineSeries(string id)`
    - Initializes a new instance of the LineSeries class with the specified unique and constant data series ID for data serialization.
  - `virtual void Clear()`
  - `override string ToString()`

## 属性

  - `CrossColor Color { set; }`
    - Color of the line.
  - `LineDashStyle LineDashStyle { set; }`
    - Style of the line.
  - `int Width { set; }`
    - Width of the line.
  - `bool UseScale { set; }`
    - Indicates whether to use scale.
  - `decimal Value { set; }`
    - Value of the line.
  - `string Text { set; }`
    - Text associated with the line.
  - `override int Count { get; }`
    - Gets the number of elements in the series (always int.MaxValue).
  - `override decimal this[int index] { set; }`
    - Gets or sets the value at the specified index (always returns the current Value and throws NotSupportedException for setting).
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
