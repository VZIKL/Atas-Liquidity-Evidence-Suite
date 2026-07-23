# 创建第一个指标

## 基本结构

自定义指标需要继承 `Indicator` 类并实现 `OnCalculate` 方法:

```csharp
using ATAS.Indicators;

public class MyFirstIndicator : Indicator
{
    protected override void OnCalculate(int bar, decimal value)
    {
        // 在这里实现指标计算逻辑
        // value 是当前 K 线的收盘价
        // bar 是当前 K 线的索引

        this[bar] = value; // 将值存入默认数据系列
    }
}
```

## 添加参数

通过公共属性添加可配置参数:

```csharp
using System.ComponentModel.DataAnnotations;
using ATAS.Indicators;

public class SimpleMovingAverage : Indicator
{
    private int _period = 14;

    [Display(Name = "周期", GroupName = "参数")]
    public int Period
    {
        get => _period;
        set
        {
            _period = value;
            RecalculateValues();
        }
    }

    protected override void OnCalculate(int bar, decimal value)
    {
        if (bar < Period - 1)
        {
            this[bar] = 0;
            return;
        }

        decimal sum = 0;
        for (int i = 0; i < Period; i++)
        {
            sum += (decimal)this[bar - i];
        }

        this[bar] = sum / Period;
    }
}
```

## 使用多个数据系列

```csharp
using ATAS.Indicators;

public class HighLowIndicator : Indicator
{
    private readonly ValueDataSeries _highSeries = new("High");
    private readonly ValueDataSeries _lowSeries = new("Low");

    public HighLowIndicator()
    {
        DataSeries.Add(_highSeries);
        DataSeries.Add(_lowSeries);
    }

    protected override void OnCalculate(int bar, decimal value)
    {
        var candle = GetCandle(bar);

        _highSeries[bar] = candle.High;
        _lowSeries[bar] = candle.Low;
    }
}
```

## 在独立面板显示

```csharp
public class MyIndicator : Indicator
{
    public MyIndicator()
    {
        Panel = IndicatorDataProvider.NewPanel;
    }
}
```

## 下一步

- 查看 [Indicator 基类](../api/indicators/) 了解更多方法
- 查看 [数据系列](../api/data-series/) 了解数据存储方式

---
