# MarketByOrdersManager

**完整名称**: `ATAS.DataFeedsCore.MarketByOrdersManager`
**类型**: 类
**继承自**: `ATAS.DataFeedsCore.IMarketByOrdersManager`

## 描述

Manager that provides access to market by order data.

## 公共方法

  - `void Update(IReadOnlyCollection< MarketByOrder > values)`
    - Update an snapshot of the current market by order data.

## 属性

  - `IEnumerable< MarketByOrder > MarketByOrders { get; }`
    - Gets a snapshot of the current market by order data.
  - `IEnumerable< MarketByOrder > MarketByOrders { get; }`
    - Gets a snapshot of the current market by order data.

## 事件

  - `event Action< IEnumerable< MarketByOrder > >? Changed`
  - `event Action< IEnumerable< MarketByOrder > >? Changed`
    - Event that is raised when real-time market by order data have changed.
