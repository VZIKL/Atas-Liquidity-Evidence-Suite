# AsyncConnectorMessage

**完整名称**: `ATAS.DataFeedsCore.AsyncConnectorMessage`
**类型**: 类

## 描述

Service message for passing continuations to the connector thread.

## 属性

  - `SendOrPostCallback Callback { set; }`
  - `object State { set; }`
  - `ManualResetEvent Sync { set; }`
  - `bool IsSetupMessage { get; }`
    - Indicates that synchronization context should be set up on the connector queue thread.
