# HistoryMyTrade

**完整名称**: `ATAS.DataFeedsCore.HistoryMyTrade`
**类型**: 类

## 描述

Represents a historical trade record.

## 公共方法

  - `HistoryMyTrade Clone()`
  - `override string ToString()`

## 保护方法

  - `virtual void OnPropertyChanged(string propertyName)`
    - Raises the PropertyChanged event for a specific property.

## 属性

  - `long Id { set; }`
    - Gets or sets the unique identifier of the historical trade.
  - `string AccountID { set; }`
    - Gets or sets the account ID associated with the historical trade.
  - `string SecurityId { set; }`
    - Gets or sets the security ID associated with the historical trade.
  - `string SecurityCode { set; }`
    - Gets or sets the security code associated with the historical trade.
  - `Security Security { set; }`
    - Gets or sets the security object associated with the historical trade.
  - `Portfolio Portfolio { set; }`
    - Gets or sets the portfolio object associated with the historical trade.
  - `DateTime OpenTime { set; }`
    - Gets or sets the open time of the historical trade.
  - `decimal OpenPrice { set; }`
    - Gets or sets the open price of the historical trade.
  - `decimal OpenVolume { set; }`
    - Gets or sets the open volume of the historical trade.
  - `DateTime CloseTime { set; }`
    - Gets or sets the close time of the historical trade.
  - `decimal ClosePrice { set; }`
    - Gets or sets the close price of the historical trade.
  - `decimal CloseVolume { set; }`
    - Gets or sets the close volume of the historical trade.
  - `decimal PnL { set; }`
    - Gets or sets the profit and loss (PnL) of the historical trade.
  - `decimal TicksPnL { set; }`
    - Gets or sets the PnL in ticks of the historical trade.
  - `decimal PricePnL { set; }`
    - Gets or sets the PnL in price units of the historical trade.
  - `decimal? Commission { set; }`
    - Gets or sets the commission associated with the historical trade.
  - `string Comment { set; }`
    - Gets or sets the comment associated with the historical trade.
  - `bool Reviewed { set; }`
  - `MyTrade EnterTrade { set; }`
    - Gets or sets the enter trade associated with the historical trade.
  - `MyTrade ExitTrade { set; }`
    - Gets or sets the exit trade associated with the historical trade.
  - `MissingDataCases MissingDataCase { set; }`
    - Indicates what part of the trade is missing.
  - `bool IsComplete { get; }`
  - `List< Playbook > Playbooks { set; }`

## 事件

  - `event PropertyChangedEventHandler PropertyChanged`
