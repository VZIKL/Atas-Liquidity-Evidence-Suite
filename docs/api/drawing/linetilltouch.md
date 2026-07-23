# LineTillTouch

**完整名称**: `ATAS.Indicators.Drawing.LineTillTouch`
**类型**: 类
**继承自**: `ATAS.Indicators.Drawing.TrendLine`

## 描述

Represents a trend line that extends until it is touched by the price.

## 公共方法

  - ` LineTillTouch(int bar, decimal price, CrossPen pen)`
    - Initializes a new instance of the LineTillTouch class with a single point.
  - ` LineTillTouch(int bar, decimal price, CrossPen pen, int fixedBarsCount)`
    - Initializes a new instance of the LineTillTouch class with a fixed number of bars.
  - `void CheckIfTouched(decimal high, decimal low, int bar, int lastBar)`
    - Checks if the trend line has been touched by the price within the specified high and low values.
  - ` TrendLine(int firstBar, decimal firstPrice, int secondBar, decimal secondPrice, CrossPen pen)`
    - Initializes a new instance of the TrendLine class.

## 属性

  - `bool Finished { get; }`
    - Gets a value indicating whether the trend line has been finished (touched).
  - `object Context { set; }`
    - Custom object context.
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
