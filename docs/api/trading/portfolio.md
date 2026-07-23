# Portfolio

**完整名称**: `ATAS.DataFeedsCore.Portfolio`
**类型**: 类
**继承自**: `ATAS.DataFeedsCore.IEntity`

## 描述

Represents a portfolio entity with various properties related to account balance, Profit and Loss (PnL), permissions, trading options, and more.

## 公共方法

  - ` Portfolio()`
    - Initializes a new instance of the Portfolio class with default values.
  - `Portfolio Clone()`
    - Creates a new instance of the Portfolio class that is a shallow copy of the current instance.
  - `override string ToString()`
    - Returns a string representation of the portfolio group, including various account-related information.

## 保护方法

  - `void OnPropertyChanged(string name)`
    - Raises the PropertyChanged event with the specified property name.

## 属性

  - `string AccountID { set; }`
  - `string DepoName { set; }`
    - Gets or sets the name of the deposit for the portfolio.
  - `Currencies? Currency { set; }`
    - Gets or sets the currency associated with the portfolio.
  - `TPlusLimits? TPlusLimit { set; }`
    - Gets or sets the T+ limits for the portfolio.
  - `ConnectionStates? ConnectionState { set; }`
    - Gets or sets the connection state of the portfolio.
  - `decimal Balance { set; }`
    - Gets or sets the total available funds that the user can use right now to make an order.
  - `decimal BlockedMargin { set; }`
    - Gets or sets the amount of funds that are blocked by current open positions and not included in the BalanceAvailable.
  - `decimal Leverage { set; }`
    - Gets or sets the leverage of the portfolio.
  - `decimal BalancePower { set; }`
    - Gets or sets the balance according to the leverage (on leverage x2, it will be two times bigger).
  - `decimal? BalanceAvailable { set; }`
    - Gets or sets the balance excluding the BlockedMargin.
  - `decimal OpenPnL { set; }`
    - Gets or sets the opened Profit and Loss (PnL) of the portfolio. The opened PnL represents the unrealized gains or losses from currently open positions.
  - `decimal ClosedPnL { set; }`
    - Gets or sets the closed Profit and Loss (PnL) of the portfolio. The closed PnL represents the realized gains or losses from closed positions.
  - `decimal TotalClosedPnL { set; }`
    - Gets or sets the total closed Profit and Loss (PnL) of the portfolio. The total closed PnL is the cumulative realized gains or losses from all closed positions.
  - `decimal TotalPnL { get; }`
    - Gets the total Profit and Loss (PnL) of the portfolio. The total PnL is the sum of both the opened PnL and the total closed PnL.
  - `decimal MaxEquityValue { set; }`
    - Gets or sets the maximum equity value of the portfolio. The maximum equity value represents the highest value of the portfolio's equity over time.
  - `bool IsLocked { set; }`
  - `bool IsSuspended { set; }`
    - Gets or sets a value indicating whether the trading options are suspended.
  - `long? TradingOptionsId { set; }`
    - Gets or sets the ID of the associated trading options for the portfolio.
  - `TradingOptions TradingOptions { set; }`
  - `CommissionRulesGroup CommissionRulesGroup { set; }`
    - Gets or sets the commission rules group associated with the portfolio. The commission rules group is represented by an object of the CommissionRulesGroup class. This property is not visible in the user interface (Browsable(false)).
  - `string CommissionState { set; }`
    - Gets or sets the state of the commission for the portfolio.
  - `decimal Commission { set; }`
    - Gets or sets the commission value for the portfolio.
  - `DateTime ClosedPnlDate { set; }`
    - Gets or sets the date of the closed profit and loss (PnL).
  - `object Data { set; }`
    - Gets or sets additional data associated with the portfolio.
  - `IPortfolioExtendedInfo? ExtendedInfo { set; }`
    - Gets or sets the extended portfolio information specific to the connector. Each connector can provide its own implementation with unique parameters.
  - `bool IsAdviserPortfolio { set; }`
    - Gets or sets a flag indicating whether the portfolio is associated with an adviser portfolio.
  - `string FcmId { set; }`
    - Gets or sets the FCM ID (Futures Commission Merchant ID) associated with the portfolio.
  - `string IbId { set; }`
    - Gets or sets the IB ID (Interactive Brokers ID) associated with the portfolio.
  - `int ActiveOrders { set; }`
    - Gets or sets the number of active orders associated with the portfolio.
  - `int AtasId { set; }`
    - Gets or sets the ATAS ID associated with the portfolio.
  - `bool IsRealAccount { set; }`
    - Gets or sets a flag indicating whether the portfolio is associated with a real account.
  - `long UserId { set; }`
    - Gets or sets the ID of the user associated with the portfolio.
  - `User User { set; }`
    - Gets or sets the user associated with the portfolio.
  - `List< PortfolioViewer > Viewers { get; }`
    - Gets the list of portfolio viewers associated with the portfolio.
  - `List< PortfolioGroup > Accounts { get; }`
    - Gets a list of portfolio groups associated with the portfolio.
  - `DateTime? ProcessedTradeTime { set; }`
    - Gets or sets the date and time when the trades for the portfolio were last processed.
  - `string? StatisticsUrl { set; }`
    - Url to get trading statistics for this account.
  - `EntityType EntityType { get; }`
  - `EntityType EntityType { get; }`
    - Gets the type of the entity.

## 事件

  - `event PropertyChangedEventHandler PropertyChanged`
