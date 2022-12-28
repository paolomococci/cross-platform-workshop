# HelloWebApi

This trace is useful if you want to process and distribute spreadsheets thanks to the web.

## Scaffolding

```shell
mkdir HelloWebApi
cd HelloWebApi
dotnet new gitignore
dotnet new webapi -o Spreadsheet.WebApi
cd Spreadsheet.WebApi
dotnet add package ClosedXML --version 0.97.0
dotnet run
```
