# DummyRosterRC2

Release candidate which should implement both an webapi ​​and a blazorserver with Individual authentication.

## Scaffolding of DummyRosterRC2 workspace

```shell
mkdir DummyRosterRC2
cd DummyRosterRC2
echo "# DummyRosterRC2" > README.md
dotnet new gitignore
```

## I continue by generating the projects within the workspace

```shell
dotnet new blazorserver --auth Individual --framework "net7.0" --name DummyRoster.BlazorServer
dotnet new classlib --framework "net7.0" --name DummyRoster.Common.EntityModel
dotnet new webapi --framework "net7.0" --name DummyRoster.WebApi
```

## Development of DummyRoster.Common.EntityModel project

```shell
cd DummyRoster.Common.EntityModel
rm Class1.cs
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 7.0.1
dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.1
```

### Migration of entity classes from database tables

From the DummyRoster.Common.EntityModel directory I type the following commands:

```shell
dotnet new tool-manifest
dotnet tool install --local dotnet-ef --version 7.0.1
dotnet ef dbcontext scaffold "Filename=../DummyRoster.db" Microsoft.EntityFrameworkCore.Sqlite --namespace DummyRoster.Common.EntityModel.Models --data-annotations --context-dir Data --output-dir Models
dotnet clean
dotnet build
```
