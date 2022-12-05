# DummyRosterWebApiImproved

## Scaffolding of DummyRosterWebApiImproved workspace

```shell
mkdir DummyRosterWebApiImproved
cd DummyRosterWebApiImproved
echo "# DummyRosterWebApiImproved" > README.md
dotnet new gitignore
```

### Scaffolding of DummyRoster.WebApi project

From the main workspace I type the following commands:

```shell
dotnet new webapi --name DummyRoster.WebApi
sqlite3 DummyRoster.db -init dummyroster.sql
```

On Linux, to exit the sqlite command prompt, type the following string:

```text
.quit
```

and then give enter.

### Scaffolding of DummyRoster.Common.EntityModel project

From the main workspace I type the following commands:

```shell
dotnet new classlib --name DummyRoster.Common.EntityModel
cd DummyRoster.Common.EntityModel
rm Class1.cs
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 7.0.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.0
```

### Get classes from database tables

From the DummyRoster.Common.EntityModel directory I type the following commands:

```shell
dotnet new tool-manifest
dotnet tool install --local dotnet-ef --version 7.0.0
dotnet ef dbcontext scaffold "Filename=../DummyRoster.db" Microsoft.EntityFrameworkCore.Sqlite --namespace DummyRoster.Common.EntityModel.Models --data-annotations --context-dir Data --output-dir Models
```

### Scaffolding of DummyRoster.Common.DataContext project

From the main workspace I type the following commands:

```shell
dotnet new classlib --name DummyRoster.Common.DataContext
cd DummyRoster.Common.DataContext
rm Class1.cs
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 7.0.0
mv --verbose ../DummyRoster.Common.EntityModel/Data .
echo -e "namespace DummyRoster.Common.DataContext.Data;\n\npublic class DummyRosterContextExtensions {}" > Data/DummyRosterContextExtensions.cs
dotnet add ./DummyRoster.Common.DataContext.csproj reference ../DummyRoster.Common.EntityModel/DummyRoster.Common.EntityModel.csproj
dotnet clean
dotnet build
```

### From the DummyRoster.WebApi project add a reference to the DummyRoster.Common.DataContext project

```shell
cd ../DummyRoster.WebApi
dotnet add ./DummyRoster.WebApi.csproj reference ../DummyRoster.Common.DataContext/DummyRoster.Common.DataContext.csproj
dotnet clean
dotnet build
dotnet run
```
