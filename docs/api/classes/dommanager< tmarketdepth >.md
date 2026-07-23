# DomManager< TMarketDepth >

**完整名称**: `ATAS.DataFeedsCore.Dom.DomManager< TMarketDepth >`
**类型**: 类
**继承自**: `ATAS.DataFeedsCore.Dom.IDomManager< TMarketDepth >`

## 描述

Maintains Depth of Market state for the security. Type Constraints TMarketDepth :class TMarketDepth :IMarketDepth TMarketDepth :new()

## 公共方法

  - `void Clear()`
  - `void Update(TMarketDepth depth)`
  - `IReadOnlyCollection< TMarketDepth > Update(IReadOnlyCollection< TMarketDepth > depths)`
  - `TMarketDepth UpdateLevel1(TMarketDepth depth)`
  - `SortedDictionary< decimal, TMarketDepth > CloneState(MarketDataType side)`
  - `IEnumerable< TMarketDepth > RemoveOverlappingQuotes()`
  - `void Clear()`
  - `IReadOnlyCollection< TMarketDepth > Update(IReadOnlyCollection< TMarketDepth > depths)`
  - `TMarketDepth UpdateLevel1(TMarketDepth depth)`

## 属性

  - `SyncRoot SyncRoot { get; }`
  - `int Count { get; }`
  - `IEnumerable< TMarketDepth > Asks { get; }`
  - `IEnumerable< TMarketDepth > Bids { get; }`
  - `IEnumerable< TMarketDepth > All { get; }`
  - `TMarketDepth? BestBid { get; }`
  - `TMarketDepth? BestAsk { get; }`
  - `SyncRoot SyncRoot { get; }`
  - `IEnumerable< TMarketDepth > Asks { get; }`
  - `IEnumerable< TMarketDepth > Bids { get; }`
  - `IEnumerable< TMarketDepth > All { get; }`
