# 开发环境配置

## 系统要求

- **操作系统**: Windows 10/11
- **开发工具**: Microsoft Visual Studio 2022 (Community 版免费)
- **运行时**: .NET 8.0 SDK

## 安装步骤

### 1. 安装 Visual Studio

1. 从 [visualstudio.microsoft.com](https://visualstudio.microsoft.com/downloads/) 下载 Visual Studio Community
2. 安装时选择 ".NET 桌面开发" 工作负载

### 2. 安装 ATAS 平台

1. 从 [atas.net](https://atas.net) 下载并安装 ATAS 交易平台
2. 记录安装路径，通常为 `C:\Program Files\ATAS` 或自定义路径

### 3. 创建项目

1. 打开 Visual Studio
2. 创建新项目 → 选择 "类库 (.NET)"
3. 配置项目:
   - 目标框架: .NET 8.0
   - 项目名称: 自定义 (如 MyCustomIndicator)

### 4. 添加引用

在项目中添加以下 DLL 引用 (位于 ATAS 安装目录):

| DLL 文件 | 说明 |
|----------|------|
| `ATAS.Indicators.dll` | 核心指标库，包含所有指标基类 |
| `Utils.Common.dll` | 工具库，包含日志等功能 |

### 5. 配置项目文件

编辑 `.csproj` 文件，添加:

```xml
<PropertyGroup>
  <TargetFramework>net8.0</TargetFramework>
  <UseWPF>true</UseWPF>
</PropertyGroup>
```

## 验证安装

创建一个简单的指标测试环境是否正确配置:

```csharp
using ATAS.Indicators;

public class TestIndicator : Indicator
{
    protected override void OnCalculate(int bar, decimal value)
    {
        this[bar] = value;
    }
}
```

编译项目，将生成的 DLL 复制到 ATAS 指标目录:
- 新版本: 通过 ATAS 界面 "添加自定义指标"
- 旧版本: `C:\Users\<用户名>\Documents\ATAS\Indicators`

---
