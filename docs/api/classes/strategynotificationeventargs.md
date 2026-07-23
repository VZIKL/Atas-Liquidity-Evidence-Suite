# StrategyNotificationEventArgs

**完整名称**: `ATAS.Strategies.StrategyNotificationEventArgs`
**类型**: 类

## 描述

Provides data for the StrategyNotification event.

## 公共方法

  - ` StrategyNotificationEventArgs(IStrategy strategy, string message, string title, bool isError)`
    - Initializes a new instance of the StrategyNotificationEventArgs class with the specified strategy, message, title, and error status.

## 属性

  - `IStrategy Strategy { get; }`
    - Gets the strategy associated with the notification.
  - `string Message { get; }`
    - Gets the message of the notification.
  - `string Title { get; }`
    - Gets the title of the notification.
  - `bool IsError { get; }`
    - Gets a value indicating whether the notification is an error.
