# HeatmapIndicator< TSettings >

**完整名称**: `ATAS.Indicators.Heatmap.HeatmapIndicator< TSettings >`
**类型**: 类
**继承自**: `ATAS.Indicators.Heatmap.IHeatmapIndicator`

## 描述

Author-facing entry points for the heatmap indicator API. The non-generic HeatmapIndicator coexists with the generic HeatmapIndicator<TSettings> base class — different arities disambiguate them at the type system level. Strongly typed base for indicator authors. Bridges to the non-generic IHeatmapIndicator with a single explicit cast, so derived classes work against typed settings. Type Constraints TSettings :class TSettings :new()

## 公共方法

  - `virtual ValueTask ConfigureAsync(TSettings settings, CancellationToken cancellationToken)`
    - Apply user-edited settings. The base class has already stored settings in the inherited Settings property by the time this runs, so the default implementation does nothing. Override only when the indicator needs to react to a settings change — e.g. invalidate an accumulator, request a state reset on calc-mode change, or rebuild visual presentation under a lease. Implementations do not need to assign the supplied settings to a private field; read them via Settings.
  - `ValueTask ConfigureAsync(object settings, CancellationToken cancellationToken)`
    - Apply user-edited settings. The runtime type of settings must be assignable to SettingsType.
  - `ValueTask OnStateResetNotificationAsync(IHeatmapIndicatorContext context, IHeatmapIndicatorRuntime runtime, CancellationToken cancellationToken)`
    - Notify the indicator that the platform has cleared State. Called when the active context changes (instrument, session, time zone) or when the indicator itself called IHeatmapIndicatorRuntime.RequestStateResetAsync.
  - `static HeatmapIndicatorDescriptorBuilder Describe(string indicatorId, string? label=null)`
    - Begin describing a heatmap indicator. The returned builder yields visual and series handles that the author captures into static readonly fields; the runtime IHeatmapVisualState that backs the indicator is materialised lazily by the base class.
  - `static HeatmapIndicatorDescriptorBuilder Describe< TSelf >(string? labelOverride=null)`
    - Begin describing the indicator using metadata from the HeatmapIndicatorAttribute applied to TSelf . Authors call this from the static constructor of the deriving type, which keeps the type id declared exactly once (in the attribute) and removes the typo-mismatch risk between discovery metadata and the descriptor.

## 保护方法

  - `virtual ValueTask OnStateResetCoreAsync(IHeatmapIndicatorContext context, IHeatmapIndicatorRuntime runtime, CancellationToken cancellationToken)`
    - Override to react to a state-reset notification. The base class has already saved context and runtime into Context / Runtime by the time this runs, so most overrides only need to clear their own indicator-internal accumulators (fields, dictionaries, etc.) and don't need either argument. The arguments are still surfaced for indicators that want to drive a re-warm or capture context-derived state synchronously.
  - `void UpdateVisual(HeatmapIndicatorVisualHandle visual, Action< IHeatmapVisualLease > update)`
    - Mutate one visual under a short-lived state lease. Use this for style/presentation-only updates or when a callback needs one visual lease and no cross-visual coordination.
  - `void UpdateSeries< TValue >(HeatmapIndicatorSeriesHandle< TValue > series, Action< IHeatmapSeriesLease< TValue > > update)`
    - Mutate one series under a short-lived state lease. Use this for simple append/clear/trim operations where the visual style and presentation do not need to change in the same transaction.
  - `void ClearSeries< TValue >(params HeatmapIndicatorSeriesHandle< TValue >[] series)`
    - Clear a homogeneous set of series under a short-lived state lease.
  - `static void ClearSeries< TValue >(IHeatmapVisualLease visualLease, params HeatmapIndicatorSeriesHandle< TValue >[] series)`
    - Clear a homogeneous set of series inside an existing visual lease. Useful for rebuilds that clear and refill multiple related series in one commit.
  - `static HeatmapIndicatorDescriptorBuilder Describe< TSelf >(string? labelOverride=null)`
    - Begin describing the indicator using metadata from the HeatmapIndicatorAttribute applied to TSelf . Authors call this from the static constructor of the deriving type, which keeps the type id declared exactly once (in the attribute) and removes the typo-mismatch risk between discovery metadata and the descriptor.
  - `static List< HeatmapTradeTick > OrderedTicks(HeatmapTickBatch ticks)`
    - Return eligible ticks from a pooled batch ordered by timestamp. The returned list is detached from the batch and may be kept after the callback returns.
  - `static List< HeatmapTradeTick > OrderedTicks(HeatmapTickBatch ticks, Predicate< HeatmapTradeTick > predicate)`
    - Return eligible ticks from a pooled batch ordered by timestamp. The returned list is detached from the batch and may be kept after the callback returns.
  - `static List< HeatmapTradeTick > OrderedTicks(IEnumerable< HeatmapTradeTick > ticks)`
    - Return eligible ticks from an enumerable ordered by timestamp.
  - `static List< HeatmapTradeTick > OrderedTicks(IEnumerable< HeatmapTradeTick > ticks, Predicate< HeatmapTradeTick > predicate)`
    - Return eligible ticks from an enumerable ordered by timestamp.
  - `static bool HasValidTimestampPriceVolume(HeatmapTradeTick tick)`
    - Common filter for price/volume indicators: timestamp, price, and volume must all be positive.
  - `static bool HasValidBuySellVolume(HeatmapTradeTick tick)`
    - Common filter for buy/sell volume indicators: timestamp and volume must be positive and direction must be buy or sell.

