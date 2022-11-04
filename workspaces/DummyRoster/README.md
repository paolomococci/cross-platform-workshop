# DummyRoster workspace

## scaffolding

```shell
mkdir DummyRoster
cd DummyRoster
echo "# DummyRoster workspace" > README.md
dotnet new gitignore
dotnet new classlib --name DummyRoster.Common.EntityModel
cd DummyRoster.Common.EntityModel
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 7.0.0-rc.2.22472.11
dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.0-rc.2.22472.11
rm Class1.cs
cd ..
sqlite3 DummyRoster.db -init dummyroster.sql
```

On Linux, to exit the sqlite command prompt, type the following string:
.quit
and then give enter.

## get classes from database tables

```shell
cd Microsoft.EntityFrameworkCore.Sqlite
dotnet new tool-manifest
dotnet tool install --local dotnet-ef --version 7.0.0-rc.2.22472.11
dotnet ef dbcontext scaffold "Filename=../DummyRoster.db" Microsoft.EntityFrameworkCore.Sqlite --namespace DummyRoster.Common.EntityModel.Models --data-annotations --context-dir Data --output-dir Models
```
