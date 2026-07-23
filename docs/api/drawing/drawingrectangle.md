# DrawingRectangle

**完整名称**: `ATAS.Indicators.Drawing.DrawingRectangle`
**类型**: 类

## 描述

Represents a rectangle drawn on a chart.

## 公共方法

  - ` DrawingRectangle(int firstBar, decimal firstPrice, int secondBar, decimal secondPrice, CrossPen outlinePen, Brush fillBrush)`
    - Initializes a new instance of the DrawingRectangle class with specified parameters.
  - ` DrawingRectangle(int firstBar, decimal firstPrice, int secondBar, decimal secondPrice, CrossPen outlinePen, Brush fillBrush, CrossPen midPen)`
    - Initializes a new instance of the DrawingRectangle class with specified parameters.

## 属性

  - `Brush Brush { set; }`
    - Gets or sets the brush used to fill the rectangle.
  - `CrossPen Pen { set; }`
    - Gets or sets the pen used to draw the outline of the rectangle.
  - `CrossPen MiddlePen { set; }`
    - Gets or sets the pen used to draw the middle horizontal line of the rectangle.
  - `int FirstBar { set; }`
    - Gets or sets the index of the first bar.
  - `int SecondBar { set; }`
    - Gets or sets the index of the second bar.
  - `decimal FirstPrice { set; }`
    - Gets or sets the price value of the first point.
  - `decimal SecondPrice { set; }`
    - Gets or sets the price value of the second point.
  - `bool ExtendRight { set; }`
    - Gets or sets rectangle extension to right side.
  - `bool ExtendLeft { set; }`
    - Gets or sets rectangle extension to left side.
  - `bool MidLineEnabled { set; }`
    - Gets or sets drawing of middle horizontal line of rectangle.
