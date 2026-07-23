# HeatmapIndicatorAttribute

**完整名称**: `ATAS.Indicators.Heatmap.HeatmapIndicatorAttribute`
**类型**: 类

## 描述

Marks a class as a heatmap indicator type and supplies discovery metadata. Apply to a concrete class that derives from HeatmapIndicator<TSettings> (or implements IHeatmapIndicator directly).

## 公共方法

  - ` HeatmapIndicatorAttribute(string id, string? displayName=null)`

## 属性

  - `string Id { get; }`
    - Stable type identifier, e.g. "heatmap.ohlc-plus". Convention: "&lt;vendor&gt;.&lt;indicator-name&gt;" using lowercase-with-dots. Must be unique within all assemblies scanned by discovery.
  - `string? DisplayName { get; }`
    - Localisable display name. If omitted, the class name is used.
  - `Type? ResourceType { get; }`
    - Localisation resource type for DisplayName / Description.
  - `string? DisplayNameKey { get; }`
    - Localisation key for DisplayName when ResourceType is set.
  - `string? DescriptionKey { get; }`
    - Localisation key for Description.
  - `string? HelpLink { get; }`
    - Optional documentation URL shown in the editor.
