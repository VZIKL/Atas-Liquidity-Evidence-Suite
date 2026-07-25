# BaseDataSeries< T >

**完整名称**: `ATAS.Indicators.BaseDataSeries< T >`
**类型**: 类
**继承自**: `ATAS.Indicators.IDataSeries< T >`

## 描述

Base generic data series class providing common functionality. Template Parameters TType of the data series.

## 公共方法

  - `virtual void Clear()`
    - Clears all elements from the data series.
  - `override string ToString()`
  - `void Clear()`
    - Clears all elements from the data series.

## 保护方法

  - `void RaiseChanged(int bar)`
  - `virtual void RaisePropertyChanged(string propertyName)`
  - `virtual void RaisePanelPropertyChanged(string propertyName)`
  - ` BaseDataSeries(string id, DataSeriesType type)`
  - ` BaseDataSeries(string id, string name, DataSeriesType type)`
  - ` BaseDataSeries(DataSeriesType type)`

## 属性

  - `bool DrawAbovePrice { set; }`
    - Gets or sets whether the data series should be drawn above candles of chart.
  - `bool IgnoredByAlerts { set; }`
    - Gets or sets a value indicating whether the data series should be ignored by alerts.
  - `string Id { set; }`
    - Gets or sets the unique and constant data series ID for data serialization.
  - `string RenderId { get; }`
    - Unique series id for all panels and indicators.
  - `virtual bool IsVisible { get; }`
    - Gets a value is should series drawn.
  - `DataSeriesType Type { get; }`
    - Gets the type of the data series from the enumeration.
  - `string Name { set; }`
    - Gets or sets the name of the data series.
  - `string DescriptionKey { set; }`
    - Get or sets the description of the data series.
  - `abstract int Count { get; }`
    - Gets the number of elements in the data series.
  - `abstract T this[int index] { set; }`
    - Gets or sets the element at the specified index.
  - `bool IsHidden { set; }`
    - Gets or sets a value indicating whether the data series properties should be hidden from the settings window.
  - `bool ShowTooltip { set; }`
    - Gets or sets a value indicating whether the data series tooltip should be shown.
  - `bool UseMinimizedModeIfEnabled { set; }`
    - Gets or sets a value indicating whether the minimized mode should be used if enabled.
  - `bool ResetAlertsOnNewBar { set; }`
    - Gets or sets a value indicating whether alerts should be reset on a new bar.
  - `bool ShowNameOnMouseOver { set; }`
    - Gets or sets a value indicating whether the name of the data series should be shown on mouseover.
  - `string Id { get; }`
    - Gets the unique and constant data series ID for data serialization.
  - `string RenderId { get; }`
    - Unique series id for all panels and indicators.
  - `DataSeriesType Type { get; }`
    - Gets the type of the data series from the enumeration.
  - `string Name { set; }`
    - Gets or sets the name of the data series.
  - `string DescriptionKey { set; }`
    - Get or sets the description of the data series.
  - `int Count { get; }`
    - Gets the number of elements in the data series.
  - `bool IsHidden { set; }`
    - Gets or sets a value indicating whether the data series properties should be hidden from the settings window.
  - `bool IsVisible { get; }`
    - Gets a value is should series drawn.
  - `bool DrawAbovePrice { set; }`
    - Gets or sets whether the data series should be drawn above candles of chart.
  - `bool UseMinimizedModeIfEnabled { set; }`
    - Gets or sets a value indicating whether the minimized mode should be used if enabled.
  - `bool IgnoredByAlerts { set; }`
    - Gets or sets a value indicating whether the data series should be ignored by alerts.
  - `bool ResetAlertsOnNewBar { set; }`
    - Gets or sets a value indicating whether alerts should be reset on a new bar.
  - `bool ShowTooltip { set; }`
    - Gets or sets a value indicating whether the data series tooltip should be shown.
  - `bool ShowNameOnMouseOver { set; }`
    - Gets or sets a value indicating whether the name of the data series should be shown on mouseover.
  - `object this[int index] { set; }`
  - `new T this[int index] { set; }`
    - Gets or sets the element at the specified index.

## 事件

  - `event Action< int >? Changed`
  - `event PropertyChangedEventHandler? PropertyChanged`
  - `event PropertyChangedEventHandler? PanelPropertyChanged`
  - `event Action< int > Changed`
    - Event raised when the data series is changed at a specific bar.
  - `event PropertyChangedEventHandler PanelPropertyChanged`
    - Occurs when a panel property value changes.
