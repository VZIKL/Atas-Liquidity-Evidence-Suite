# TradesMatchingProcessor

**完整名称**: `ATAS.DataFeedsCore.TradeStatistics.Matching.TradesMatchingProcessor`
**类型**: 类
**继承自**: `ATAS.DataFeedsCore.TradeStatistics.Matching.TradesProcessingUnit`

## 公共方法

  - ` TradesMatchingProcessor(HistoryProvider getHistory, PortfolioSecurity portfolioSecurity, IDataFeedConnector? connector=null, IReadOnlyCollection< MyTrade >? unprocessedTrades=null, decimal lastKnownPos=default, bool forceRecovery=false, IProgress< double >? progressCounter=null, TimeProvider? timeProvider=null)`
  - `override int GetHashCode()`
  - `override bool Equals(object? obj)`
  - `void Start()`
  - `void Process(MyTrade trade)`
  - `void Process(Position position)`
  - `override void Update(Portfolio portfolio)`
  - `override void Update(Security security)`
  - ` TradesProcessingUnit(PortfolioSecurity portfolioSecurity)`
  - `virtual void Update(Portfolio portfolio)`
  - `virtual void Update(Security security)`
  - `void Dispose()`

## 保护方法

  - `override void OnDispose()`
  - `virtual void OnDispose()`
  - `void LogDebug(string message, params object[] args)`
  - `void LogInfo(string message, params object[] args)`
  - `void LogWarn(string message, params object[] args)`
  - `void LogError(string message, Exception e)`

## 属性

  - `IDataFeedConnector? Connector { set; }`
  - `TimeSpan? HistoryReceptionCompletionPeriod { set; }`
  - `TimeSpan TradesPositionsSyncTimeout { set; }`
  - `Action? Balanced `
  - `bool Disposed { get; }`
  - `PortfolioSecurity PortfolioSecurity { get; }`
  - `PortfolioSecurityKey PortfolioSecurityKey { get; }`

## 事件

  - `event Action< HistoryMyTrade >? NewTrade`
  - `event Action? HistoryCalculationCompleted`
  - `event Action< Task >? PendingData`
  - `event readonly object _sync`
  - `event string? _prefix`
