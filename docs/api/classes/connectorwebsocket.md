# ConnectorWebsocket

**完整名称**: `ATAS.DataFeedsCore.ConnectorWebsocket.ConnectorWebsocket`
**类型**: 类

## 公共方法

  - ` ConnectorWebsocket(int requestPerPeriod, TimeSpan period)`
    - Private websocket connections.
  - ` ConnectorWebsocket(int requestPerPeriod, TimeSpan period, IRequestSerializer serializer, RateLimiter? connectionLimiter=null, RateLimiter? crossMessageLimiter=null, string? connectorId=null)`
    - Public websocket connections.
  - `async Task Start()`
  - `async Task StopAsync()`
  - `bool SubscribeMarketData(Security security, SubscriptionType subType)`
    - Subscription request.
  - `bool SubscribeMarketData(IEnumerable< Security > securities, SubscriptionType subType)`
    - Market data subscription bulk request.
  - `void SubscribeLiquidations(IEnumerable< Security > securities)`
    - Liquidation subscription request.
  - `void UnsubscribeLiquidations(IEnumerable< Security > securities)`
    - Liquidation subscription request.
  - `bool UnsubscribeMarketData(Security security, SubscriptionType subType)`
    - Cancelling market data subscription request.
  - `bool UnsubscribeMarketData(IEnumerable< Security > securities, SubscriptionType subType)`
    - Cancelling market data subscription bulk request.
  - `void Send(object message)`
    - Single request.
  - `void SendImmediate(object message)`
    - Send request as soon as possible.
  - `void SabotageConnection()`
    - For test purposes only.
  - `void SabotageInitialization()`
    - For test purposes only.

## 属性

  - `IRequestSerializer? Serializer { get; }`
  - `bool IsPublic { get; }`
  - `ConnectionStates ConnectionState { get; }`
  - `TimeSpan ReconnectionInterval { get; }`
  - `bool IsConnected { get; }`
  - `string Url { set; }`
  - `TimeSpan Timeout { get; }`
  - `TaskCompletionSource PrivateConnectionSource { set; }`
    - Completion source for custom connection conditions.

## 事件

  - `event Action< ConnectorWebsocket >? Connected`
  - `event Action< ConnectorWebsocket, WebsocketException >? Error`
  - `event Action< ConnectorWebsocket, string >? Message`
