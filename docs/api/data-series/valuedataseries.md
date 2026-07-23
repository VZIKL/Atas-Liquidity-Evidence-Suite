# ValueDataSeries

**完整名称**: `ATAS.Indicators.ValueDataSeries`
**类型**: 类
**继承自**: `ATAS.Indicators.BaseDataSeries< decimal >`

## 描述

Represents a data series of decimal values, each element is a decimal.

## 公共方法

  - `class BarColors()`
  - ` ValueDataSeries(string id, string name)`
    - Initializes a new instance of the ValueDataSeries class with the specified unique and constant data series ID for data serialization and unique name.
  - ` ValueDataSeries(string id)`
    - Initializes a new instance of the ValueDataSeries class with the specified unique and constant data series ID for data serialization.
  - `void SetPointOfEndLine(int bar)`
    - Sets the specified bar index as a point of end for a line in the value data series.
  - `void RemovePointOfEndLine(int bar)`
    - Removes the specified bar index as a point of end for a line in the value data series.
  - `bool IsThisPointOfStartBar(int bar)`
    - Checks if the specified bar index is a point of start for a line in the value data series.
  - `override void Clear()`
  - `decimal LastNonZeroValue(int bar)`
    - Gets the last non-zero value in the range from 0 to the specified bar.
  - `virtual void Clear()`

## 属性

  - `override string ToString `
  - `decimal ZeroValue { set; }`
    - Value of zero line for 'Histogram' mode.
  - `BarColors Colors { get; }`
    - Allows to change color per bar. Color value will be used for all bars by default.
  - `System.Drawing.Color RenderColor { set; }`
  - `int Digits { set; }`
    - Gets or sets the number of digits after the decimal point for formatting the value data series.
  - `string StringFormat { set; }`
    - Gets or sets the price string format for formatting the value data series.
  - `bool ShowOnlyNonZeroLabels { set; }`
    - Always draw last non-zero value on price axis.
  - `VisualMode VisualType { set; }`
    - Gets or sets the visual mode for drawing the value data series.
  - `CrossColor Color { set; }`
    - Gets or sets the color for drawing the value data series.
  - `System.Drawing.Color ValuesColor { set; }`
    - Gets or sets the values text color for the value data series.
  - `int Width { set; }`
    - Gets or sets the width for drawing the value data series.
  - `LineDashStyle LineDashStyle { set; }`
    - Gets or sets the line dash style for drawing the value data series.
  - `bool ShowZeroValue { set; }`
    - Gets or sets whether to show zero value on price axis for the value data series.
  - `bool ShowCurrentValue { set; }`
    - Gets or sets whether to show the current value on the price panel for the value data series.
  - `bool ScaleIt { set; }`
    - Gets or sets whether to use scaling for the value data series.
  - `override int Count { get; }`
  - `override bool IsVisible { get; }`
  - `override decimal this[int index] { set; }`
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
