# VisibleWhenAttribute

**完整名称**: `OFT.Attributes.VisibleWhenAttribute`
**类型**: 类

## 描述

Makes the property visible only when the specified source property's value matches one of the provided values. Used for dynamic property visibility in the settings UI (e.g., showing/hiding properties based on a mode enum).

## 公共方法

  - ` VisibleWhenAttribute(string propertyName, params object[] values)`

## 属性

  - `string PropertyName { get; }`
    - Name of the source property whose value determines visibility.
  - `object[] Values { get; }`
    - The set of values for which this property is visible. If the source property's current value is in this set, the property is shown.
