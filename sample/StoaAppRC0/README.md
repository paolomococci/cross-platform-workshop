# StoaApp

## scaffolding

```shell
mkdir StoaApp
cd StoaApp
dotnet new gitignore
touch README.md
echo -e "{\n\t\"folders\": [\n\t\t{\n\t\t\t\"path\": \".\"\n\t\t}\n\t],\n\t\"settings\": {}\n}" > StoaAppRC0.code-workspace
dotnet new web -o Stoa.Web
cd Stoa.Web
mkdir Models
mkdir Views
mkdir Views/Shared
mkdir Views/Home
mkdir Controllers
echo -e "namespace Stoa.Web.Controllers;\n\npublic class HomeController {}" > Controllers/HomeController.cs
```
