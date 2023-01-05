# StoaAppRC0

## scaffolding

```shell
mkdir StoaAppRC0
cd StoaAppRC0
dotnet new gitignore
touch README.md
echo -e "{\n\t\"folders\": [\n\t\t{\n\t\t\t\"path\": \".\"\n\t\t}\n\t],\n\t\"settings\": {}\n}" > StoaAppRC0.code-workspace
dotnet new web -o Stoa.Web
cd Stoa.Web
mkdir Models
echo -e "namespace Stoa.Web.Models;\n\npublic class ErrorViewModel {}" > Models/ErrorViewModel.cs
echo -e "namespace Stoa.Web.Models;\n\npublic class PostModel {}" > Models/PostModel.cs
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
mkdir Controllers
echo -e "namespace Stoa.Web.Controllers;\n\npublic class HomeController {}" > Controllers/HomeController.cs
dotnet watch run
```
