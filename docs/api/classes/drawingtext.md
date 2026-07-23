# DrawingText

**完整名称**: `ATAS.Indicators.Drawing.DrawingText`
**类型**: 类
**继承自**: `ATAS.Indicators.Drawing.BaseDrawingText`

## 描述

Represents a class for drawing text on a chart with additional alignment options.

## 公共方法

  - `enum TextAlign()`
    - Gets or sets the alignment of the text. More...
  - ` DrawingText(decimal tickSize)`
    - Initializes a new instance of the DrawingText class with the specified tick size.

## 属性

  - `override string ToString `
    - Returns a string representation of the object.
  - `TextAlign Align { set; }`
    - Gets or sets the text alignment.
  - `int Price { set; }`
    - Gets or sets the price value associated with the text.
  - `decimal TickSize { get; }`
    - Gets the tick size value used for calculations.
  - `decimal TextPrice { set; }`
    - Gets or sets the price value associated with the text (in decimal).
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
