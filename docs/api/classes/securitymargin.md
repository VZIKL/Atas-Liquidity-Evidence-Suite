# SecurityMargin

**完整名称**: `ATAS.DataFeedsCore.SecurityMargin`
**类型**: 类
**继承自**: `ATAS.DataFeedsCore.IEntity`

## 公共方法

  - ` SecurityMargin()`
  - ` SecurityMargin(string securityId, decimal defaultValue)`
  - `SecurityMargin GetSecurityMargin(string securityId)`
  - `override string ToString()`
    - Returns a string that represents the current object.

## 保护方法

  - `virtual void OnPropertyChanged(string propertyName)`

## 属性

  - `string SecurityId { set; }`
  - `bool IsContract { set; }`
  - `Security Security { set; }`
  - `DateTime Date { set; }`
  - `decimal IntradayInitialMarginBuy { set; }`
  - `decimal IntradayInitialMarginSell { set; }`
  - `decimal IntradayMarginBuy { set; }`
  - `decimal IntradayMarginSell { set; }`
  - `decimal InitialMarginBuy { set; }`
  - `decimal InitialMarginSell { set; }`
  - `decimal MarginBuy { set; }`
  - `decimal MarginSell { set; }`
  - `EntityType EntityType { get; }`
    - Gets the type of the entity.
  - `EntityType EntityType { get; }`
    - Gets the type of the entity.

## 事件

  - `event PropertyChangedEventHandler PropertyChanged`
