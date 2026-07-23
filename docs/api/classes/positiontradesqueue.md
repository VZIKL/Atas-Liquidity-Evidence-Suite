# PositionTradesQueue

**完整名称**: `ATAS.DataFeedsCore.PositionTradesQueue`
**类型**: 类

## 公共方法

  - ` PositionTradesQueue(ILoggerSource logger, Portfolio portfolio, Security security, decimal openVolume)`
  - ` PositionTradesQueue(ILoggerSource logger, Position position)`
  - `void Add(MyTrade newTrade)`
  - `void AddTrade(bool isBuy, decimal price, decimal volume)`
  - `void AddTrade(decimal price, decimal volume)`
  - `bool CalculateAveragePrice(decimal volume, bool checkTotalVolume, out decimal averagePrice)`
  - `void Clear()`
  - `decimal decimal avgPrice GetPosition()`
  - `decimal volume()`

## 属性

  - `decimal Volume { get; }`
