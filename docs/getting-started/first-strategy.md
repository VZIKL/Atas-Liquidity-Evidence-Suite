# 创建第一个策略

## 基本结构

自定义策略需要继承 `Strategy` 类:

```csharp
using ATAS.Strategies;
using ATAS.DataFeedsCore;

public class MyFirstStrategy : Strategy
{
    protected override async Task OnStarted()
    {
        // 策略启动时执行
        await base.OnStarted();
    }

    protected override async Task OnStopping()
    {
        // 策略停止时执行
        await base.OnStopping();
    }
}
```

## 处理市场数据

```csharp
public class SimpleStrategy : Strategy
{
    protected override void OnNewTrade(Trade trade)
    {
        // 处理新的成交
        base.OnNewTrade(trade);
    }

    protected override void OnPositionChanged(Position position)
    {
        // 处理持仓变化
        base.OnPositionChanged(position);
    }
}
```

## 下单示例

```csharp
public class TradingStrategy : Strategy
{
    protected async void PlaceBuyOrder()
    {
        var order = new Order
        {
            Security = Security,
            Portfolio = Portfolio,
            Side = OrderSide.Buy,
            Type = OrderTypes.Market,
            Quantity = 1
        };

        await OpenOrderAsync(order);
    }
}
```

## 策略属性

| 属性 | 说明 |
|------|------|
| `Security` | 当前交易品种 |
| `Portfolio` | 当前投资组合 |
| `Position` | 当前持仓 |
| `CurrentPosition` | 当前持仓量 |
| `OpenPnL` | 浮动盈亏 |
| `ClosedPnL` | 已实现盈亏 |

## 下一步

- 查看 [Strategy 基类](../api/strategies/) 了解更多方法
- 查看 [Order 类](../api/trading/) 了解订单结构

---
