# TradesProcessingUnit

**完整名称**: `ATAS.DataFeedsCore.TradeStatistics.Matching.TradesProcessingUnit`
**类型**: 类
**继承自**: `ATAS.DataFeedsCore.TradeStatistics.Matching.TradesProcessingLoggerSource`

## 公共方法

  - ` TradesProcessingUnit(PortfolioSecurity portfolioSecurity)`
  - `virtual void Update(Portfolio portfolio)`
  - `virtual void Update(Security security)`
  - `void Dispose()`

## 保护方法

  - `virtual void OnDispose()`
  - `void LogDebug(string message, params object[] args)`
  - `void LogInfo(string message, params object[] args)`
  - `void LogWarn(string message, params object[] args)`
  - `void LogError(string message, Exception e)`
  - `readonly object _sync()`
  - `string? _prefix()`

## 属性

  - `bool Disposed { get; }`
  - `PortfolioSecurity PortfolioSecurity { get; }`
  - `PortfolioSecurityKey PortfolioSecurityKey { get; }`
