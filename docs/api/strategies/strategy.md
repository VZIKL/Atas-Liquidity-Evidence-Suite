# Strategy

**完整名称**: `ATAS.Strategies.Strategy`
**类型**: 类
**继承自**: `ATAS.Strategies.IStrategy`

## 描述

Base class for implementing trading strategies.

## 公共方法

  - `void Start()`
  - `void Stop()`
  - `async Task StartAsync()`
    - Starts the strategy, allowing it to execute its trading logic.
  - `async Task WatchAsync()`
  - `async Task StartFromWatchAsync()`
  - `async Task StopAsync()`
    - Stops the strategy, terminating its execution and releasing any resources.
  - `async void OpenOrder(Order order, bool isAutomated=true)`
    - Opens an order.
  - `async Task OpenOrderAsync(Order order, bool isAutomated=true)`
    - Opens an order.
  - `async void ModifyOrder(Order order, Order neworder, bool isAutomated=true)`
    - Modifies an order.
  - `async Task ModifyOrderAsync(Order order, Order neworder, bool isAutomated=true)`
    - Modifies an order.
  - `async void CancelOrder(Order order, bool isAutomated=true)`
    - Cancels an order.
  - `async Task CancelOrderAsync(Order order, bool isAutomated=true)`
    - Cancels an order.
  - `Task StartAsync()`
    - Starts the strategy, allowing it to execute its trading logic.
  - `Task StopAsync()`
    - Stops the strategy, terminating its execution and releasing any resources.

## 保护方法

  - ` Strategy()`
  - `void SetState(StrategyStates state)`
    - Set strategy state.
  - `void SetErrorState(StrategyErrorTypes type, string[] errorDescriptions)`
    - Set StrategyStates.Error state.
  - `void ResetErrorState()`
    - Reset error state.
  - `void RaisePropertyChanged(string propertyName)`
    - Raises the PropertyChanged event with the specified property name.
  - `void RaiseShowNotification(string message, string title=null, bool isError=false)`
    - Raises the ShowNotification event with the specified message, title, and error flag.
  - `bool SetProperty< TValue >(ref TValue storage, TValue newValue, string propertyName, Action< TValue, TValue > onChanged=null)`
    - Sets the property with the specified name to the new value and raises the PropertyChanged event if the value has changed.
  - `string GetOCOGroup()`
    - Generates a unique OCO (One-Cancels-the-Other) group identifier based on the current timestamp.
  - `bool CanProcess(Order order)`
    - Checks if the specified order can be processed by this strategy.
  - `ICollection< MyTrade > FilterMyTrades(IEnumerable< MyTrade > trades)`
    - Filters and returns the collection of MyTrade that belong to the current portfolio and security and have occurred after the latest trade time.
  - `void UpdateCurrentPosition()`
    - Update thr CurrentPosition and AveragePrice values.
  - `virtual Task OnStarted()`
    - Called when the strategy is started from StrategyStates.Stopped state.
  - `virtual Task OnStartedFromWatch()`
    - Called when the strategy is started from StrategyStates.Watch state.
  - `virtual Task OnStopping()`
    - Called when the strategy is stopping.
  - `virtual Task OnStopped()`
    - Called when the strategy is stopped.
  - `virtual Task OnOpenOrder(Order order, bool isAutomated)`
    - Called when a new order is opened.
  - `virtual Task OnModifyOrder(Order order, Order newOrder, bool isAutomated)`
    - Called when an existing order is modified.
  - `virtual Task OnCancelOrder(Order order, bool isAutomated)`
    - Called when an order is canceled.
  - `virtual void OnMarketDepth(IEnumerable< MarketDepth > depths)`
    - Called when market depth data is received.
  - `virtual void OnBestBidAsk(MarketDepth depth)`
    - Called when the best bid or ask market depth data is received.
  - `virtual void OnNewTrade(Trade trade)`
    - Called when a new trade occurs.
  - `virtual void OnNewPortfolio(Portfolio portfolio)`
    - Called when a new portfolio is added.
  - `virtual void OnNewPosition(Position position)`
    - Called when a new position is added.
  - `virtual void OnPositionChanged(Position position)`
    - Called when an existing position is changed.
  - `virtual void OnPnLChanged(int ticks)`
    - Called when the profit and loss (PnL) changes.
  - `virtual void OnNewOrder(Order order)`
    - Called when a new order is added.
  - `virtual void OnOrderChanged(Order order)`
    - Called when an existing order is changed.
  - `virtual void OnOrderRegisterFailed(Order order, string message)`
    - Called when an order registration fails.
  - `virtual void OnOrderCancelFailed(Order order, string message)`
    - Called when an order cancellation fails.
  - `virtual void OnOrderModifyFailed(Order order, Order newOrder, string message)`
    - Called when an order modification fails.
  - `virtual void OnNewMyTrade(MyTrade myTrade)`
    - Called when a new trade is added to the collection of MyTrade.
  - `virtual void OnCurrentPositionChanged()`
    - Called when the volume of the current position changes.
  - `virtual void OnUpdateStrategyState()`
    - Called when the strategy state needs to be updated.
  - `virtual bool CanProcess()`
    - Checks if the strategy can process operations in the current state.
  - `virtual bool CanUpdateCurrentPosition(Position position)`
    - Checks if the current position can be updated with the specified position.
  - `virtual void LogParameters()`
    - Log current parameters.

