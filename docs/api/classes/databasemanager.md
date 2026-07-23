# DatabaseManager

**完整名称**: `ATAS.DataFeedsCore.Database.DatabaseManager`
**类型**: 类
**继承自**: `ATAS.DataFeedsCore.Database.IDatabaseManager`

## 公共方法

  - ` DatabaseManager(string configurationName)`
  - ` DatabaseManager(string providerName, string connectionString)`
  - ` DatabaseManager(DataProviderBase provider, string connectionString)`
  - `double? Initialize()`
  - `long? GetCommissionGroupByPortfolio(string accountId)`
  - `long? GetCommissionGroupByPortfolio(string accountId)`
  - `double? Initialize()`
  - `int Delete< TEntity >(TEntity entity)`
  - `void BeginTransaction()`
  - `void CommitTransaction()`
  - `void RollbackTransaction()`

## 属性

  - `long LastExtId { get; }`
  - `long LastOrderId { get; }`
  - `long LastTradeId { get; }`
  - `IQueryable< Security > Securities { get; }`
  - `IQueryable< Portfolio > Portfolios { get; }`
  - `IQueryable< Position > Positions { get; }`
  - `IQueryable< Order > Orders { get; }`
  - `IQueryable< MyTrade > MyTrades { get; }`
  - `IQueryable< User > Users { get; }`
  - `IQueryable< UserRole > UserRoles { get; }`
  - `IQueryable< UserRoleRight > UserRoleRights { get; }`
  - `IQueryable< UserGroup > UserGroups { get; }`
  - `IQueryable< GroupExchange > GroupExchanges { get; }`
  - `IQueryable< CommissionGroup > CommissionGroups { get; }`
  - `IQueryable< HistoryMyTrade > HistoryMyTrades { get; }`
  - `IQueryable< SettingsItem > Settings { get; }`
  - `IQueryable< Exchange > Exchanges { get; }`
  - `IQueryable< WorkingTime > WorkingTimes { get; }`
  - `IQueryable< SecurityMargin > SecurityMargins { get; }`
  - `IQueryable< News > News { get; }`
  - `IQueryable< TradingOptions > TradingOptions { get; }`
  - `IQueryable< TradingOptionsSecurity > TradingOptionsSecurities { get; }`
  - `IQueryable< CommissionGroupItem > CommissionGroupItems { get; }`
  - `IQueryable< PortfolioChange > PortfolioChanges { get; }`
  - `IQueryable< PortfolioState > PortfolioStates { get; }`
  - `IQueryable< PositionState > PositionStates { get; }`
  - `IQueryable< SecurityRoute > SecurityRoutes { get; }`
  - `IQueryable< PortfolioViewer > PortfolioViewers { get; }`
  - `IQueryable< PortfolioGroup > PortfolioGroups { get; }`
  - `IQueryable< ServerPnL > ServerPnL { get; }`
  - `IQueryable< InstrumentExchange > InstrumentExchanges { get; }`
  - `IQueryable< OvernightSwapValue > OvernightSwapValues { get; }`
  - `long LastExtId { get; }`
  - `long LastOrderId { get; }`
  - `long LastTradeId { get; }`
  - `IQueryable< Security > Securities { get; }`
  - `IQueryable< Portfolio > Portfolios { get; }`
  - `IQueryable< Position > Positions { get; }`
  - `IQueryable< Order > Orders { get; }`
  - `IQueryable< MyTrade > MyTrades { get; }`
  - `IQueryable< User > Users { get; }`
  - `IQueryable< UserRole > UserRoles { get; }`
  - `IQueryable< UserRoleRight > UserRoleRights { get; }`
  - `IQueryable< UserGroup > UserGroups { get; }`
  - `IQueryable< GroupExchange > GroupExchanges { get; }`
  - `IQueryable< CommissionGroup > CommissionGroups { get; }`
  - `IQueryable< HistoryMyTrade > HistoryMyTrades { get; }`
  - `IQueryable< SettingsItem > Settings { get; }`
  - `IQueryable< Exchange > Exchanges { get; }`
  - `IQueryable< WorkingTime > WorkingTimes { get; }`
  - `IQueryable< SecurityMargin > SecurityMargins { get; }`
  - `IQueryable< News > News { get; }`
  - `IQueryable< TradingOptions > TradingOptions { get; }`
  - `IQueryable< TradingOptionsSecurity > TradingOptionsSecurities { get; }`
  - `IQueryable< CommissionGroupItem > CommissionGroupItems { get; }`
  - `IQueryable< PortfolioChange > PortfolioChanges { get; }`
  - `IQueryable< PortfolioState > PortfolioStates { get; }`
  - `IQueryable< PositionState > PositionStates { get; }`
  - `IQueryable< SecurityRoute > SecurityRoutes { get; }`
  - `IQueryable< PortfolioViewer > PortfolioViewers { get; }`
  - `IQueryable< PortfolioGroup > PortfolioGroups { get; }`
  - `IQueryable< ServerPnL > ServerPnL { get; }`
  - `IQueryable< InstrumentExchange > InstrumentExchanges { get; }`
