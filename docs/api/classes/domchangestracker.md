# DomChangesTracker

**完整名称**: `ATAS.DataFeedsCore.Dom.DomBuilder.DomChangesTracker`
**类型**: 类

## 公共方法

  - `void TrackChange(MarketDepth md)`
  - `List< MarketDepth > GetChanges()`

## 属性

  - `MarketDepth? NewBestAsk { get; }`
    - Changed new best ASK value or null if value didn't change.
  - `MarketDepth? NewBestBid { get; }`
    - Changed new best BID value or null if value didn't change.
