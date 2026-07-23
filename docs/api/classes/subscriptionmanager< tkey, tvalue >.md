# SubscriptionManager< TKey, TValue >

**完整名称**: `ATAS.DataFeedsCore.SubscriptionManager< TKey, TValue >`
**类型**: 类

## 公共方法

  - `IEnumerable< TValue > Add(TKey key, TValue session)`
  - `IEnumerable< TValue > Remove(TKey key, TValue session)`
  - `void Remove(TValue value)`
  - `IEnumerable< TValue > Get(TKey key)`
  - `IEnumerable< TKey > Get(TValue value)`
  - `IEnumerable< Tuple< TKey, TValue > > GetAll()`
