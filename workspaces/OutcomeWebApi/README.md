# OutcomeWebApi

## Scaffolding of OutcomeWebApi workspace

```shell
mkdir OutcomeWebApi
cd OutcomeWebApi
echo "# OutcomeWebApi" > README.md
dotnet new gitignore
```

### Scaffolding of Outcome.Common project

From the main workspace I type the following commands:

```shell
dotnet new classlib --name Outcome.Common
cd Outcome.Common
mv Class1.cs Forecast.cs
```

### Scaffolding of Outcome.Web project

From the main workspace I type the following commands:

```shell
dotnet new web --name Outcome.Web
cd Outcome.Web
dotnet add ./Outcome.Web.csproj reference ../Outcome.Common/Outcome.Common.csproj
dotnet clean
dotnet build
dotnet run
```
