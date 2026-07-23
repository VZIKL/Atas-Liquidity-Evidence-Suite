# TaskQueue

**完整名称**: `ATAS.DataFeedsCore.ConnectorWebsocket.TaskQueue`
**类型**: 类

## 公共方法

  - ` TaskQueue(int requestPerPeriod, TimeSpan period, bool strictSequence=true)`
    - Task queue with execution frequency.
  - `async Task< bool > WaitAsync(bool stopOnError=false)`
  - `void Add(Func< Task > action, bool highPriority=false)`
  - `void Clear()`

## 属性

  - `int Count { get; }`

## 事件

  - `event Action< Exception > QueueError`
