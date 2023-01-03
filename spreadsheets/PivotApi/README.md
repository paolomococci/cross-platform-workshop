# PivotApi

This trace is useful if you want to process and distribute spreadsheets thanks to the web.
In particular, it is an example of transcription of data of different types, in a collection of spreadsheets, which took place in a programmatic way.

## Scaffolding

### main project

```shell
mkdir PivotApi
cd PivotApi
dotnet new gitignore
```

### Pivot.Common project

```shell
dotnet new classlib -o Pivot.Common
cd Pivot.Common
rm Class1.cs
dotnet add package ClosedXML --version 0.97.0
mkdir Models
echo -e "namespace Pivot.Common.Models;\n\npublic class LedgerModel {}" > Models/LedgerModel.cs
echo -e "namespace Pivot.Common.Models;\n\npublic class ItemModel {}" > Models/ItemModel.cs
mkdir Templates
echo -e "namespace Pivot.Common.Templates;\n\npublic class PinnedSheetTemplate {}" > Templates/PinnedSheetTemplate.cs
```

### Pivot.Web project

```shell
dotnet new web -o Pivot.Web
cd Pivot.Web
dotnet add ./Pivot.Web.csproj reference ../Pivot.Common/Pivot.Common.csproj
mkdir Controllers
echo -e "namespace Pivot.Web.Controllers;\n\npublic class LedgerController {}" > Controllers/LedgerController.cs
dotnet run
```
