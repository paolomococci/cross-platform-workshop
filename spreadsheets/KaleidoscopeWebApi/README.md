# KaleidoscopeWebApi

This trace is useful if you want to process and distribute spreadsheets thanks to the web.
In particular, it is an example of transcription of data of different types, in a collection of spreadsheets, which took place in a programmatic way.

## Scaffolding

```shell
mkdir KaleidoscopeWebApi
cd KaleidoscopeWebApi
dotnet new gitignore
dotnet new webapi -o Spreadsheet.WebApi
cd Spreadsheet.WebApi
dotnet add package ClosedXML --version 0.97.0
echo -e "namespace Spreadsheet.WebApi.Controllers;\n\npublic class LedgerController {}" > Controllers/LedgerController.cs
mkdir Models
echo -e "namespace Spreadsheet.WebApi.Models;\n\npublic class LedgerModel {}" > Models/LedgerModel.cs
echo -e "namespace Spreadsheet.WebApi.Models;\n\npublic class ItemModel {}" > Models/ItemModel.cs
mkdir Sheet
mkdir Sheet/Templates
echo -e "namespace Spreadsheet.WebApi.Sheet.Templates;\n\npublic class FormulaSheetTemplate {}" > Sheet/Templates/FormulaSheetTemplate.cs
echo -e "namespace Spreadsheet.WebApi.Sheet.Templates;\n\npublic class DatatypeSheetTemplate {}" > Sheet/Templates/DatatypeSheetTemplate.cs
echo -e "namespace Spreadsheet.WebApi.Sheet.Templates;\n\npublic class PinnedSheetTemplate {}" > Sheet/Templates/PinnedSheetTemplate.cs
dotnet run
```
