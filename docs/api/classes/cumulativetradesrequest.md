# CumulativeTradesRequest

**完整名称**: `ATAS.Indicators.CumulativeTradesRequest`
**类型**: 类

## 描述

Represents a request to retrieve cumulative trade data within a specified time range or for a particular date. It mustn't be more than 7 days.

## 公共方法

  - ` CumulativeTradesRequest(DateTime beginTime, DateTime endTime, int minVolume, int maxVolume)`
    - Initializes a new instance of the CumulativeTradesRequest class with the specified time range and volume filters.
  - ` CumulativeTradesRequest(DateTime beginTime, DateTime endTime, CumulativeTradesMode mode)`
    - Initializes a new instance of the CumulativeTradesRequest class with the specified time range and filtering mode.
  - ` CumulativeTradesRequest(DateTime date)`
    - Initializes a new instance of the CumulativeTradesRequest class for retrieving data for a particular date.
  - ` CumulativeTradesRequest(DateTime beginTime, DateTime endTime, CumulativeTradesMode mode, int minVolume, int maxVolume)`
    - Initializes a new instance of the CumulativeTradesRequest class with an explicit mode and volume filter.

## 属性

  - `DateTime BeginTime { get; }`
    - Gets the start time of the requested data.
  - `DateTime EndTime { get; }`
    - Gets the end time of the requested data.
  - `decimal MinVolume { get; }`
    - Gets the minimum cumulative volume filter for the requested data.
  - `decimal MaxVolume { get; }`
    - Gets the maximum cumulative volume filter for the requested data.
  - `int RequestId { get; }`
    - Gets the unique identifier for the request.
  - `CumulativeTradesMode Mode { get; }`
    - Gets the mode used to filter cumulative trades by their aggregated volume.
  - `bool GetDataForParticularDate { get; }`
    - Gets or sets a flag indicating whether to get data for a particular date only.
