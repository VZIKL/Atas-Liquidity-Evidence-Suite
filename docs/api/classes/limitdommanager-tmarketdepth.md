# LimitDomManager< TMarketDepth >

**完整名称**: `ATAS.DataFeedsCore.Dom.LimitDomManager< TMarketDepth >`
**类型**: 类
**继承自**: `ATAS.DataFeedsCore.Dom.IDomManager< TMarketDepth >`

## 公共方法

  - `void Clear()`
  - `IReadOnlyCollection< TMarketDepth > Update(IReadOnlyCollection< TMarketDepth > depths)`
  - `TMarketDepth UpdateLevel1(TMarketDepth depth)`
  - `void Clear()`
  - `IReadOnlyCollection< TMarketDepth > Update(IReadOnlyCollection< TMarketDepth > depths)`
  - `TMarketDepth UpdateLevel1(TMarketDepth depth)`

## 属性

  - `SyncRoot SyncRoot { get; }`
  - `int DepthLevelsCount { set; }`
    - Gets or sets how many MarketDepth levels to store.
  - `IEnumerable< TMarketDepth > Asks { get; }`
  - `IEnumerable< TMarketDepth > Bids { get; }`
  - `IEnumerable< TMarketDepth > All { get; }`
  - `SyncRoot SyncRoot { get; }`
  - `IEnumerable< TMarketDepth > Asks { get; }`
  - `IEnumerable< TMarketDepth > Bids { get; }`
  - `IEnumerable< TMarketDepth > All { get; }`
