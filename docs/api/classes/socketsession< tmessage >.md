# SocketSession< TMessage >

**完整名称**: `ATAS.DataFeedsCore.SessionServer.SocketSession< TMessage >`
**类型**: 类
**继承自**: `ATAS.DataFeedsCore.SessionServer.SessionInfo`

## 公共方法

  - `override void Start()`
  - `override void Stop()`
  - `void Send(TMessage message)`
  - `abstract void Start()`
  - `abstract void Stop()`
  - `void SetLoggedIn()`

## 保护方法

  - ` SocketSession(SessionInfoType type, Socket socket, int maxQueueSize)`
  - ` SocketSession(SessionInfoType type, Socket socket)`
  - `abstract void Process(SocketAsyncEventArgs e)`
  - `abstract void SetSendBuffer(ConcurrentQueue< TMessage > queue, SocketAsyncEventArgs e)`
  - `abstract void SetReceiveBuffer(SocketAsyncEventArgs e)`
  - `abstract void SendLogout(string reason=null)`
  - `void CloseClientSocket(string reason=null)`
  - ` SessionInfo(SessionInfoType type, EndPoint address)`

## 属性

  - `int QueueLength { get; }`
  - `int MaxQueueSize { get; }`
  - `SessionInfoType Type { get; }`
  - `EndPoint Address { get; }`
  - `ServerStates State { set; }`
  - `User User { set; }`
