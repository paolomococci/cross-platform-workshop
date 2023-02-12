# AttitudeML.RC4

Web application that provides access to machine learning capabilities using the ML.NET version 3.0.0-preview.22621.2 framework.
Stylized using the CSS UIkit framework.

## Scaffolding

### I start by creating the directory that will house the entire project

```shell
mkdir AttitudeML.RC4
cd AttitudeML.RC4
```

### I create the file that defines the workspace

```shell
cat <<EOF | tee AttitudeML.RC4.code-workspace
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
echo -e "# AttitudeML.RC4" > README.md
```

### AttitudeML.Common project

```shell
dotnet new classlib -o AttitudeML.Common
cd AttitudeML.Common
rm Class1.cs
dotnet add package ClosedXML --version 0.100.3
dotnet add package Microsoft.ML --version 3.0.0-preview.22621.2
dotnet add package Microsoft.ML.TorchSharp --version 0.21.0-preview.22621.2
mkdir Models
echo -e "namespace AttitudeML.Common.Models;\n\npublic class DatasetModel {}" > Models/DomainModel.cs
echo -e "namespace AttitudeML.Common.Models;\n\npublic class PredictionModel {}" > Models/PredictionModel.cs
echo -e "namespace AttitudeML.Common.Models;\n\npublic class SchemeModel {}" > Models/SchemeModel.cs
echo -e "namespace AttitudeML.Common.Models;\n\npublic class ReportModel {}" > Models/ReportModel.cs
echo -e "namespace AttitudeML.Common.Models;\n\npublic class WorkbookModel {}" > Models/WorkbookModel.cs
mkdir Tests
echo -e "namespace AttitudeML.Common.Tests;\n\npublic class SchemeModelTest {}" > Tests/SchemeModelTest.cs
```

### AttitudeML.Mvc.Feather project

```shell
dotnet new web -o AttitudeML.Mvc.Feather
cd AttitudeML.Mvc.Feather
dotnet add ./AttitudeML.Mvc.Feather.csproj reference ../AttitudeML.Common/AttitudeML.Common.csproj
mkdir Models
echo -e "namespace AttitudeML.Mvc.Feather.Models;\n\npublic class ErrorViewModel {}" > Models/ErrorViewModel.cs
echo -e "namespace AttitudeML.Mvc.Feather.Models;\n\npublic class DataCollectionModel {}" > Models/DataCollectionModel.cs
mkdir Services
echo -e "namespace AttitudeML.Mvc.Feather.Services;\n\npublic class FileUploadService {}" > Services/FileUploadService.cs
mkdir Views
touch Views/_ViewImports.cshtml
touch Views/_ViewStart.cshtml
mkdir Views/Shared
touch Views/Shared/_Layout.cshtml
touch Views/Shared/Error.cshtml
mkdir Views/Home
touch Views/Home/Index.cshtml
touch Views/Home/Upload.cshtml
touch Views/Home/Workbooks.cshtml
touch Views/Home/Interact.cshtml
touch Views/Home/Report.cshtml
mkdir Views/Workbook
touch Views/Workbook/Index.cshtml
mkdir Views/Scheme
touch Views/Scheme/Index.cshtml
mkdir Controllers
echo -e "namespace AttitudeML.Mvc.Feather.Controllers;\n\npublic class HomeController {}" > Controllers/HomeController.cs
echo -e "namespace AttitudeML.Mvc.Feather.Controllers;\n\npublic class WorkbookController {}" > Controllers/WorkbookController.cs
echo -e "namespace AttitudeML.Mvc.Feather.Controllers;\n\npublic class SchemeController {}" > Controllers/SchemeController.cs
mkdir wwwroot
mkdir wwwroot/css
mkdir wwwroot/js
mkdir wwwroot/Store
mkdir wwwroot/Store/datasets
mkdir wwwroot/Store/workbooks
touch wwwroot/css/site.css
touch wwwroot/js/site.js
```

### After that, from within the AttitudeML.Mvc.Feather directory, I can launch the web application

```shell
dotnet watch run
```

