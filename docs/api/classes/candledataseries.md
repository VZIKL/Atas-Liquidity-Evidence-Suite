# CandleDataSeries

**完整名称**: `ATAS.Indicators.CandleDataSeries`
**类型**: 类
**继承自**: `ATAS.Indicators.BaseDataSeries< Candle >`

## 描述

Represents a data series of candles. Each element in the series is a Candle.

## 公共方法

  - ` CandleDataSeries(string id, string name)`
    - Initializes a new instance of the CandleDataSeries class with the specified unique and constant data series ID for data serialization and unique name.
  - ` CandleDataSeries(string id)`
    - Initializes a new instance of the CandleDataSeries class with the specified unique and constant data series ID for data serialization.
  - `override void Clear()`
  - `virtual void Clear()`
  - `override string ToString()`

## 属性

  - `int Digits { set; }`
    - Gets or sets the number of digits after the decimal point.
  - `string StringFormat { set; }`
    - Gets or sets the price string format used for displaying values.
  - `bool HideZeroCandles { set; }`
    - Gets or sets whether to show current values on the price panel.
  - `bool HideOpenCloseLabels { set; }`
    - Gets or sets which point of the candle is used as the tooltip anchor.
  - `CandleTooltipAnchor TooltipAnchor { set; }`
  - `bool ShowCurrentValue { set; }`
  - `CrossColor UpCandleColor { set; }`
    - Gets or sets the color of the data series element on a bullish (up) candle.
  - `CrossColor DownCandleColor { set; }`
    - Gets or sets the color of the data series element on a bearish (down) candle.
  - `CrossColor BorderColor { set; }`
    - Gets or sets the color of the data series element border.
  - `System.Drawing.Color ValuesColor { set; }`
    - Gets or sets the color of the values text.
  - `bool Visible { set; }`
    - Gets or sets whether the data series is visible on the chart.
  - `bool ScaleIt { set; }`
    - Gets or sets whether to scale the data series on the chart.
  - `CandleVisualMode Mode { set; }`
    - Gets or sets the visualization mode of the data series.
  - `bool DrawCandleBorder { set; }`
    - Gets or sets whether to draw candle border.
  - `override bool IsVisible { get; }`
  - `override int Count { get; }`
  - `override Candle this[int index] { set; }`
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
