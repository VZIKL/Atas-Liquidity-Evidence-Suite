# SubscriptionCounter< T >

**完整名称**: `ATAS.DataFeedsCore.SubscriptionCounter< T >`
**类型**: 类

## 公共方法

  - `Dictionary< SubscriptionType, HashSet< T > > Add(IEnumerable< T > keys, SubscriptionType type)`
  - `SubscriptionType Add(T key, SubscriptionType type)`
  - `Dictionary< SubscriptionType, HashSet< T > > Remove(IEnumerable< T > keys, SubscriptionType type)`
  - `SubscriptionType Remove(T key, SubscriptionType type)`
  - `SubscriptionType Get(T key)`
  - `IDictionary< SubscriptionType, List< T > > Get(IEnumerable< T > keys)`
  - `bool Check(T key, SubscriptionType subscription)`
  - `T[] GetKeys()`
  - `bool Any()`
  - `void Clear()`
  - `bool Add()`
  - `bool Remove()`
