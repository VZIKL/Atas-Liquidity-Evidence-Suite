# Position

**完整名称**: `ATAS.DataFeedsCore.Position`
**类型**: 类
**继承自**: `ATAS.DataFeedsCore.IEntity`

## 描述

Represents a trading position.

## 公共方法

  - `Position Clone()`
    - Creates a deep copy of the current position.
  - `override string ToString()`

## 保护方法

  - `void OnPropertyChanged(string name)`
    - Raises the PropertyChanged event to notify subscribers that a property's value has changed.

## 属性

  - `string AccountID { set; }`
    - Gets or sets the unique identifier of the account associated with this position.
  - `string SecurityId { set; }`
    - Gets or sets the unique identifier of the security associated with this position.
  - `Portfolio Portfolio { set; }`
    - Gets or sets the portfolio associated with this position.
  - `Security Security { set; }`
    - Gets or sets the security associated with this position.
  - `TPlusLimits? TPlusLimit { set; }`
    - Gets or sets the T+ limit associated with this position, if applicable.
  - `PositionAveragePriceValueTypes AveragePriceValueType { set; }`
    - Gets or sets the type of value used to calculate the average price of the position.
  - `decimal AveragePrice { set; }`
    - Gets or sets the average price at which the position was acquired.
  - `decimal UnrealizedPnL { set; }`
    - Gets or sets the unrealized profit or loss associated with this position.
  - `decimal RealizedPnL { set; }`
    - Gets or sets the realized profit or loss associated with this position.
  - `decimal Volume { set; }`
    - Gets or sets the current volume of the position.
  - `decimal OpenVolume { set; }`
    - Gets or sets the open volume (unfilled quantity) of the financial instrument associated with this position.
  - `decimal CurrentBuy { set; }`
    - Gets or sets the current buy price for the financial instrument associated with this position.
  - `decimal CurrentSell { set; }`
    - Gets or sets the current sell price for the financial instrument associated with this position.
  - `bool IsInPosition { set; }`
    - Gets or sets whether the position is currently open (in position).
  - `object Parent { set; }`
    - Gets or sets the parent or container object associated with this position.
  - `decimal Commission { set; }`
    - Gets or sets the commission associated with this position.
  - `EntityType EntityType { get; }`
  - `PnlPercentType PnlPercentType { set; }`
    - Calculate pnl percent from portfolio balance or position margin.
  - `RiskInfo? Risk { set; }`
    - Gets or sets information about marginal trading options. Null if marginal trading is not supported.
  - `EntityType EntityType { get; }`
    - Gets the type of the entity.

## 事件

  - `event PropertyChangedEventHandler PropertyChanged`
