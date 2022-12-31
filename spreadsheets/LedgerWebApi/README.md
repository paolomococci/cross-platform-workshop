# LedgerWebApi

This trace is useful if you want to process and distribute spreadsheets thanks to the web.

## Scaffolding

```shell
mkdir LedgerWebApi
cd LedgerWebApi
dotnet new gitignore
dotnet new webapi -o Spreadsheet.WebApi
cd Spreadsheet.WebApi
dotnet add package ClosedXML --version 0.97.0
mkdir Templates
echo -e "namespace Spreadsheet.WebApi.Controllers;\n\npublic class SpreadsheetController {}" > Controllers/SpreadsheetController.cs
echo -e "namespace Spreadsheet.WebApi.Templates;\n\npublic class AdjuvantTemplate {}" > Templates/AdjuvantTemplate.cs
echo -e "namespace Spreadsheet.WebApi.Templates;\n\npublic class RetrieverTemplate {}" > Templates/RetrieverTemplate.cs
mkdir Models
echo -e "namespace Spreadsheet.WebApi.Models;\n\npublic class SampleOneModel {}" > Models/SampleOneModel.cs
echo -e "namespace Spreadsheet.WebApi.Models;\n\npublic class SampleTwoModel {}" > Models/SampleTwoModel.cs
echo -e "namespace Spreadsheet.WebApi.Models;\n\npublic class ResultModel {}" > Models/ResultModel.cs
dotnet run
```
