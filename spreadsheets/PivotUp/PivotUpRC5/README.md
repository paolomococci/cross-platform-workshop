# PivotUpRC5

Example of a web application dedicated to the upload and subsequent programmatic processing of spreadsheets.

## Scaffolding

### I start by creating the directory that will house the entire project

```shell
mkdir PivotUpRC5
cd PivotUpRC5
```

### I create the file that defines the workspace

```shell
cat <<EOF | tee PivotUpRC5.code-workspace
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
dotnet add package ClosedXML --version 0.97.0
mkdir Models
echo -e "namespace Pivot.Common.Models;\n\npublic class LedgerModel {}" > Models/LedgerModel.cs
echo -e "namespace Pivot.Common.Models;\n\npublic class ItemModel {}" > Models/ItemModel.cs
mkdir Templates
echo -e "namespace Pivot.Common.Templates;\n\npublic class PinnedSheetTemplate {}" > Templates/PinnedSheetTemplate.cs
```

### Pivot.Mvc.Feather project

```shell
dotnet new web -o Pivot.Mvc.Feather
cd Pivot.Mvc.Feather
dotnet add ./Pivot.Mvc.Feather.csproj reference ../Pivot.Common/Pivot.Common.csproj
mkdir Models
echo -e "namespace Pivot.Mvc.Feather.Models;\n\npublic class ErrorViewModel {}" > Models/ErrorViewModel.cs
echo -e "namespace Pivot.Mvc.Feather.Models;\n\npublic class PostModel {}" > Models/PostModel.cs
echo -e "namespace Pivot.Mvc.Feather.Models;\n\npublic class CoordsModel {}" > Models/CoordsModel.cs
echo -e "namespace Pivot.Mvc.Feather.Models;\n\npublic class AssetModel {}" > Models/AssetModel.cs
echo -e "namespace Pivot.Mvc.Feather.Models;\n\npublic class DataSheetModel {}" > Models/DataSheetModel.cs
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
touch Views/Home/Process.cshtml
mkdir Views/Ledger
touch Views/Ledger/Index.cshtml
mkdir Controllers
echo -e "namespace Pivot.Mvc.Feather.Controllers;\n\npublic class HomeController {}" > Controllers/HomeController.cs
echo -e "namespace Pivot.Mvc.Feather.Controllers;\n\npublic class LedgerController {}" > Controllers/LedgerController.cs
dotnet watch run
```
