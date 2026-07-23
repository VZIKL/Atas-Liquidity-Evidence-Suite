# BaseDrawingText

**完整名称**: `ATAS.Indicators.Drawing.BaseDrawingText`
**类型**: 类

## 描述

Represents a base class for drawing text on a chart.

## 公共方法

  - `override string ToString()`
    - Returns a string representation of the object.

## 属性

  - `int XOffset { set; }`
    - Gets or sets the X-axis offset of the text.
  - `string Tag { set; }`
    - Gets or sets a tag associated with the text.
  - `string Text { set; }`
    - Gets or sets the text to be displayed.
  - `int Bar { set; }`
    - Gets or sets the index of the bar where the text is displayed.
  - `int YOffset { set; }`
    - Gets or sets the Y-axis offset of the text.
  - `bool IsAbovePrice { set; }`
    - Gets or sets a value indicating whether the text is displayed above the price.
  - `Color Textcolor { set; }`
    - Gets or sets the color of the text.
  - `Color Outlinecolor { set; }`
    - Gets or sets the color of the outline of the text.
  - `Color FillColor { set; }`
    - Gets or sets the fill color of the text.
  - `bool AutoSize { set; }`
    - Gets or sets a value indicating whether the text size is automatically adjusted.
  - `float FontSize { set; }`
    - Gets or sets the font size of the text.
  - `CrossFont TextFont { set; }`
    - Gets or sets the font used for the text.
