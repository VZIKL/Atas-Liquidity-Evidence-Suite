# PriceSelectionDataSeries

**完整名称**: `ATAS.Indicators.PriceSelectionDataSeries`
**类型**: 类
**继承自**: `ATAS.Indicators.BaseDataSeries< SyncList< PriceSelectionValue > >`

## 描述

Represents a data series of price selection values, each element is a synchronized list of PriceSelectionValue.

## 公共方法

  - ` PriceSelectionDataSeries(string id, string name)`
    - Initializes a new instance of the PriceSelectionDataSeries class with the specified unique and constant data series ID for data serialization and unique name.
  - ` PriceSelectionDataSeries(string id)`
    - Initializes a new instance of the PriceSelectionDataSeries class with the specified unique and constant data series ID for data serialization.
  - `override void Clear()`
  - `virtual void Clear()`
  - `override string ToString()`

## 属性

  - `override bool IsVisible { get; }`
  - `bool Visible { set; }`
    - Gets or sets the visibility of the price selection data series.
  - `override int Count { get; }`
  - `override SyncList< PriceSelectionValue > this[int index] { set; }`
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
