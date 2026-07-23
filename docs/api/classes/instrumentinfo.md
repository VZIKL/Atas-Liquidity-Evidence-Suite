# InstrumentInfo

**完整名称**: `ATAS.Indicators.InstrumentInfo`
**类型**: 类
**继承自**: `ATAS.Indicators.IInstrumentInfo`

## 描述

Implementation of the IInstrumentInfo interface representing instrument information.

## 公共方法

  - ` InstrumentInfo(string instrument, string exchange, decimal tickSize, int timeZone)`
    - Constructor to create an InstrumentInfo object with the specified parameters.

## 属性

  - `string Instrument { get; }`
    - Gets the name of the instrument.
  - `string Exchange { get; }`
    - Gets the name of the exchange where the instrument is traded.
  - `decimal TickSize { get; }`
    - Gets the tick size of the instrument, which is the minimum price movement.
  - `int TimeZone { set; }`
    - Gets the time zone of the instrument.
  - `string Instrument { get; }`
    - Gets the name of the instrument.
  - `string Exchange { get; }`
    - Gets the name of the exchange where the instrument is traded.
  - `decimal TickSize { get; }`
    - Gets the tick size of the instrument, which is the minimum price movement.
  - `int TimeZone { get; }`
    - Gets the time zone of the instrument.
