# MultiConnectorMessageQueue< TMessage >

**完整名称**: `ATAS.DataFeedsCore.MultiConnectorMessageQueue< TMessage >`
**类型**: 类
**继承自**: `ATAS.DataFeedsCore.BaseMessageQueue< TMessage,(IDataFeedConnector, TMessage, Action)>`

## 保护方法

  - ` override(IDataFeedConnector, TMessage, Action)`
  - `override void OnStart(IDataFeedConnector connector, Action< TMessage > handler)`
  - `override bool OnStop(IDataFeedConnector connector)`
  - `override void OnProcess((IDataFeedConnector, TMessage, Action) item)`
  - ` BaseMessageQueue()`
  - `abstract TItem CreateItem(IDataFeedConnector connector, TMessage message, Action action)`
  - `abstract void OnStart(IDataFeedConnector connector, Action< TMessage > handler)`
  - `abstract bool OnStop(IDataFeedConnector connector)`
  - `abstract void OnProcess(TItem item)`
  - `void Enqueue(IDataFeedConnector connector, TMessage message)`
  - `void Enqueue(IDataFeedConnector connector, Action action)`
  - `void Start(IDataFeedConnector connector, Action< TMessage > handler)`
  - `void Stop(IDataFeedConnector connector)`
  - `TimeSpan HeartbeatTimeout()`
  - `Action Heartbeat()`
