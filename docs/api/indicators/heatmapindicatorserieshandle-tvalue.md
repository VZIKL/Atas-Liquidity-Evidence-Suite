# HeatmapIndicatorSeriesHandle< TValue >

**完整名称**: `ATAS.Indicators.Heatmap.HeatmapIndicatorSeriesHandle< TValue >`
**类型**: 类

## 描述

Strongly typed handle for a series within a visual. Returned from HeatmapIndicatorVisualHandle.Series<TValue>(string, HeatmapIndicatorSeriesRole, HeatmapIndicatorValueKind, System.Func<TValue, decimal>, HeatmapIndicatorVisualStyle?, string?, string?); the constructor is internal so authors cannot fabricate one. TValue is the indicator-internal sample type — what the indicator's calculation produces. The handle also carries the projection that converts the typed sample to a renderer-facing decimal; the lease applies the projection inline on every Append so the chunked storage holds decimal samples ready for the renderer.
