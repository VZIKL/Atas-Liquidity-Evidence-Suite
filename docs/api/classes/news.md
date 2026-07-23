# News

**完整名称**: `ATAS.DataFeedsCore.News`
**类型**: 类
**继承自**: `ATAS.DataFeedsCore.IEntity`

## 公共方法

  - `override string ToString()`
    - Returns a string that represents the current object.

## 保护方法

  - `virtual void OnPropertyChanged(string propertyName)`

## 属性

  - `long Id { set; }`
  - `string AccountID { set; }`
  - `NewsType Type { set; }`
  - `DateTime Time { set; }`
  - `string Source { set; }`
  - `string Title { set; }`
  - `string Text { set; }`
  - `bool IsHandled { set; }`
  - `long UserId { set; }`
  - `User User { set; }`
  - `EntityType EntityType { get; }`
    - Gets the type of the entity.
  - `EntityType EntityType { get; }`
    - Gets the type of the entity.

## 事件

  - `event PropertyChangedEventHandler PropertyChanged`
