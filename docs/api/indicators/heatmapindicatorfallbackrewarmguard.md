# HeatmapIndicatorFallbackReWarmGuard

**完整名称**: `ATAS.Indicators.Heatmap.HeatmapIndicatorFallbackReWarmGuard`
**类型**: 类

## 描述

State holder for indicators whose calculation is anchored at the real data start (e.g. CVD FromDataStart, VWAP FromDataStart) and may receive a fallback-range warm-up before the host knows the real data start. Encapsulates the latch protocol so the indicator does not have to track three flags and an inline check by hand. Usage: Construct once per instance, typically as a readonly field. Call Reset from ResetAsync. Call OnWarmedUp from WarmUpAsync with the incoming request — the guard captures HeatmapIndicatorWarmupRequest.IsFallbackRange and re-arms the latch. Call ShouldRequestReWarm from ProcessTicksAsync after processing the batch; if it returns true, await IHeatmapIndicatorRuntime.RequestReWarmAsync. The guard latches per warm-up cycle: ShouldRequestReWarm returns true at most once between two OnWarmedUp calls, so repeated tick batches do not re-trigger. A fresh warm-up re-arms the latch for the next fallback episode. Threading: per-instance, lock-free. The platform serialises calls on a single indicator instance, which is also the only valid caller of this guard.

## 公共方法

  - `void Reset()`
  - `void OnWarmedUp(HeatmapIndicatorWarmupRequest request)`
  - `bool ShouldRequestReWarm(HeatmapTickBatch ticks)`
