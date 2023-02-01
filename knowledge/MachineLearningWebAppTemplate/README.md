# MachineLearningWebAppTemplate

Web application that offers access to machine learning features.
Stylized using the CSS UIkit framework.

## Scaffolding

### I start by creating the directory that will house the entire project

```shell
mkdir MachineLearningWebAppTemplate
cd MachineLearningWebAppTemplate
```

### I create the file that defines the workspace

```shell
cat <<EOF | tee MachineLearningWebAppTemplate.code-workspace
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
echo -e "# MachineLearningWebAppTemplate" > README.md
```

### Template.Common project

```shell
dotnet new classlib -o Template.Common
cd Template.Common
rm Class1.cs
dotnet add package ClosedXML --version 0.100.3
dotnet add package Microsoft.ML --version 3.0.0-preview.22621.2
mkdir Models
echo -e "namespace Template.Common.Models;\n\npublic class DatasetRawModel {}" > Models/DatasetRawModel.cs
echo -e "namespace Template.Common.Models;\n\npublic class DatasetCookedModel {}" > Models/DatasetCookedModel.cs
echo -e "namespace Template.Common.Models;\n\npublic class SchemeModel {}" > Models/SchemeModel.cs
echo -e "namespace Template.Common.Models;\n\npublic class ReportModel {}" > Models/ReportModel.cs
echo -e "namespace Template.Common.Models;\n\npublic class DataSheetModel {}" > Models/DataSheetModel.cs
echo -e "namespace Template.Common.Models;\n\npublic class WorkbookModel {}" > Models/WorkbookModel.cs
mkdir Probes
echo -e "namespace Template.Common.Probes;\n\npublic class ConsoleProbe {}" > Probes/ConsoleProbe.cs
mkdir Tests
echo -e "namespace Template.Common.Tests;\n\npublic class SchemeModelTest {}" > Tests/SchemeModelTest.cs
```

### Template.Mvc.Feather project

```shell
dotnet new web -o Template.Mvc.Feather
cd Template.Mvc.Feather
dotnet add ./Template.Mvc.Feather.csproj reference ../Template.Common/Template.Common.csproj
mkdir Models
echo -e "namespace Template.Mvc.Feather.Models;\n\npublic class ErrorViewModel {}" > Models/ErrorViewModel.cs
echo -e "namespace Template.Mvc.Feather.Models;\n\npublic class DataCollectionModel {}" > Models/DataCollectionModel.cs
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
touch Views/Home/Report.cshtml
mkdir Views/Workbook
touch Views/Workbook/Index.cshtml
mkdir Views/Scheme
touch Views/Scheme/Index.cshtml
mkdir Controllers
echo -e "namespace Template.Mvc.Feather.Controllers;\n\npublic class HomeController {}" > Controllers/HomeController.cs
echo -e "namespace Template.Mvc.Feather.Controllers;\n\npublic class WorkbookController {}" > Controllers/WorkbookController.cs
echo -e "namespace Template.Mvc.Feather.Controllers;\n\npublic class SchemeController {}" > Controllers/SchemeController.cs
mkdir wwwroot
mkdir wwwroot/css
mkdir wwwroot/js
mkdir wwwroot/Store
mkdir wwwroot/Store/datasets
mkdir wwwroot/Store/workbooks
touch wwwroot/css/site.css
touch wwwroot/js/site.js
```

### After that, from within the Template.Mvc.Feather directory, I can launch the web application

```shell
dotnet watch run
```

