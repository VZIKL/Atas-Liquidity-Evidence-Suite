# PortfolioViewer

**完整名称**: `ATAS.DataFeedsCore.PortfolioViewer`
**类型**: 类

## 描述

Represents a portfolio viewer used in the application.

## 公共方法

  - `PortfolioViewer Clone()`
    - Creates a new instance of the PortfolioViewer class that is a shallow copy of the current instance.

## 属性

  - `long Id { set; }`
    - Gets or sets the ID of the portfolio viewer.
  - `string AccountId { set; }`
    - Gets or sets the account ID associated with the portfolio viewer.
  - `Portfolio Portfolio { set; }`
    - Gets or sets the portfolio associated with the portfolio viewer.
  - `long UserId { set; }`
    - Gets or sets the ID of the user associated with the portfolio viewer.
  - `User User { set; }`
    - Gets or sets the user associated with the portfolio viewer.
  - `DateTime? ProcessedTime { set; }`
    - Gets or sets the time when the portfolio viewer was last processed.
  - `bool IsDeleted { set; }`
    - Gets or sets a value indicating whether the portfolio viewer is marked as deleted.
