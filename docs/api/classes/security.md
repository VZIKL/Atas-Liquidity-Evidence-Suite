# Security

**完整名称**: `ATAS.DataFeedsCore.Security`
**类型**: 类
**继承自**: `ATAS.DataFeedsCore.IEntity`

## 描述

Represents a security entity used in the application.

## 公共方法

  - ` Security()`
    - Initializes a new instance of the Security class with default values.
  - `override string ToString()`
    - Returns a string representation of the security, using either the instrument name or the combination of code and exchange.

## 保护方法

  - `void OnPropertyChanged(string name)`
    - Raises the PropertyChanged event with the specified property name.

## 属性

  - `EntityType EntityType { get; }`
  - `string SecurityId { set; }`
    - Global ATAS security identifier like BCHUSDT@Bybit. Includes exchange id.
  - `string ConnectorId { set; }`
    - Gets or sets the connector identifier associated with the security.
  - `string Code { set; }`
    - Id of the security May have any format like CLK4 or BCHUSDT etc.
  - `string Exchange { set; }`
    - Gets or sets the exchange associated with the security.
  - `string Instrument { set; }`
    - Gets or sets the instrument associated with the security.
  - `DateTime Expiration { set; }`
    - Gets or sets the expiration date of the security.
  - `SecType Type { set; }`
    - Gets or sets the type of security or financial instrument.
  - `decimal TickSize { set; }`
    - Gets or sets the minimum price increment (tick size) for the security.
  - `decimal TickCost { set; }`
    - Price of a single tickSize.
  - `decimal LotSize { set; }`
    - Minimum volume increment.
  - `decimal? LotMinSize { set; }`
    - Minimum size (volume) for the order.
  - `decimal? LotMaxSize { set; }`
    - Maximum size (volume) for the order.
  - `int Digits { get; }`
    - Gets the number of decimal digits used for formatting prices.
  - `decimal MinPrice { set; }`
    - Gets or sets the minimum price allowed for the security.
  - `decimal MaxPrice { set; }`
    - Gets or sets the maximum price allowed for the security.
  - `decimal MarginBuy { set; }`
    - Gets or sets the margin buy value for the security.
  - `decimal MarginSell { set; }`
    - Gets or sets the margin sell value for the security.
  - `long Id { set; }`
    - Gets or sets the identifier of the security.
  - `long IsinId { set; }`
    - Gets or sets the International Securities Identification Number (ISIN) identifier of the security.
  - `decimal BestAskPrice { set; }`
    - Gets or sets the best asking price for the security.
  - `decimal BestAskVolume { set; }`
    - Gets or sets the volume available at the best asking price for the security.
  - `decimal BestBidPrice { set; }`
    - Gets or sets the best bidding price for the security.
  - `decimal BestBidVolume { set; }`
    - Gets or sets the volume available at the best bidding price for the security.
  - `decimal? LastTradePrice { set; }`
    - Price of the last tick This value may be null if no ticks were received yet.
  - `decimal? LastTradeVolume { set; }`
    - Volume of the last tick This value may be null if no ticks were received yet.
  - `decimal PriceMultiplier { set; }`
    - Gets or sets the price multiplier for the security.
  - `decimal VolumeMultiplier { set; }`
    - Gets or sets the volume multiplier for the security.
  - `decimal? OpenInterest { set; }`
    - Gets or sets the open interest value for the security.
  - `decimal? MarkPrice { set; }`
    - A price that reflects the real-time spot price on the major exchanges.
  - `decimal? FundingRate { set; }`
    - Gets funding rate exchanged between buyers and sellers. During the funding rate cycle.
  - `DateTimeOffset? NextFundingTime { set; }`
    - Gets time of the next funding cycle.
  - `string? BaseCurrency { set; }`
    - First currency of the trading pair, order volume must be sent in this currency.
  - `string? QuoteCurrency { set; }`
    - Second currency of the trading pair, if set you can use it for convert operations.
  - `decimal? QuoteCurrencyPrecision { set; }`
    - Minimum step for quote currency (ex: 0.01 for USD, 0.00000001 for BTC).
  - `string MoneyPnLFormat { set; }`
    - Gets or sets money PnL format for security.
  - `object? Parent { set; }`
    - Gets or sets connector entity the security was created from.
  - `bool IsInverseFutures { set; }`
    - Security is an inverse futures.
  - `Exchange? ExchangeInstance { set; }`
    - The object that represents the exchange where the security is listed.
  - `decimal? StrikePrice { set; }`
    - A strike price of option contract.
  - `OptionTypes? OptionType { set; }`
    - Gets or sets the type of option contract.
  - `Security? UnderlyingSecurity { set; }`
    - An underlying security of option contract.
  - `EntityType EntityType { get; }`
    - Gets the type of the entity.
  - `decimal TickSize { get; }`
  - `decimal TickCost { get; }`
  - `int Digits { get; }`
  - `string Code { get; }`
  - `string Exchange { get; }`

## 事件

  - `event PropertyChangedEventHandler PropertyChanged`