## 属性

  - `Security Security { set; }`
    - Gets or sets the security associated with the strategy.
  - `Portfolio Portfolio { set; }`
    - Gets or sets the portfolio associated with the strategy.
  - `TPlusLimits? TPlusLimit { set; }`
    - Gets or sets the T+ limits for the strategy.
  - `IDataFeedConnector Connector { set; }`
    - Gets or sets the data feed connector for the strategy.
  - `IEnumerable< MyTrade > MyTrades { get; }`
  - `IEnumerable< Order > Orders { get; }`
  - `Position Position { set; }`
  - `decimal CurrentPosition { get; }`
    - Gets the current position volume of the strategy.
  - `decimal AveragePrice { get; }`
    - Gets the average price of the strategy's trades.
  - `int OpenTicksPnL { get; }`
  - `decimal OpenPnL { get; }`
    - Gets the open profit and loss of the strategy.
  - `decimal ClosedPnL { get; }`
    - Gets the closed profit and loss of the strategy.
  - `MarketDepth BestBid { get; }`
  - `MarketDepth BestAsk { get; }`
  - `StrategyStates State { set; }`
    - Gets the current state of the strategy.
  - `StrategyStateDescription StateDescription { get; }`
  - `string Name { set; }`
    - Gets or sets the name of the strategy.
  - `string Name { set; }`
    - Gets or sets the name of the strategy.
  - `StrategyStates State { get; }`
    - Gets the current state of the strategy.
  - `decimal CurrentPosition { get; }`
    - Gets the current position volume of the strategy.
  - `decimal AveragePrice { get; }`
    - Gets the average price of the strategy's trades.
  - `decimal OpenPnL { get; }`
    - Gets the open profit and loss of the strategy.
  - `decimal ClosedPnL { get; }`
    - Gets the closed profit and loss of the strategy.
  - `Security Security { set; }`
    - Gets or sets the security associated with the strategy.
  - `Portfolio Portfolio { set; }`
    - Gets or sets the portfolio associated with the strategy.
  - `TPlusLimits? TPlusLimit { set; }`
    - Gets or sets the T+ limits for the strategy.
  - `IDataFeedConnector Connector { set; }`
    - Gets or sets the data feed connector for the strategy.

## 事件

  - `event PropertyChangedEventHandler PropertyChanged`
  - `event EventHandler< StrategyStateChangedEventArgs > StateChanged`
  - `event EventHandler< StrategyNotificationEventArgs > ShowNotification`
  - `event EventHandler< StrategyStateChangedEventArgs > StateChanged`
    - Occurs when the state of the strategy changes.
  - `event EventHandler< StrategyNotificationEventArgs > ShowNotification`
    - Occurs when the strategy needs to show a notification or alert.
