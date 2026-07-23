# PriceSelectionValue

**完整名称**: `ATAS.Indicators.PriceSelectionValue`
**类型**: 类

## 描述

Represents a class for defining price level selection in clusters and bars. Using in PriceSelectionDataSeries.

## 公共方法

  - ` PriceSelectionValue(decimal price)`
    - Constructor for creating a price selection with a given price.
  - `Color GetPriceSelectionColor()`
    - Gets the current price selection color.
  - `Color GetObjectsColor()`
    - Gets the current graphic objects color.
  - `RenderPen GetBorderPen()`
    - Gets the render pen for the border of the graphic objects.

## 属性

  - `decimal MinimumPrice { set; }`
    - Minimum price of the selection.
  - `decimal MaximumPrice { set; }`
    - Maximum price of the selection.
  - `int Size { set; }`
    - Graphic objects size.
  - `string Tooltip { set; }`
    - Tooltip associated with the selection.
  - `bool DrawValue { set; }`
    - Draw value inside object.
  - `decimal? RenderValue { set; }`
    - Render value inside object.
  - `SelectionType SelectionSide { set; }`
    - Selection type.
  - `ObjectType VisualObject { set; }`
    - Visual object type.
  - `CrossColor PriceSelectionColor { set; }`
    - Color of the price selection. Use alpha channel for transparency.
  - `CrossColor ObjectColor { set; }`
    - Color of the graphic objects.
  - `decimal HeightFactor { set; }`
    - Height Factor (obsolete).
  - `object Context { set; }`
    - Коэффициент уменьшения высоты выделения цены. Если значение 100, выделяется вся высота, если 50, выделяется половина
  - `int ObjectsTransparency { set; }`
    - Transparency of objects filling.
