# 指标开发

Indicator 基类、Heatmap、数据提供者等指标开发相关类

| 类名 | 方法 | 属性 | 事件 | 描述 |
|------|------|------|------|------|
| [`BaseIndicator`](baseindicator.md) | 35 | 18 | 5 | Base class for custom indicators in a chart. |
| [`CustomValue`](customvalue.md) | 0 | 3 | 0 | Represents a custom value with associated properties. |
| [`ExtendedIndicator`](extendedindicator.md) | 83 | 42 | 0 | An extended base class for custom indicators that provide ad |
| [`FixedProfileRequest`](fixedprofilerequest.md) | 2 | 2 | 0 | Represents a request for a fixed profile with a specific per |
| [`HeatmapIndicator< TSettings >`](heatmapindicator< tsettings >.md) | 17 | 9 | 0 | Author-facing entry points for the heatmap indicator API. Th |
| [`HeatmapIndicatorAttribute`](heatmapindicatorattribute.md) | 1 | 6 | 0 | Marks a class as a heatmap indicator type and supplies disco |
| [`HeatmapIndicatorDescriptorBuilder`](heatmapindicatordescriptorbuilder.md) | 8 | 0 | 0 | Fluent builder that produces an immutable HeatmapIndicatorDe |
| [`HeatmapIndicatorFallbackReWarmGuard`](heatmapindicatorfallbackrewarmguard.md) | 3 | 0 | 0 | State holder for indicators whose calculation is anchored at |
| [`HeatmapIndicatorSeriesHandle< TValue >`](heatmapindicatorserieshandle< tvalue >.md) | 0 | 0 | 0 | Strongly typed handle for a series within a visual. Returned |
| [`HeatmapIndicatorVisualHandle`](heatmapindicatorvisualhandle.md) | 2 | 0 | 0 | Strongly typed handle for a visual added to a descriptor via |
| [`HeatmapLeaseMisuseException`](heatmapleasemisuseexception.md) | 0 | 1 | 0 | Thrown when an indicator misuses the visual-state lease API. |
| [`Indicator`](indicator.md) | 95 | 64 | 0 | Base class for custom indicators. |
| [`IndicatorDataProvider`](indicatordataprovider.md) | 19 | 20 | 0 | Implementation of the IIndicatorDataProvider interface that  |
| [`IndicatorSeries`](indicatorseries.md) | 3 | 28 | 0 | Represents a custom data series for an indicator, derived fr |
| [`InstrumentInfo`](instrumentinfo.md) | 1 | 8 | 0 | Implementation of the IInstrumentInfo interface representing |
| [`MarketDataArg`](marketdataarg.md) | 1 | 12 | 0 | Represents a data point in the market. |
| [`MarketDepthInfoProvider`](marketdepthinfoprovider.md) | 3 | 4 | 0 | A class that implements the IMarketDepthInfoProvider interfa |
| [`MarketDepthSnapshot`](marketdepthsnapshot.md) | 0 | 3 | 0 | Represents the end state of market depth over a specified ti |
| [`MarketDepthSnapshotRequest`](marketdepthsnapshotrequest.md) | 0 | 4 | 0 | Represents a request to retrieve a snapshot of the market de |
| [`NotifyPropertyChangedBase`](notifypropertychangedbase.md) | 2 | 0 | 1 | Base class for implementing the INotifyPropertyChanged inter |
| [`PriceSelectionValue`](priceselectionvalue.md) | 4 | 13 | 0 | Represents a class for defining price level selection in clu |
| [`PriceVolumeInfo`](pricevolumeinfo.md) | 0 | 7 | 0 | Represents information on volumes at a specific price. |
| [`RangeValue`](rangevalue.md) | 0 | 2 | 0 | RangeDataSeries element. |
| [`RedrawArg`](redrawarg.md) | 1 | 2 | 0 | Represents the arguments for requesting a redraw of a chart. |
| [`ValueArea`](valuearea.md) | 0 | 2 | 0 | Represents information on Value area high/low. |

---