# IndicatorDataProvider

**完整名称**: `ATAS.Indicators.IndicatorDataProvider`
**类型**: 类
**继承自**: `ATAS.Indicators.IIndicatorDataProvider`

## 描述

Implementation of the IIndicatorDataProvider interface that provides access to various data and services related to an indicator.

## 公共方法

  - ` IndicatorDataProvider(ITradingStatisticsProvider tradingStatisticsProvider, IIndicatorServiceProvider indicatorServiceProvider, IOnlineDataProvider onlineDataProvider, IPlatformSettings platformSettings, IInstrumentInfo instrumentInfo, ITradingManager tradingManager, ICandleCreator candleCreator, IChart chartInfo)`
    - Initializes a new instance of the IndicatorDataProvider class.
  - `T GetService< T >()`
    - Resolves registered services.
  - `DateTime GetCustomStartTime(DateTime time, TimeSpan timeFrame)`
    - Gets custom candle begin time with specified timeframe and current time.Parameters time timeFrame Returnstrue if a new trading session has started; otherwise, false.
  - `bool IsNewSession(DateTime prevTime, DateTime newTime)`
    - Checks whether a new trading session has started between the specified previous time and new time.Parameters prevTimeThe previous time. newTimeThe new time. Returnstrue if a new trading session has started; otherwise, false.
  - `bool IsNewWeek(DateTime prevTime, DateTime newTime)`
    - Checks whether a new trading week has started between the specified previous time and new time.Parameters prevTimeThe previous time. newTimeThe new time. Returnstrue if a new trading week has started; otherwise, false.
  - `bool IsNewMonth(DateTime prevTime, DateTime newTime)`
    - Checks whether a new trading month has started between the specified previous time and new time.Parameters prevTimeThe previous time. newTimeThe new time. Returnstrue if a new trading month has started; otherwise, false.
  - `void AddAlert(string soundFile, string instrument, string message, CrossColor background, CrossColor foreground, DateTime? time=null)`
    - Adds an alert with the specified details to the indicator.
  - `void DoActionInGuiThread(Action action)`
    - Executes the specified action on the GUI thread.
  - `override string ToString()`
    - Returns the name of the indicator data provider.
  - `T GetService< T >()`
    - Resolves registered services.
  - `DateTime GetCustomStartTime(DateTime time, TimeSpan timeFrame)`
    - Gets custom candle begin time with specified timeframe and current time.
  - `bool IsNewSession(DateTime prevTime, DateTime newTime)`
    - Checks whether a new trading session has started between the specified previous time and new time.
  - `bool IsNewWeek(DateTime prevTime, DateTime newTime)`
    - Checks whether a new trading week has started between the specified previous time and new time.
  - `bool IsNewMonth(DateTime prevTime, DateTime newTime)`
    - Checks whether a new trading month has started between the specified previous time and new time.
  - `void AddAlert(string soundFile, string instrument, string message, CrossColor background, CrossColor foreground, DateTime? time=null)`
    - Adds an alert with the specified details to the indicator.
  - `void DoActionInGuiThread(Action action)`
    - Executes the specified action on the GUI thread.
  - `Action< Action >? OnNewGuiActionRequested()`
    - Gets or sets the action to request a new GUI action.
  - `const string NewPanel()`
    - Represents the name of a new panel.
  - `const string CandlesPanel()`
    - Represents the name of the candles panel on the chart.

## 属性

  - `string Name { get; }`
    - Gets or sets the name of the indicator data provider.
  - `IChart ChartInfo { get; }`
    - Gets the chart information associated with the indicator.
  - `IPlatformSettings GlobalPlatformSettings { get; }`
    - Gets or sets the global platform settings used by the indicator.
  - `IOnlineDataProvider OnlineDataProvider { get; }`
    - Gets or sets the online data provider used by the indicator to fetch real-time data.
  - `ObservableCollection< CandlePartSeries > CandlesDataSeries { get; }`
    - Gets or sets the collection of candle part series used by the indicator.
  - `ObservableCollection< string > Panels { get; }`
    - Gets or sets the collection of panels associated with the indicator.
  - `MarketDepthInfoProvider MarketDepthInfoProvider { get; }`
    - Gets or sets the market depth information provider used by the indicator to access market depth data.
  - `IInstrumentInfo InstrumentInfo { set; }`
    - Gets or sets the instrument information associated with the indicator's instrument.
  - `ITradingManager TradingManager { get; }`
    - Gets the trading manager used by the indicator to manage trading-related tasks.
  - `ITradingStatisticsProvider TradingStatisticsProvider { get; }`
    - Gets the trading statistics provider used by the indicator to access trading-related statistics.
  - `string Name { get; }`
    - Gets the name of the indicator data provider.
  - `IChart ChartInfo { get; }`
    - Gets the chart information associated with the indicator.
  - `IPlatformSettings GlobalPlatformSettings { get; }`
    - Gets the global platform settings used by the indicator.
  - `IOnlineDataProvider OnlineDataProvider { get; }`
    - Gets the online data provider used by the indicator to fetch real-time data.
  - `ObservableCollection< CandlePartSeries > CandlesDataSeries { get; }`
    - Gets the collection of candle part series used by the indicator.
  - `ObservableCollection< string > Panels { get; }`
    - Gets the collection of panels associated with the indicator.
  - `MarketDepthInfoProvider MarketDepthInfoProvider { get; }`
    - Gets the market depth information provider used by the indicator to access market depth data.
  - `IInstrumentInfo InstrumentInfo { get; }`
    - Gets the instrument information associated with the indicator's instrument.
  - `ITradingManager TradingManager { get; }`
    - Gets the trading manager used by the indicator to manage trading-related tasks.
  - `ITradingStatisticsProvider TradingStatisticsProvider { get; }`
    - Gets the trading statistics provider used by the indicator to access trading-related statistics.
