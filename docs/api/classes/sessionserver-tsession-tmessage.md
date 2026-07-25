# SessionServer< TSession, TMessage >

**完整名称**: `ATAS.DataFeedsCore.SessionServer.SessionServer< TSession, TMessage >`
**类型**: 类

## 公共方法

  - ` SessionServer(string name, Func< Socket, Action< TSession, TMessage >, TSession > sessionFactory, Action< TSession, TMessage > handler)`
  - `void Start()`
  - `void Stop()`
  - `void Start()`
  - `void Stop()`

## 属性

  - `string Address { set; }`
  - `int Port { set; }`
  - `ServerStates State { get; }`
