# Exchange

**完整名称**: `ATAS.DataFeedsCore.Exchange`
**类型**: 类
**继承自**: `ATAS.DataFeedsCore.IEntity`

## 公共方法

  - ` Exchange()`
  - `bool IsWorkingTime(DateTime time)`
  - `bool IsNewSession(DateTime prevTime, DateTime newTime)`
  - `bool IsNewWeek(DateTime prevTime, DateTime newTime)`
  - `bool IsNewMonth(DateTime prevTime, DateTime newTime)`
  - `WorkingTime GetWorkingTime(DateTime time)`
  - `DateTime? GetNextSessionOpen(DateTime time)`
  - `DateTime? GetPreviousSessionClose(DateTime time)`
  - `DateTime?? DateTime MaxTradedTime TrimToMinTradedRange(DateTime from, DateTime to)`
  - `Tuple< DateTime, DateTime > GetWorkingDateTime(DateTime time)`
  - `DateTime ToLocalTime(DateTime time)`
  - `DateTime ToUtcTime(DateTime time)`
  - `Exchange Clone()`
  - `override string ToString()`
    - Returns a string that represents the current object.
  - `bool IsNewSession(DateTime prevTime, DateTime newTime)`
  - `bool IsNewWeek(DateTime prevTime, DateTime newTime)`
  - `bool IsNewMonth(DateTime prevTime, DateTime newTime)`
  - `DateTime? MinTradedTime()`

## 保护方法

  - `virtual void OnPropertyChanged(string propertyName)`

## 属性

  - `string Code { set; }`
  - `string ExchangeCode { set; }`
  - `string Name { set; }`
  - `string Country { set; }`
  - `string TimeZone { set; }`
  - `TimeZoneInfo TimeZoneInfo { set; }`
  - `List< WorkingTime > WorkingTimes { set; }`
  - `bool ConvertTradeTimeToLocal { set; }`
  - `DayOfWeek FirstDayOfWeek { set; }`
  - `bool IsSystemExchange { set; }`
  - `EntityType EntityType { get; }`
    - Gets the type of the entity.
  - `EntityType EntityType { get; }`
    - Gets the type of the entity.

## 事件

  - `event PropertyChangedEventHandler PropertyChanged`
