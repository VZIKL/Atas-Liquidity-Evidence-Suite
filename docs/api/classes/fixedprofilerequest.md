# FixedProfileRequest

**完整名称**: `ATAS.Indicators.FixedProfileRequest`
**类型**: 类

## 描述

Represents a request for a fixed profile with a specific period.

## 公共方法

  - ` FixedProfileRequest(FixedProfilePeriods period)`
    - Initializes a new instance of the FixedProfileRequest class with the specified period.
  - ` FixedProfileRequest(FixedProfilePeriods period, long? tradingSession)`
    - Initializes a new instance of the FixedProfileRequest class with the specified period.

## 属性

  - `FixedProfilePeriods Period { get; }`
    - Gets the fixed profile period associated with this request.
  - `long? TradingSession { get; }`
    - Gets the fixed profile trading session identifier (ETH/RTH/etc.) associated with this request.
