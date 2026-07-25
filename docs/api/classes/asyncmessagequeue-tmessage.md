# AsyncMessageQueue< TMessage >

**完整名称**: `ATAS.DataFeedsCore.AsyncMessageQueue< TMessage >`
**类型**: 类
**继承自**: `ATAS.DataFeedsCore.IMessageQueue< TMessage >`

## 公共方法

  - ` AsyncMessageQueue()`
  - ` AsyncMessageQueue(AsyncOneThreadProcessor processor)`
  - `void Enqueue(IDataFeedConnector connector, TMessage message)`
  - `void Enqueue(IDataFeedConnector connector, Action action)`
  - `void Start(IDataFeedConnector connector, Action< TMessage > handler)`
  - `void Stop(IDataFeedConnector connector)`
  - `void Enqueue(IDataFeedConnector connector, TMessage message)`
  - `void Enqueue(IDataFeedConnector connector, Action action)`
  - `void Start(IDataFeedConnector connector, Action< TMessage > handler)`
  - `void Stop(IDataFeedConnector connector)`

## 属性

  - `TimeSpan HeartbeatTimeout { set; }`
  - `TimeSpan HeartbeatTimeout { set; }`

## 事件

  - `event Action? Heartbeat`
  - `event Action Heartbeat`
