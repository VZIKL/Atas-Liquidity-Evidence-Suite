# User

**完整名称**: `ATAS.DataFeedsCore.User`
**类型**: 类
**继承自**: `ATAS.DataFeedsCore.IEntity`

## 公共方法

  - ` User()`
  - ` User(string login, string password)`
  - `void SetFakePassword()`
  - `bool Check(string password)`
  - `void Update(string password)`
  - `override string ToString()`
    - Returns a string that represents the current object.

## 保护方法

  - `virtual void OnPropertyChanged(string propertyName)`

## 属性

  - `long Id { set; }`
  - `long GroupId { set; }`
  - `UserGroup Group { set; }`
  - `long RoleId { set; }`
  - `UserRole Role { set; }`
  - `string Login { set; }`
  - `string Password { set; }`
  - `string Salt { set; }`
  - `string Name { set; }`
  - `string Description { set; }`
  - `string Email { set; }`
  - `string Country { set; }`
  - `string Zip { set; }`
  - `string Address { set; }`
  - `string Phone { set; }`
  - `bool IsOnline { set; }`
  - `bool IsLocked { set; }`
  - `DateTime? ExpiryDate { set; }`
  - `DateTime? LastLogonTime { set; }`
  - `List< Portfolio > Portfolios { get; }`
  - `List< PortfolioViewer > PortfolioViewers { get; }`
  - `EntityType EntityType { get; }`
    - Gets the type of the entity.
  - `EntityType EntityType { get; }`
    - Gets the type of the entity.

## 事件

  - `event PropertyChangedEventHandler PropertyChanged`