## 属性

  - `abstract HeatmapIndicatorDescriptor Descriptor { get; }`
    - Static type-level metadata. Identifies the indicator type, declares its placement (overlay vs sub-panel), visual roles, and series shape. Must not change between calls.
  - `Type SettingsType { get; }`
    - CLR type of the settings DTO this indicator accepts. Used by the catalogue to materialise persisted settings into the right shape before calling ConfigureAsync.
  - `TSettings Settings { get; }`
    - Most recent settings DTO applied through ConfigureAsync. The base class assigns this property before invoking the typed ConfigureAsync(TSettings, CancellationToken) override, so derived indicators can read the current settings directly without caching them into a private field. Defaults to a fresh TSettings instance until the platform calls ConfigureAsync for the first time.
  - `IHeatmapVisualState State { get; }`
    - Persistent visual state. Lazily created on first access from the indicator's own Descriptor; the platform may pre-create it via IHeatmapIndicator.State at instance construction time so the reference is stable from the first lifecycle callback onward.
  - `IHeatmapIndicatorContext? Context { get; }`
    - Most recent context handed in by the platform via IHeatmapIndicator.OnStateResetNotificationAsync. Null only before the very first reset notification — the platform always emits a reset before any data callback, so by the time IHeatmapTradeTickConsumer.ProcessTicksAsync / IHeatmapWarmupIndicator.WarmUpAsync / IHeatmapProfileConsumer.ProcessProfileAsync fires this is non-null.
  - `IHeatmapIndicatorRuntime? Runtime { get; }`
    - Most recent runtime handed in by the platform via IHeatmapIndicator.OnStateResetNotificationAsync. Use to call IHeatmapIndicatorRuntime.RequestReWarmAsync / IHeatmapIndicatorRuntime.RequestStateResetAsync. The reference is rebound on every reset, so do not cache it across reset boundaries — read this property each time.
  - `HeatmapIndicatorDescriptor Descriptor { get; }`
    - Static type-level metadata. Identifies the indicator type, declares its placement (overlay vs sub-panel), visual roles, and series shape. Must not change between calls.
  - `Type SettingsType { get; }`
    - CLR type of the settings DTO this indicator accepts. Used by the catalogue to materialise persisted settings into the right shape before calling ConfigureAsync.
  - `IHeatmapVisualState State { get; }`
    - Persistent visual state read by the renderer. Created by the platform from Descriptor at instance construction time; the same reference is returned for the entire instance lifetime. Resets clear content but never replace the reference.
