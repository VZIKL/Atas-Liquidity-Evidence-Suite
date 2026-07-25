# BaseMarketDataOnlyConnectorSettings< T, TSelf >

**完整名称**: `ATAS.DataFeedsCore.BaseMarketDataOnlyConnectorSettings< T, TSelf >`
**类型**: 类
**继承自**: `OFT.Core.BaseConnectorSettings< T, TSelf >`

## 属性

  - `bool MarketDataOnly { set; }`
  - `string Type { set; }`
  - `string Description { get; }`
  - `Uri Logo { get; }`
  - `Guid Id { set; }`
  - `virtual string DisplayName { set; }`
  - `string Name { set; }`
  - `bool IsMarketDataEnabled { set; }`
  - `bool IsAutoConnectEnabled { set; }`
  - `bool AllowUpdatePositionsPnL { set; }`
  - `TimeOnly? RefreshSecuritiesTime { set; }`
  - `abstract ConnectorFeatures Features { get; }`
  - `virtual ConnectorSettingsTypes SettingsTypes { get; }`
  - `virtual bool IsDemo { get; }`
    - Indicates that connector uses TestNet environment.
  - `virtual MarketDataDelayPeriods MarketDataDelayPeriod { get; }`
  - `string Type { get; }`
  - `string Description { get; }`
  - `Uri Logo { get; }`
  - `Guid Id { set; }`
  - `string Name { set; }`
  - `bool IsMarketDataEnabled { set; }`
  - `bool IsAutoConnectEnabled { set; }`
  - `ConnectorFeatures Features { get; }`
  - `ConnectorSettingsTypes SettingsTypes { get; }`
  - `bool IsDemo { get; }`
    - Indicates that connector uses TestNet environment.
  - `MarketDataDelayPeriods MarketDataDelayPeriod { get; }`
  - `bool MarketDataOnly { set; }`
  - `IDataFeedConnector CreateConnector `
  - `void ApplySettings `
  - `virtual bool CheckSupported `
    - Checks if connector is supported on this machine.Parameters errorMessageNull if supported otherwise contains error text Returnstrue if no problems detected, false if not supported
  - `bool HasSameCredentials `
    - Checks if this connector has the same credentials as another connector. Also verifies that the connector types match.
  - `override string ToString `
  - `IDataFeedConnector CreateConnector `
  - `void ApplySettings `
  - `bool CheckSupported `
    - Checks if connector is supported on this machine.
  - `bool HasSameCredentials `
    - Checks if this connector has the same credentials as another connector. Also verifies that the connector types match.
  - ` BaseConnectorSettings `
  - `abstract bool CompareCredentials `
    - Compares credentials with another connector of the same type. The caller (HasSameCredentials) already guarantees that other is the same Type.
  - `abstract IDataFeedConnector OnCreateConnector `
  - `abstract void OnApplySettings `
  - `void RaisePropertyChanged `
  - `bool SetProperty< TValue > `
  - `override IDataFeedConnector OnCreateConnector `
  - `override void OnApplySettings `
  - `sealed override bool CompareCredentials `
  - `abstract void OnApplySettings `
  - `abstract bool CompareCredentials `
  - `PropertyChangedEventHandler PropertyChanged `
