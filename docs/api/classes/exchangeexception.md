# ExchangeException

**完整名称**: `ATAS.DataFeedsCore.Exceptions.ExchangeException`
**类型**: 类

## 描述

An exception means the Exchange sent us an logic error like violating business rules It allows us to separate network errors and logic errors.

## 公共方法

  - ` ExchangeException(Exception innerException)`
  - ` ExchangeException(string originalMessage, Exception? innerException=null)`
  - ` ExchangeException(string originalMessage, string displayText, Exception? innerException=null)`

## 属性

  - `string DisplayText { set; }`
