# StatisticsParameterGroup< T >

**完整名称**: `ATAS.DataFeedsCore.Statistics.StatisticsParameterGroup< T >`
**类型**: 类
**继承自**: `ATAS.DataFeedsCore.Statistics.IStatisticsParameterGroup`

## 公共方法

  - ` StatisticsParameterGroup()`
  - `void Process(HistoryMyTrade trade)`
  - `void Clear()`
  - `void Process(HistoryMyTrade trade)`
  - `void Clear()`

## 保护方法

  - `virtual void OnPropertyChanged(string propertyName)`

## 属性

  - `string Name { get; }`
  - `Type Type { get; }`
  - `T Total { get; }`
  - `T Long { get; }`
  - `T Short { get; }`
  - `string Name { get; }`
  - `Type Type { get; }`
  - `IStatisticsParameter Total { get; }`
  - `IStatisticsParameter Long { get; }`
  - `IStatisticsParameter Short { get; }`

## 事件

  - `event PropertyChangedEventHandler? PropertyChanged`
