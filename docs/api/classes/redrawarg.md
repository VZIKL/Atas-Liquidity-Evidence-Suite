# RedrawArg

**完整名称**: `ATAS.Indicators.RedrawArg`
**类型**: 类

## 描述

Represents the arguments for requesting a redraw of a chart.

## 公共方法

  - ` RedrawArg(Rectangle redrawRegion)`
    - Initializes a new instance of the RedrawArg class with the specified redraw region.

## 属性

  - `Rectangle RedrawRegion { set; }`
    - Gets or sets the region to redraw on the chart.
  - `bool ForceRedraw { set; }`
    - Gets or sets a value indicating whether the chart should be redrawn with user-interacted settings of frames per second (FPS). Should be used only if it is really needed, otherwise it could lead to performance issues.
