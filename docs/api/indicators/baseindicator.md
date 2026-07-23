# BaseIndicator

**完整名称**: `ATAS.Indicators.BaseIndicator`
**类型**: 类
**继承自**: `ATAS.Indicators.ChartObject`

## 描述

Base class for custom indicators in a chart.

## 公共方法

  - `virtual void Dispose()`
  - `override string ToString()`
    - Converts the current instance of the indicator to its string representation.
  - `virtual bool ProcessMouseClick(RenderControlMouseEventArgs e)`
    - Processes a mouse click event on the chart object.
  - `virtual bool ProcessMouseWheel(int delta)`
    - Processes a mouse wheel event on the chart object.
  - `virtual bool ProcessMouseDown(RenderControlMouseEventArgs e)`
    - Processes a mouse down event on the chart object.
  - `virtual bool ProcessMouseUp(RenderControlMouseEventArgs e)`
    - Processes a mouse up event on the chart object.
  - `virtual bool ProcessMouseMove(RenderControlMouseEventArgs e)`
    - Processes a mouse move event on the chart object.
  - `virtual bool ProcessMouseDoubleClick(RenderControlMouseEventArgs e)`
    - Processes a mouse double click event on the chart object.
  - `virtual StdCursor GetCursor(RenderControlMouseEventArgs e)`
    - Gets the cursor to display when the mouse is over the chart object.
  - `virtual bool ProcessKeyDown(CrossKeyEventArgs e)`
    - Processes a key down event on the chart object.
  - `virtual bool ProcessKeyUp(CrossKeyEventArgs e)`
    - Processes a key up event on the chart object.

## 保护方法

  - ` BaseIndicator(bool useCandles=false)`
  - `virtual void RecalculateValues()`
    - Recalculate the indicator values on each bar.
  - `virtual void OnInitialize()`
    - The method is executed before the first calculation.
  - `virtual void OnRecalculate()`
    - The method is executed before a new calculation.
  - `virtual void OnFinishRecalculate()`
    - The method is executed after the end of the calculation.
  - `virtual void Calculate(int bar, decimal value)`
    - Performs the calculation for the indicator at the specified bar and value.
  - `abstract void OnCalculate(int bar, decimal value)`
    - The main indicator calculation method is called for each bar on the history, then it is called on each tick.
  - `void Add(Indicator indicator)`
    - Adds an indicator to the list of used indicators by this indicator.
  - `void Clear()`
    - Clear all data series.
  - `virtual void OnSourceChanged()`
    - This method is called when the SourceDataSeries property is changed.
  - `virtual void OnPropertiesEditorChanged(IPropertiesEditor? oldValue, IPropertiesEditor? newValue)`
    - Called when the PropertiesEditor property changes.
  - `void RaisePropertyChanged(string propertyName)`
    - Raises the PropertyChanged event for the specified property name.
  - `void RaisePropertyChanged(object? sender, PropertyChangedEventArgs e)`
    - Raises the PropertyChanged event with the specified event arguments.
  - `void RaisePanelPropertyChanged(string name)`
    - Raises the PanelPropertyChanged event with the specified property name.
  - `void RaiseBarValueChanged(int bar)`
    - Raises the BarValueChanged event with the specified bar value.
  - `virtual void OnDispose()`
    - Called when the indicator is being disposed.
  - `override void OnVisibleChanged()`
    - Called when the Visible property changes.
  - `virtual void OnVisibleChanged()`
    - Called when the Visible property changes.
  - `virtual void LockedOnChanged()`
    - Called when the Locked property changes.
  - `void SetProperty< TProperty >(ref TProperty store, TProperty value, Action? onChanged=null, Func< TProperty, bool >? onChanging=null, [CallerMemberName] string propertyName="")`
    - Sets the value of a property and notifies subscribers if the value has changed.
  - `void SetTrackedProperty< TProperty >(ref TProperty store, TProperty value, Action< string >? onChanged=null, [CallerMemberName] string propertyName="")`
    - Sets the value of a property that implements the INotifyPropertyChanged interface and notifies subscribers if the value has changed.
  - `virtual void OnChangeProperty([CallerMemberName] string propertyName="")`
    - Notifies subscribers when a property value changes.
  - `static PerfCounter MeasurePerformance(string name)`
    - Measures the performance of a specific operation with the given name. If a performance diagnoser is available, it will be used to measure the performance; otherwise, a default performance counter will be returned.
  - `readonly List< Indicator > UsedIndicators()`
    - The list of indicators that are being used by this indicator.

## 属性

  - `static ? PerformanceDiagnoser PerformanceDiagnoser { get; }`
    - Indicator performance tracker.
  - `static bool UseProfiling { set; }`
    - Set to true to measure the performance of all indicators.
  - `IPropertiesEditor? PropertiesEditor { set; }`
  - `string Name { set; }`
    - Name of the indicator.
  - `bool IsDisposed { set; }`
    - Gets or sets a value indicating whether the indicator object has been disposed of.
  - `List< IDataSeries > DataSeries { get; }`
    - List of data series used by the indicator.
  - `bool SupportsExtendedSeries { get; }`
    - Gets value indicating whether the data series can be drawn out of chart bars.
  - `List< LineSeries > LineSeries { get; }`
    - List of line series used by the indicator.
  - `string Panel { set; }`
    - The name of the panel where the indicator is placed.
  - `bool IsVerticalIndicator { set; }`
    - Gets or sets a value indicating whether the indicator is intended to be displayed as a vertical indicator.
  - `bool UseCandles { get; }`
    - Gets a value indicating whether the indicator uses candle data series.
  - `int CurrentBar { get; }`
    - Bars number. All bars and the values of the corresponding data series have a serial number. The earliest bar of the chart is assigned the number 0; the next bar is assigned the number 1, and so on.
  - `IDataSeries< decimal >? SourceDataSeries { set; }`
    - Gets or sets the data series used as the source for the indicator's calculations.
  - `decimal this[int index] { set; }`
    - Gets or sets the value of the first data series of the indicator at the specified index.
  - `bool Visible { set; }`
    - Gets or sets a value indicating whether the chart object is visible.
  - `bool Locked { set; }`
    - Gets or sets a value indicating whether the chart object is locked.
  - `bool AllowedInteraction { get; }`
    - Gets a value indicating whether interaction with the chart object is allowed.
  - `IPropertiesEditor? PropertiesEditor { set; }`

## 事件

  - `event new? PropertyChangedEventHandler PropertyChanged`
  - `event PropertyChangedEventHandler? PanelPropertyChanged`
  - `event Action< int >? BarValueChanged`
    - Event that is raised when the value of a bar in the indicator changes.
  - `event PropertyChangedEventHandler? PropertyChanged`
  - `event PropertyChangedEventHandler PanelPropertyChanged`
    - Occurs when a panel property value changes.
