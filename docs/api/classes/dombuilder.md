# DomBuilder

**完整名称**: `ATAS.DataFeedsCore.Dom.DomBuilder`
**类型**: 类

## 描述

Builds and maintains a DOM for a connector Allows to obtain best prices if connector does not give them This class is intended to use in thread safe environment

## 公共方法

  - `class DomChangesTracker()`
  - `Dictionary< decimal, MarketDepth >? GetDom(string securityCode)`
  - `ICollection< string > RecordedInstruments()`
  - `DomChangesTracker BeginChanges(string securityCode)`
    - Initiates changes in the DOM by returning a special object DomChangesTracker After tracking, call GetChanges() to commit all changes to the parent dom builder.
  - `void Clear()`
  - `void Clear(string securityCode)`
  - `MarketDepth?? MarketDepth BestAsk GetBestPricesFor(string securityCode)`
  - `MarketDepth? BestBid()`
    - Returns a tuple of best Bid and Ask prices, or null Double nulls are possible if no DOM were loaded yet.
