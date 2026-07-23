# TrendLine

**完整名称**: `ATAS.Indicators.Drawing.TrendLine`
**类型**: 类

## 描述

Represents a trend line on a chart.

## 公共方法

  - ` TrendLine(int firstBar, decimal firstPrice, int secondBar, decimal secondPrice, CrossPen pen)`
    - Initializes a new instance of the TrendLine class.

## 属性

  - `CrossPen Pen { set; }`
    - Gets or sets the pen used to draw the trend line.
  - `int FirstBar { set; }`
    - Gets or sets the index of the first bar.
  - `int SecondBar { set; }`
    - Gets or sets the index of the second bar.
  - `decimal FirstPrice { set; }`
    - Gets or sets the price value of the first point.
  - `decimal SecondPrice { set; }`
    - Gets or sets the price value of the second point.
  - `bool IsRay { set; }`
    - Gets or sets a value indicating whether the trend line is displayed as a ray.
