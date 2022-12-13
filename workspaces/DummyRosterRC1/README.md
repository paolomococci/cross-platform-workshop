# DummyRosterRC1

Release candidate which should implement both an webapi ​​and a blazorserver interface.

## Scaffolding of DummyRosterRC1 workspace

```shell
mkdir DummyRosterRC1
cd DummyRosterRC1
echo "# DummyRosterRC1" > README.md
dotnet new gitignore
```

## Initializing database SQLite DummyRoster.db

From the main workspace I type the following commands:

```shell
sqlite3 DummyRoster.db -init dummyroster.sql
```

On Linux, to exit the sqlite command prompt, type the following string:

```text
.quit
```

and then give enter.

### Please note

Attention, for the database to automatically generate incrementally the identifiers must be indicated as follows:

```text
...
"Id" INTEGER PRIMARY KEY AUTOINCREMENT
...
```

## Scaffolding of DummyRoster.Common.EntityModel project

From the main workspace I type the following commands:

```shell
dotnet new classlib --name DummyRoster.Common.EntityModel
cd DummyRoster.Common.EntityModel
rm Class1.cs
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 7.0.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.0
```

### Migration of entity classes from database tables

From the DummyRoster.Common.EntityModel directory I type the following commands:

```shell
dotnet new tool-manifest
dotnet tool install --local dotnet-ef --version 7.0.0
dotnet ef dbcontext scaffold "Filename=../DummyRoster.db" Microsoft.EntityFrameworkCore.Sqlite --namespace DummyRoster.Common.EntityModel.Models --data-annotations --context-dir Data --output-dir Models
cd DummyRoster.Common.EntityModel
dotnet clean
dotnet build
```

### Scaffolding of DummyRoster.WebApi project

From the main workspace I type the following commands:

```shell
dotnet new webapi --name DummyRoster.WebApi
cd DummyRoster.WebApi
mkdir Controllers/Interfaces
mkdir Repositories
mkdir Repositories/Interfaces
```
