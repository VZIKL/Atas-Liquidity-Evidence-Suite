# ConnectorLatencyManager

**完整名称**: `ATAS.DataFeedsCore.ConnectorLatencyManager`
**类型**: 类
**继承自**: `ATAS.DataFeedsCore.IConnectorLatencyManager`

## 公共方法

  - ` ConnectorLatencyManager()`
  - `void ProcessTrade(Security security, DateTime time)`
  - `void ProcessBestBidAsk(Security security, DateTime time)`
  - `void ProcessMarketDepths(Security security, DateTime time)`
  - `TimeSpan ProcessOrderLatency(DateTime startTime)`
  - `void Reset()`
  - `void ProcessTickTime(DateTime time)`
  - `void ProcessMarketDepthTime(DateTime time)`

## 属性

  - `TimeSpan FeedDelay { set; }`
  - `ITimeSyncManager TimeSyncManager { set; }`
  - `TimeSpan? OrdersLatency { get; }`
    - Orders processing delay time.
  - `TimeSpan? MarketDataLatency { get; }`
    - Market data processing delay time.
  - `DateTime? LastMarketDataReceptionTimeUtc { get; }`
    - Last market data update time in UTC.
  - `TimeSpan? TimeSinceLastMarketDataReceived { get; }`
    - Time elapsed since the last market data update.
  - `Action< TimeSpan?>? OrdersLatencyChanged `
    - Event raised when OrdersLatency value changes.
  - `Action< TimeSpan?>? MarketDataLatencyChanged `
    - Event raised when MarketDataLatency value changes.
  - `TimeSpan? OrdersLatency { get; }`
    - Orders processing delay time.
  - `TimeSpan? MarketDataLatency { get; }`
    - Market data processing delay time.
  - `DateTime? LastMarketDataReceptionTimeUtc { get; }`
    - Last market data update time in UTC.
  - `TimeSpan? TimeSinceLastMarketDataReceived { get; }`
    - Time elapsed since the last market data update.

## 事件

  - `event Action< DateTime?>? LastMarketDataReceptionTimeChanged`
    - Event raised when TimeSinceLastMarketDataReceived value changes.
  - `event Action< TimeSpan?>? OrdersLatencyChanged`
    - Event raised when OrdersLatency value changes.
  - `event Action< TimeSpan?>? MarketDataLatencyChanged`
    - Event raised when MarketDataLatency value changes.
  - `event Action< DateTime?>? LastMarketDataReceptionTimeChanged`
    - Event raised when TimeSinceLastMarketDataReceived value changes.
