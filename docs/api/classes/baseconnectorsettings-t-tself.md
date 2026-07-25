# BaseConnectorSettings< T, TSelf >

**完整名称**: `OFT.Core.BaseConnectorSettings< T, TSelf >`
**类型**: 类
**继承自**: `OFT.Core.IConnectorSettings`

## 公共方法

  - `IDataFeedConnector CreateConnector(string dataPath)`
  - `void ApplySettings(IDataFeedConnector connector)`
  - `virtual bool CheckSupported(out string? errorMessage)`
    - Checks if connector is supported on this machine.Parameters errorMessageNull if supported otherwise contains error text Returnstrue if no problems detected, false if not supported
  - `bool HasSameCredentials(IConnectorSettings other)`
    - Checks if this connector has the same credentials as another connector. Also verifies that the connector types match.
  - `override string ToString()`
  - `IDataFeedConnector CreateConnector(string dataPath)`
  - `void ApplySettings(IDataFeedConnector connector)`
  - `bool CheckSupported(out string? errorMessage)`
    - Checks if connector is supported on this machine.
  - `bool HasSameCredentials(IConnectorSettings other)`
    - Checks if this connector has the same credentials as another connector. Also verifies that the connector types match.

## 保护方法

  - ` BaseConnectorSettings()`
  - `abstract bool CompareCredentials(IConnectorSettings other)`
    - Compares credentials with another connector of the same type. The caller (HasSameCredentials) already guarantees that other is the same Type.
  - `abstract IDataFeedConnector OnCreateConnector(string dataPath)`
  - `abstract void OnApplySettings(IDataFeedConnector connector)`
  - `void RaisePropertyChanged(string propertyName)`
  - `bool SetProperty< TValue >(ref TValue storage, TValue newValue, string propertyName, Action< TValue, TValue > onChanged=null)`
  - `override IDataFeedConnector OnCreateConnector(string dataPath)`
  - `override void OnApplySettings(IDataFeedConnector connector)`
  - `sealed override bool CompareCredentials(IConnectorSettings other)`
  - `abstract void OnApplySettings(T connector)`
  - `abstract bool CompareCredentials(TSelf other)`

## 属性

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

## 事件

  - `event PropertyChangedEventHandler PropertyChanged`
