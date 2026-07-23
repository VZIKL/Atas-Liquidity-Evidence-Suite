# HeatmapIndicatorVisualHandle

**完整名称**: `ATAS.Indicators.Heatmap.HeatmapIndicatorVisualHandle`
**类型**: 类

## 描述

Strongly typed handle for a visual added to a descriptor via HeatmapIndicatorDescriptorBuilder. The handle captures the owning descriptor's identity so the state builder can reject handles from a different descriptor at runtime, and the constructor is internal so authors cannot fabricate handles by hand.

## 公共方法

  - `HeatmapIndicatorSeriesHandle< TValue > Series< TValue >(string seriesId, HeatmapIndicatorSeriesRole role, HeatmapIndicatorValueKind valueKind, Func< TValue, decimal > valueProjection, HeatmapIndicatorVisualStyle? defaultStyle=null, string? metricId=null, string? unit=null)`
    - Add a typed series to this visual. TValue is the indicator-internal sample type — the type the indicator computes (e.g. HeatmapPriceLineSample, HeatmapValueAreaSample, custom records). Each Append on the lease projects the typed value to the renderer-facing decimal via valueProjection .
  - `HeatmapIndicatorSeriesHandle< decimal > Series(string seriesId, HeatmapIndicatorSeriesRole role, HeatmapIndicatorValueKind valueKind, HeatmapIndicatorVisualStyle? defaultStyle=null, string? metricId=null, string? unit=null)`
    - Decimal fast path: the series stores decimal samples and no projection is required. Equivalent to the generic overload with the identity projection, but avoids the delegate.
