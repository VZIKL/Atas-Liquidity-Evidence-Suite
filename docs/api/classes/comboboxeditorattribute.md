# ComboBoxEditorAttribute

**完整名称**: `OFT.Attributes.Editors.ComboBoxEditorAttribute`
**类型**: 类

## 公共方法

  - ` ComboBoxEditorAttribute(params object[] itemsSource)`
    - Configure ComboBox editor attribute.
  - ` ComboBoxEditorAttribute(Type typeSource)`
    - Configure ComboBox editor attribute.
  - `IEnumerable GetItemsSource(object instance)`

## 属性

  - `string DisplayMember { set; }`
    - Gets or sets a member name in the bound data source whose values are displayed by the editor.
  - `string ValueMember { set; }`
    - Gets or sets a member name in the bound data source, whose values are assigned to item values.
  - `object[] ItemsSource { set; }`
    - Get or set data source for selection.
  - `bool IsTextEditable { set; }`
    - Gets or sets whether end-users are allowed to edit the text displayed in the edit box.
  - `bool AutoComplete { set; }`
    - Gets or sets whether the automatic completion is enabled.
  - `bool SelectItemWithNullValue { set; }`
    - Gets or sets whether the editor searches for a null item in the bound data source when the editor value is null (empty).
