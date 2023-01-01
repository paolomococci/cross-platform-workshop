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
echo -e "namespace Spreadsheet.WebApi.Controllers;\n\npublic class SpreadsheetController {}" > Controllers/SpreadsheetController.cs
dotnet run
```
