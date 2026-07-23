# TabAttribute

**完整名称**: `OFT.Attributes.TabAttribute`
**类型**: 类

## 描述

Attribute that assigns a property or all properties of a class to a named tab in the settings UI. Use alongside System.ComponentModel.DataAnnotations.DisplayAttribute for property display metadata (Name, GroupName, Description, Order).

## 公共方法

  - `string? GetLocalizedTab()`
    - Gets the localized tab name. Returns null if TabName is not set.
  - `int? GetTabOrder()`
    - Returns the explicitly assigned TabOrder, or null if not set.

## 属性

  - `string? TabName { set; }`
    - Tab name. If ResourceType is set, this is treated as a resource key.
  - `int TabOrder { set; }`
    - Tab display order. Lower values appear first. Tabs with equal order are sorted by the order their first property appears in the class. When not set, the tab is sorted purely by its source declaration order.
  - `Type? ResourceType { set; }`
    - Resource type for localization of TabName.
