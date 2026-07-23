# SecurityPositionManager

**完整名称**: `ATAS.DataFeedsCore.SecurityPositionManager`
**类型**: 类
**继承自**: `ATAS.DataFeedsCore.ISecurityPositionManager`

## 公共方法

  - ` SecurityPositionManager(ILoggerSource logger, Position position)`
  - `void Clear()`
  - `bool GetIsChanged()`
  - `bool GetIsNeedSubscribeLevel1()`
  - `bool Update(decimal? volume=null, decimal? averagePrice=null, decimal? openedPnL=null, decimal? closedPnL=null, decimal? commission=null, decimal? openVolume=null, RiskInfo? risk=null)`
  - `bool UpdateAveragePriceByTrades()`
  - `bool UpdateOpenPnL(Security security, MarketDataType type, decimal price)`
  - `bool Process(Order order)`
  - `bool Process(MyTrade trade)`
  - `void SetAveragePrice(decimal avgPrice)`
  - `void Clear()`
  - `bool GetIsChanged()`
  - `bool GetIsNeedSubscribeLevel1()`
  - `bool Update(decimal? volume=null, decimal? averagePrice=null, decimal? openedPnL=null, decimal? closedPnL=null, decimal? commission=null, decimal? openVolume=null, RiskInfo? risk=null)`
  - `bool UpdateAveragePriceByTrades()`
  - `bool UpdateOpenPnL(Security security, MarketDataType type, decimal price)`
  - `bool Process(Order order)`
  - `bool Process(MyTrade trade)`
  - `void SetAveragePrice(decimal avgPrice)`

## 保护方法

  - `virtual bool UpdateUnrealizedPnl(MarketDataType type, decimal price)`
  - `virtual decimal GetPnlMultiplier()`

## 属性

  - `Position Position { get; }`
  - `bool IsPositionInitialized { get; }`
  - `PositionAveragePriceValueTypes AveragePriceValueType { set; }`
  - `decimal AveragePrice { set; }`
  - `decimal Volume { set; }`
  - `bool CalculateVolume { set; }`
  - `bool CalculateAveragePrice { set; }`
  - `bool CalculateOpenedPnL { set; }`
  - `bool CalculateClosedPnL { set; }`
  - `bool AllowSubscribeLevel1 { set; }`
  - `Position Position { get; }`
  - `bool IsPositionInitialized { get; }`
