# StrategyStateChangedEventArgs

**完整名称**: `ATAS.Strategies.StrategyStateChangedEventArgs`
**类型**: 类

## 描述

Provides data for the StrategyStateChanged event.

## 公共方法

  - ` StrategyStateChangedEventArgs(IStrategy strategy, StrategyStateDescription state)`
    - Initializes a new instance of the StrategyStateChangedEventArgs class with the specified strategy, old state, and new state.

## 属性

  - `IStrategy Strategy { get; }`
    - Gets the strategy associated with the state change.
  - `StrategyStateDescription State { get; }`
    - Gets the state of the strategy.
