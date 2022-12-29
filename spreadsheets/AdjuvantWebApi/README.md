# AdjuvantWebApi

This trace is useful if you want to process and distribute spreadsheets thanks to the web.

## Scaffolding

```shell
mkdir AdjuvantWebApi
cd AdjuvantWebApi
dotnet new gitignore
dotnet new webapi -o Spreadsheet.WebApi
cd Spreadsheet.WebApi
dotnet add package ClosedXML --version 0.97.0
mkdir Templates
echo -e "namespace Spreadsheet.WebApi.Controllers;\n\npublic class SpreadsheetController {}" > Controllers/SpreadsheetController.cs
echo -e "namespace Spreadsheet.WebApi.Templates;\n\npublic class AdjuvantTemplate {}" > Templates/AdjuvantTemplate.cs
dotnet run
```
