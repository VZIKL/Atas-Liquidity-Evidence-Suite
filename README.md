# ATAS Custom Indicators — Iceberg & Stop-Loss Detection

Three indicators for order flow analysis on [ATAS](https://atas.net) platform.

## Indicators

| Indicator | Data Input | What It Detects |
|-----------|-----------|-----------------|
| **IcebergDetector** | MBO + Tick + DOM | Iceberg candidate evidence from replenishment |
| **StopCascadeDetector** | CumulativeTrade + DOM + K线 | Stop-cascade candidate score at key-level breaks |
| **LiquidityStressIndex** | DOM snapshot + Tick + BBO | Liquidity-stress score after baseline warm-up |

## Architecture

```
Tick Events                    Timer Callbacks
    │                               │
    ├─ OnNewTrade ─────────┐       ├─ CheckDepthChannel (2s)
    ├─ MarketDepthChanged  │       └─ ComputeStressIndex (1s)
    ├─ OnCumulativeTrade ──┤
    ├─ OnMarketByOrders ───┤
    └─ OnBestBidAsk ───────┘
            │
    ┌───────▼────────┐
    │  FSM / Tracker  │  ← RingBuffer (O(1) window stats)
    │  KeyLevelCalc   │
    │  EMA baselines  │
    └───────┬────────┘
            │
    ┌───────▼──────────────┐
    │  ValueDataSeries[]    │  ← Per-bar output for chart
    │  Labels (AddText)     │  ← Visual annotations
    │  Alerts (AddAlert)    │  ← Sound/popup notifications
    └──────────────────────┘
```

All outputs are heuristic evidence scores. They are not calibrated probabilities and must be calibrated per exchange, instrument, and session before operational use.

## IcebergDetector — Detection logic

### Synthetic replenishment evidence (tick + DOM)
```
Observed ask/bid depth exists at a price
  → aggressive buy/sell consumes that same side
  → a depth reduction is observed
  → same-side depth at that price increases with similar visible size inside the timeout
  → repeated replenishment confirms an iceberg candidate
  → no further replenishment before timeout expires the candidate
```

Candidate and MBO state are cleared at a new trading session to prevent overnight order-flow history from contaminating live evidence.

### Zotikov Native iceberg (MBO-based)
- Track `ExchangeOrderId` across `OnMarketByOrdersChanged`
- A same-ID volume reduction records a possible partial fill
- A same-ID refill at the same price and side within the configurable window adds native evidence
- A volume reduction alone is not treated as iceberg evidence

### Output series
- `IcebergScore` (0-100): replenishment evidence score
- `HiddenVolume`: lower bound for hidden quantity already consumed; remaining hidden quantity cannot be inferred from public depth
- `ActiveCount`: # of confirmed iceberg levels

## StopCascadeDetector — Detection logic

### Key level identification
- Swing highs/lows (20-bar lookback)
- Round numbers (1.00 increments)
- Extensible to Volume Profile POC via `GetFixedProfile`

### Candidate score
1. A directional close through a key level is required.
2. Upward breaks require buy-aggressor spread evidence and/or ask-side DOM erosion; downward breaks require sell-aggressor evidence and/or bid-side DOM erosion.
3. Volume expansion is supplementary only: a score is emitted only when the break also has same-direction order-flow or DOM support.
4. Scores of 50/70/80 drive build-up, stress confirmation, and alerts respectively.

`CascadeDirection` is emitted beside the score: `+1` for upward key-level breaks, `-1` for downward key-level breaks, and `0` when no key-level break exists.

The indicator cannot observe stop orders directly. A high score identifies a candidate liquidity event, not a proven stop-loss cascade.

Swing levels become available only after their confirming lookback window closes; historical calculations do not use future candles, including after changing level parameters. Volume and DOM baselines reset at each trading session. DOM evidence uses only the configured near-touch depth levels and is ignored when the snapshot is stale.

### Regime state machine
```
Stable → Build-up → Stress → Stable
  ↑        ↓ (score >= 50)  ↓ (score < 30 sustained)
  └──────── 3+ scores >= 70 ─┘
```

## LiquidityStressIndex — Composite channels

MAX aggregation of corroborated channels:

| Channel | Metric | Weight |
|---------|--------|--------|
| Depth Erosion | max(bid_erosion, ask_erosion) × 100 | dominant |
| Trade Clustering | 1 - recent_interval / baseline_interval | secondary |
| Spread Pressure | normalized excess over baseline spread | auxiliary |
| OFI Volatility | normalized short-term / baseline volatility of volume-normalized OFI | auxiliary |

- Each channel requires a configurable minimum number of baseline samples.
- At least two ready channels must independently exceed the activation score before the index can alert.
- Stale DOM, BBO, or trade feeds make their corresponding channel unavailable.
- `StressIndex = 0` with `DataReadiness = 0` means unavailable/warming up, not an observed low-stress state.
- Rising-edge condition: 3+ consecutive 1 Hz samples → full signal
- Adaptive threshold: EMA baseline + 2σ
- Alert levels: Warning (60) / Critical (80)

## Build

Requirements: Windows 10/11, Visual Studio 2022, .NET 8.0, ATAS installed.

```powershell
# 1. Open src/ATAS.CustomIndicators.csproj in Visual Studio
# 2. Verify DLL references point to your ATAS installation
# 3. Build → ATAS.CustomIndicators.dll
# 4. In ATAS: Indicators → Add Custom Indicator → select DLL

# Optional: override the ATAS directory when it is not installed in the default location
dotnet build src/ATAS.CustomIndicators.csproj -p:AtasInstallDir="D:\Apps\ATAS"
```

### DLL reference paths (adjust for your ATAS install)
`AtasInstallDir` defaults to `C:\Program Files\ATAS` and can be overridden at build time.

## Data requirements

| Feature | Minimum Data | Better |
|---------|-------------|--------|
| Iceberg detection | Level 2 (MarketDepth) + Tick | MBO (MarketByOrder) |
| Stop cascade | Tick + CumulativeTrade | + Full DOM snapshot |
| Stress index | Tick + BBO | + DOM snapshot (timer) |

MBO data requires exchange support. Works best on CME, EUREX, NASDAQ TotalView.

## Verification checklist

Before production use:
- [ ] Compile on Windows with ATAS SDK DLLs
- [ ] Load on historical chart → verify no crashes
- [ ] Run on live data → verify tick events fire
- [ ] Verify session-open behavior and stale-feed suppression
- [ ] Build labelled, out-of-sample samples for each exchange and instrument
- [ ] Report precision, recall, false-alert rate, calibration, and lead time
- [ ] Tune `ConfirmThreshold`, `NativeReplenishWindowMs`, and `VolumeSpikeMultiplier` on training data only
- [ ] Verify MBO subscription if using native iceberg detection

## References

- Frey & Sandås (2017). *The Impact of Iceberg Orders in Limit Order Books*. QJF. Market-impact evidence, not a production detector specification.
- Zotikov & Antonov (2019). *CME Iceberg Order Detection and Prediction*. arXiv:1909.09495. CME-specific MBO method with out-of-sample evaluation.
- Hiremath & Hiremath (2026). *Early Detection of Latent Microstructure Regimes in LOBs*. arXiv:2604.20949. Preprint only; it is background for liquidity-regime ideas, not validation for this implementation.
- Zhang et al. (2025). *ClusterLOB: Enhancing Trading Strategies by Clustering Orders*. arXiv:2504.20349. MBO clustering reference; it does not validate the three indicators directly.

## License

MIT — use at your own risk. Not financial advice.
