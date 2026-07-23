# HeatmapIndicatorDescriptorBuilder

**完整名称**: `ATAS.Indicators.Heatmap.HeatmapIndicatorDescriptorBuilder`
**类型**: 类

## 描述

Fluent builder that produces an immutable HeatmapIndicatorDescriptor alongside the typed visual / series handles required by the state builder. Single-shot: each builder yields exactly one descriptor via Done; further mutation throws. private static readonly HeatmapIndicatorDescriptor _descriptor; private static readonly HeatmapIndicatorVisualHandle _panel; private static readonly HeatmapIndicatorSeriesHandle<long> _value; static MyIndicator() { var build = HeatmapIndicator.Describe("vendor.my-indicator", "My Indicator"); _panel = build.SubPanelScalar("my.panel", "My Panel"); _value = _panel.Series<long>( "my.value", HeatmapIndicatorSeriesRole.Scalar, HeatmapIndicatorValueKind.Integer, metricId: "my.value"); _descriptor = build.Done(); } ATAS.Indicators.Heatmap.HeatmapIndicatorDescriptorBuilder.SubPanelScalarHeatmapIndicatorVisualHandle SubPanelScalar(string visualId, string? label=null, HeatmapIndicatorVisualStyle? defaultStyle=null, HeatmapIndicatorVisualPresentation? defaultPresentation=null) ATAS.Indicators.Heatmap.HeatmapIndicatorSeriesHandleStrongly typed handle for a series within a visual. Returned from HeatmapIndicatorVisualHandle....Definition HeatmapIndicatorSeriesHandle.cs:17 ATAS.Indicators.Heatmap.HeatmapIndicatorVisualHandleStrongly typed handle for a visual added to a descriptor via HeatmapIndicatorDescriptorBuilder....Definition HeatmapIndicatorVisualHandle.cs:15 ATAS.Indicators.Heatmap.HeatmapIndicatorVisualHandle.SeriesHeatmapIndicatorSeriesHandle< decimal > Series(string seriesId, HeatmapIndicatorSeriesRole role, HeatmapIndicatorValueKind valueKind, HeatmapIndicatorVisualStyle? defaultStyle=null, string? metricId=null, string? unit=null)Decimal fast path: the series stores decimal samples and no projection is required....Definition HeatmapIndicatorVisualHandle.cs:118 ATAS.Indicators.Heatmap.HeatmapIndicatorAuthor-facing entry points for the heatmap indicator API. The non-generic HeatmapIndicator coexists w...Definition IHeatmapIndicator.cs:113 ATAS.Indicators.Heatmap.HeatmapIndicator.Describestatic HeatmapIndicatorDescriptorBuilder Describe(string indicatorId, string? label=null)Begin describing a heatmap indicator. The returned builder yields visual and series handles that the ...

## 公共方法

  - `HeatmapIndicatorVisualHandle Visual(string visualId, HeatmapIndicatorVisualKind kind, string? label=null, HeatmapIndicatorVisualStyle? defaultStyle=null, HeatmapIndicatorVisualPresentation? defaultPresentation=null)`
    - Add a visual of any kind. The kind-specific helpers (PriceLine, SubPanelScalar, …) are usually clearer; reach for this one when the kind is computed at runtime.
  - `HeatmapIndicatorVisualHandle PriceLine(string visualId, string? label=null, HeatmapIndicatorVisualStyle? defaultStyle=null)`
  - `HeatmapIndicatorVisualHandle ValueArea(string visualId, string? label=null, HeatmapIndicatorVisualStyle? defaultStyle=null)`
  - `HeatmapIndicatorVisualHandle LevelLine(string visualId, string? label=null, HeatmapIndicatorVisualStyle? defaultStyle=null)`
  - `HeatmapIndicatorVisualHandle SubPanelScalar(string visualId, string? label=null, HeatmapIndicatorVisualStyle? defaultStyle=null, HeatmapIndicatorVisualPresentation? defaultPresentation=null)`
  - `HeatmapIndicatorVisualHandle SubPanelPair(string visualId, string? label=null, HeatmapIndicatorVisualStyle? defaultStyle=null, HeatmapIndicatorVisualPresentation? defaultPresentation=null)`
  - `HeatmapIndicatorVisualHandle Histogram(string visualId, string? label=null, HeatmapIndicatorVisualStyle? defaultStyle=null, HeatmapIndicatorVisualPresentation? defaultPresentation=null)`
  - `HeatmapIndicatorDescriptor Done()`
    - Seal the builder and produce the immutable descriptor. The visual / series handles minted by this builder remain usable as state-builder inputs after Done; what becomes invalid is mutation (no more Visual calls, no more HeatmapIndicatorVisualHandle.Series<TValue> calls). Single-shot: a second Done throws.
