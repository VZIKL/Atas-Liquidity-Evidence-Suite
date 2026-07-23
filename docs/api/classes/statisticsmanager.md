# StatisticsManager

**完整名称**: `ATAS.DataFeedsCore.Statistics.StatisticsManager`
**类型**: 类

## 公共方法

  - ` StatisticsManager()`
  - `virtual void Clear(bool clearTradesQueue=false)`
  - `virtual void Process(Order order)`
  - `virtual void Process(MyTrade trade)`

## 保护方法

  - `virtual void UpdateStatistics(HistoryMyTrade trade)`
  - `virtual void Add(Order order)`
  - `virtual void Add(MyTrade trade)`
  - `void AddToStatistics(MyTrade trade)`
  - `virtual void OnPropertyChanged(string propertyName)`

## 属性

  - `ThreadSafeObservableCollection< HistoryMyTrade > HistoryMyTrades { get; }`
  - `ThreadSafeObservableCollection< Order > Orders { get; }`
  - `ThreadSafeObservableCollection< MyTrade > MyTrades { get; }`
  - `ThreadSafeObservableCollection< IStatisticsParameterGroup > Statistics { get; }`
  - `ThreadSafeObservableCollection< KeyValuePair< DateTime, PnlTuple > > Equity { get; }`

## 事件

  - `event PropertyChangedEventHandler PropertyChanged`
