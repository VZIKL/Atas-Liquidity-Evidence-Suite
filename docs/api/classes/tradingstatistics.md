# TradingStatistics

**完整名称**: `ATAS.DataFeedsCore.Statistics.TradingStatistics`
**类型**: 类
**继承自**: `ATAS.DataFeedsCore.Statistics.ITradingStatistics`

## 公共方法

  - ` TradingStatistics()`
  - `void ClearHistoryMyTrades()`
  - `void Clear()`
  - `void Add(DailyNote note)`
  - `void Remove(DailyNote note)`
  - `void Add(Order order)`
  - `void Add(MyTrade trade)`
  - `void Add(HistoryMyTrade historyTrade)`
  - `void Update(HistoryMyTrade historyTrade)`
  - `void Update(Order order)`
  - `void RecalcMetrics()`

## 属性

  - `IMutableEnumerable< HistoryMyTrade > HistoryMyTrades { get; }`
  - `IMutableEnumerable< Order > Orders { get; }`
  - `IMutableEnumerable< MyTrade > MyTrades { get; }`
  - `IMutableEnumerable< IStatisticsParameterGroup > Statistics { get; }`
  - `IMutableEnumerable< EquityValue > Equity { get; }`
  - `IMutableEnumerable< DailyNote > DailyNotes { get; }`
  - `IMutableEnumerable< Order > Orders { get; }`
  - `IMutableEnumerable< MyTrade > MyTrades { get; }`
  - `IMutableEnumerable< HistoryMyTrade > HistoryMyTrades { get; }`
  - `IMutableEnumerable< DailyNote > DailyNotes { get; }`
  - `IMutableEnumerable< EquityValue > Equity { get; }`
  - `IMutableEnumerable< IStatisticsParameterGroup > Statistics { get; }`
