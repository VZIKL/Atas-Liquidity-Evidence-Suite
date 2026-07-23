# StatisticsParameter

**完整名称**: `ATAS.DataFeedsCore.Statistics.StatisticsParameter`
**类型**: 类
**继承自**: `ATAS.DataFeedsCore.Statistics.IStatisticsParameter`

## 公共方法

  - `void Process(HistoryMyTrade trade)`
  - `void Clear()`
  - `void Clear()`
  - `void Process(HistoryMyTrade trade)`

## 保护方法

  - `abstract decimal OnProcess(HistoryMyTrade trade)`
  - `virtual void OnClear()`
  - `virtual void OnPropertyChanged(string propertyName)`

## 属性

  - `string Name { get; }`
  - `decimal Value { get; }`
  - `string Name { get; }`
  - `decimal Value { get; }`

## 事件

  - `event PropertyChangedEventHandler PropertyChanged`
