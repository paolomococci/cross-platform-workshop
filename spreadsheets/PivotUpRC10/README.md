# PivotUpRC10

It extracts data from a dataset previously loaded and stored and then transcribed into a workbook, also stored in a dedicated directory.

## Scaffolding

### I start by creating the directory that will house the entire project

```shell
mkdir PivotUpRC10
cd PivotUpRC10
```

### I create the file that defines the workspace

```shell
cat <<EOF | tee PivotUpRC10.code-workspace
{
	"folders": [
		{
			"path": "."
		}
	],
	"settings": {}
}
EOF
```

### I continue to define the root of the whole project

```shell
dotnet new gitignore
touch README.md
```

### Pivot.Common project

```shell
dotnet new classlib -o Pivot.Common
cd Pivot.Common
rm Class1.cs
dotnet add package ClosedXML --version 0.100.3
mkdir Models
mkdir Templates
```

### Pivot.Mvc.Feather project

```shell
dotnet new web -o Pivot.Mvc.Feather
cd Pivot.Mvc.Feather
dotnet add ./Pivot.Mvc.Feather.csproj reference ../Pivot.Common/Pivot.Common.csproj
mkdir Models
echo -e "namespace Pivot.Mvc.Feather.Models;\n\npublic class ErrorViewModel {}" > Models/ErrorViewModel.cs
echo -e "namespace Pivot.Mvc.Feather.Models;\n\npublic class PostModel {}" > Models/PostModel.cs
echo -e "namespace Pivot.Mvc.Feather.Models;\n\npublic class AssetModel {}" > Models/AssetModel.cs
echo -e "namespace Pivot.Mvc.Feather.Models;\n\npublic class CoordsModel {}" > Models/CoordsModel.cs
echo -e "namespace Pivot.Mvc.Feather.Models;\n\npublic class DataSheetModel {}" > Models/DataSheetModel.cs
echo -e "namespace Pivot.Mvc.Feather.Models;\n\npublic class WorkbookModel {}" > Models/WorkbookModel.cs
mkdir Views
touch Views/_ViewImports.cshtml
touch Views/_ViewStart.cshtml
mkdir Views/Shared
touch Views/Shared/_Layout.cshtml
touch Views/Shared/Error.cshtml
mkdir Views/Home
touch Views/Home/Index.cshtml
touch Views/Home/Upload.cshtml
touch Views/Home/Uploaded.cshtml
mkdir Views/Ledger
touch Views/Ledger/Index.cshtml
touch Views/Ledger/Workbooks.cshtml
mkdir Controllers
echo -e "namespace Pivot.Mvc.Feather.Controllers;\n\npublic class HomeController {}" > Controllers/HomeController.cs
echo -e "namespace Pivot.Mvc.Feather.Controllers;\n\npublic class LedgerController {}" > Controllers/LedgerController.cs
dotnet watch run
```
