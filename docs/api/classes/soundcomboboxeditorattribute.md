# SoundComboBoxEditorAttribute

**完整名称**: `OFT.Attributes.Editors.SoundComboBoxEditorAttribute`
**类型**: 类
**继承自**: `OFT.Attributes.Editors.ComboBoxEditorAttribute`

## 描述

Specialized ComboBox editor for internal application sounds. Renders non-editable list with a Play button in item template.

## 公共方法

  - ` SoundComboBoxEditorAttribute()`
    - Create sound combo editor. ItemsSource will be supplied by editor behavior.
  - ` SoundComboBoxEditorAttribute(Type itemsSource)`
    - Create sound combo editor with custom source type.
  - ` ComboBoxEditorAttribute(params object[] itemsSource)`
    - Configure ComboBox editor attribute.
  - ` ComboBoxEditorAttribute(Type typeSource)`
    - Configure ComboBox editor attribute.
  - `IEnumerable GetItemsSource(object instance)`
  - `string DisplayMember()`
    - Gets or sets a member name in the bound data source whose values are displayed by the editor.
  - `string ValueMember()`
    - Gets or sets a member name in the bound data source, whose values are assigned to item values.
  - `object[] ItemsSource()`
    - Get or set data source for selection.
  - `bool IsTextEditable()`
    - Gets or sets whether end-users are allowed to edit the text displayed in the edit box.
  - `bool AutoComplete()`
    - Gets or sets whether the automatic completion is enabled.
  - `bool SelectItemWithNullValue()`
    - Gets or sets whether the editor searches for a null item in the bound data source when the editor value is null (empty).
