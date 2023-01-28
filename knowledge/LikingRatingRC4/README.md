# LikingRatingRC4

Web application that offers access to machine learning features.
Stylized using the CSS UIkit framework.

## Scaffolding

### I start by creating the directory that will house the entire project

```shell
mkdir LikingRatingRC4
cd LikingRatingRC4
```

### I create the file that defines the workspace

```shell
cat <<EOF | tee LikingRatingRC4.code-workspace
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
echo -e "# LikingRatingRC4" > README.md
```

### Liking.Common project

```shell
dotnet new classlib -o Liking.Common
cd Liking.Common
rm Class1.cs
dotnet add package ClosedXML --version 0.100.3
dotnet add package Microsoft.ML --version 3.0.0-preview.22621.2
mkdir Models
echo -e "namespace Liking.Common.Models;\n\npublic class DatasetRawModel {}" > Models/DatasetRawModel.cs
echo -e "namespace Liking.Common.Models;\n\npublic class DatasetCookedModel {}" > Models/DatasetCookedModel.cs
echo -e "namespace Liking.Common.Models;\n\npublic class SchemeModel {}" > Models/SchemeModel.cs
echo -e "namespace Liking.Common.Models;\n\npublic class DataSheetModel {}" > Models/DataSheetModel.cs
echo -e "namespace Liking.Common.Models;\n\npublic class WorkbookModel {}" > Models/WorkbookModel.cs
```

### Liking.Mvc.Feather project

```shell
dotnet new web -o Liking.Mvc.Feather
cd Liking.Mvc.Feather
dotnet add ./Liking.Mvc.Feather.csproj reference ../Liking.Common/Liking.Common.csproj
mkdir Models
echo -e "namespace Liking.Mvc.Feather.Models;\n\npublic class ErrorViewModel {}" > Models/ErrorViewModel.cs
echo -e "namespace Liking.Mvc.Feather.Models;\n\npublic class DataCollectionModel {}" > Models/DataCollectionModel.cs
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
mkdir Views/Workbook
touch Views/Workbook/Index.cshtml
mkdir Controllers
echo -e "namespace Liking.Mvc.Feather.Controllers;\n\npublic class HomeController {}" > Controllers/HomeController.cs
echo -e "namespace Liking.Mvc.Feather.Controllers;\n\npublic class WorkbookController {}" > Controllers/WorkbookController.cs
echo -e "namespace Liking.Mvc.Feather.Controllers;\n\npublic class SchemeController {}" > Controllers/SchemeController.cs
mkdir wwwroot
mkdir wwwroot/css
mkdir wwwroot/js
mkdir wwwroot/Store
mkdir wwwroot/Store/datasets
mkdir wwwroot/Store/workbooks
touch wwwroot/css/site.css
touch wwwroot/js/site.js
```

### After that, from within the Liking.Mvc.Feather directory, I can launch the web application

```shell
dotnet watch run
```

