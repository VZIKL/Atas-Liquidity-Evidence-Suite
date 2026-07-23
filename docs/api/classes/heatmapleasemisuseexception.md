# HeatmapLeaseMisuseException

**完整名称**: `ATAS.Indicators.Heatmap.HeatmapLeaseMisuseException`
**类型**: 类

## 描述

Thrown when an indicator misuses the visual-state lease API. Distinct from a plain InvalidOperationException so call sites can catch lease misuse separately from generic invalid-operation errors, and tests can assert on Reason instead of message text.

## 属性

  - `HeatmapLeaseMisuseReason Reason { get; }`
    - The misuse class — see HeatmapLeaseMisuseReason.
