# MarketDepthSnapshotRequest

**完整名称**: `ATAS.Indicators.MarketDepthSnapshotRequest`
**类型**: 类

## 描述

Represents a request to retrieve a snapshot of the market depth for a specified time range.

## 属性

  - `int RequestId { get; }`
    - Unique identifier of the request.
  - `required DateTime From { get; }`
    - Time for data to start from.
  - `required DateTime To { get; }`
    - End time of the requested data.
  - `required TimeSpan Period { get; }`
    - Period for which the data is to be retrieved.
