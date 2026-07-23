# SessionInfo

**完整名称**: `ATAS.DataFeedsCore.SessionServer.SessionInfo`
**类型**: 类

## 公共方法

  - `abstract void Start()`
  - `abstract void Stop()`
  - `void SetLoggedIn()`

## 保护方法

  - ` SessionInfo(SessionInfoType type, EndPoint address)`

## 属性

  - `SessionInfoType Type { get; }`
  - `EndPoint Address { get; }`
  - `ServerStates State { set; }`
  - `User User { set; }`
