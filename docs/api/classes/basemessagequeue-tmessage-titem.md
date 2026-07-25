# BaseMessageQueue< TMessage, TItem >

**完整名称**: `ATAS.DataFeedsCore.BaseMessageQueue< TMessage, TItem >`
**类型**: 类
**继承自**: `ATAS.DataFeedsCore.IMessageQueue< TMessage >`

## 公共方法

  - `void Enqueue(IDataFeedConnector connector, TMessage message)`
  - `void Enqueue(IDataFeedConnector connector, Action action)`
  - `void Start(IDataFeedConnector connector, Action< TMessage > handler)`
  - `void Stop(IDataFeedConnector connector)`
  - `void Enqueue(IDataFeedConnector connector, TMessage message)`
  - `void Enqueue(IDataFeedConnector connector, Action action)`
  - `void Start(IDataFeedConnector connector, Action< TMessage > handler)`
  - `void Stop(IDataFeedConnector connector)`

## 保护方法

  - ` BaseMessageQueue()`
  - `abstract TItem CreateItem(IDataFeedConnector connector, TMessage message, Action action)`
  - `abstract void OnStart(IDataFeedConnector connector, Action< TMessage > handler)`
  - `abstract bool OnStop(IDataFeedConnector connector)`
  - `abstract void OnProcess(TItem item)`

## 属性

  - `TimeSpan HeartbeatTimeout { set; }`
  - `TimeSpan HeartbeatTimeout { set; }`

## 事件

  - `event Action Heartbeat`
  - `event Action Heartbeat`
