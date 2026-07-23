# IndicatorSeries

**完整名称**: `ATAS.Indicators.IndicatorSeries`
**类型**: 类
**继承自**: `ATAS.Indicators.BaseDataSeries< decimal >`

## 描述

Represents a custom data series for an indicator, derived from BaseDataSeries<decimal>.

## 公共方法

  - ` IndicatorSeries(Indicator indicator, int seriesId)`
    - Constructor to create an IndicatorSeries object for the specified indicator and series ID.
  - `virtual void Clear()`
  - `override string ToString()`

## 属性

  - `Indicator Indicator { get; }`
    - Gets the associated indicator.
  - `int SeriesId { get; }`
    - Gets the ID of the series within the indicator.
  - `override int Count { get; }`
    - Gets the count of data points in the series.
  - `override decimal this[int index] { set; }`
    - Gets the data value at the specified index in the IndicatorSeries.
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
