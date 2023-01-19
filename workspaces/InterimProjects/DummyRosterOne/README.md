# DummyRosterOne

## Scaffolding of DummyRoster workspace

```shell
mkdir DummyRosterOne
cd DummyRosterOne
echo "# DummyRosterOne" > README.md
dotnet new gitignore
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
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 7.0.0-rc.2.22472.11
dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.0-rc.2.22472.11
rm Class1.cs
```

### Get classes from database tables

From the main workspace I type the following commands:

```shell
cd DummyRoster.Common.EntityModel
dotnet new tool-manifest
dotnet tool install --local dotnet-ef --version 7.0.0-rc.2.22472.11
dotnet ef dbcontext scaffold "Filename=../DummyRoster.db" Microsoft.EntityFrameworkCore.Sqlite --namespace DummyRoster.Common.EntityModel.Models --data-annotations --context-dir Data --output-dir Models
```

### Scaffolding of DummyRoster.Common.DataContext project

From the main workspace I type the following commands:

```shell
dotnet new classlib --name DummyRoster.Common.DataContext
cd DummyRoster.Common.DataContext
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 7.0.0-rc.2.22472.11
```

### Scaffolding of DummyRoster.Web project

```shell
dotnet new web --name DummyRoster.Web
cd DummyRoster.Web
dotnet watch
```

Note:
_"CTRL+R"_ to restart and _"CTRL+C"_ to stop
