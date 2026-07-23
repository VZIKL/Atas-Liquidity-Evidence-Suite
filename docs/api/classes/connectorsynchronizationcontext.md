# ConnectorSynchronizationContext

**完整名称**: `ATAS.DataFeedsCore.AsyncConnector< TPortfolioKey, TSecurityKey >.ConnectorSynchronizationContext`
**类型**: 类

## 描述

Custom synchronization context to forward await continuations to the connector queue.

## 公共方法

  - ` ConnectorSynchronizationContext(AsyncConnector< TPortfolioKey, TSecurityKey > connector)`
  - `override void Post(SendOrPostCallback d, object state)`
  - `override void Send(SendOrPostCallback d, object state)`
  - `override SynchronizationContext CreateCopy()`
