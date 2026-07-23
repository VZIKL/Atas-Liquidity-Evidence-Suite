# SecuritySummary

**完整名称**: `ATAS.DataFeedsCore.SecuritySummary`
**类型**: 类

## 公共方法

  - ` SecuritySummary()`
    - Initializes a new instance of the SecuritySummary class with default values.
  - ` SecuritySummary(Security security)`
    - Initializes a new instance of the SecuritySummary class with default values.

## 属性

  - `Security Security { get; }`
    - Gets or sets the security.
  - `decimal? BestAskPrice { set; }`
    - Gets or sets the best asking price for the security.
  - `decimal? BestAskVolume { set; }`
    - Gets or sets the volume available at the best asking price for the security.
  - `decimal? BestBidPrice { set; }`
    - Gets or sets the best bidding price for the security.
  - `decimal? BestBidVolume { set; }`
    - Gets or sets the volume available at the best bidding price for the security.
  - `decimal? LastTradePrice { set; }`
    - Price of the last tick This value may be null if no ticks were received yet.
  - `decimal? LastTradeVolume { set; }`
    - Volume of the last tick This value may be null if no ticks were received yet.
  - `decimal? SettlementPrice { set; }`
    - Gets or sets the settlement price value for the security.
  - `decimal? OpenInterest { set; }`
    - Gets or sets the open interest value for the security.
  - `decimal? CurrentDayOpenPrice { set; }`
    - Gets or sets the current day open price value for the security.
  - `decimal? CurrentDayHighPrice { set; }`
    - Gets or sets the current day high price value for the security.
  - `decimal? CurrentDayLowPrice { set; }`
    - Gets or sets the current day low price value for the security.
  - `decimal? CurrentDayTotalVolume { set; }`
    - Gets or sets the today trade volume value for the security.
  - `decimal? CurrentDayTurnover { set; }`
    - Gets or sets the today turnover for the security.
  - `decimal? PrevDayClosePrice { set; }`
    - Gets or sets the previous day close price value for the security.
  - `decimal? PrevDayTotalVolume { set; }`
    - Gets or sets the previous day trade volume value for the security.
  - `decimal? Last24OpenPrice { set; }`
    - Gets or sets the 24H open price value for the security.
  - `decimal? Last24HighPrice { set; }`
    - Gets or sets the 24H high price value for the security.
  - `decimal? Last24LowPrice { set; }`
    - Gets or sets the 24H low price value for the security.
  - `decimal? Last24TotalVolume { set; }`
    - Gets or sets the 24H trade volume value for the security.
  - `decimal? Last24Turnover { set; }`
    - Gets or sets the 24H turnover for the security.
  - `decimal? MarkPrice { set; }`
    - A price that reflects the real-time spot price on the major exchanges.
  - `decimal? FundingRate { set; }`
    - Gets funding rate exchanged between buyers and sellers. During the funding rate cycle.
  - `DateTimeOffset? NextFundingTime { set; }`
    - Gets time of the next funding cycle.
