# CandlePartSeries

**完整名称**: `ATAS.Indicators.CandlePartSeries`
**类型**: 类
**继承自**: `ATAS.Indicators.BaseDataSeries< decimal >`

## 描述

Represents a data series of decimal values derived from specific parts of an IndicatorCandle created by an ICandleCreator.

## 公共方法

  - ` CandlePartSeries(ICandleCreator candleCreator, DataSeriesType type)`
    - Initializes a new instance of the CandlePartSeries class.
  - `IndicatorCandle GetCandle(int bar)`
    - Gets the IndicatorCandle at the specified bar index.
  - `virtual void Clear()`
  - `override string ToString()`

## 属性

  - `override int Count { get; }`
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
  - `PropertyChangedEventHandler? PanelPropertyChanged `
