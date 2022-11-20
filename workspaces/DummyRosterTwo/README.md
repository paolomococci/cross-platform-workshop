# DummyRosterTwo

## Scaffolding of DummyRosterTwo workspace

```shell
mkdir DummyRosterTwo
cd DummyRosterTwo
echo "# DummyRosterTwo" > README.md
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
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 7.0.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.0
rm Class1.cs
```
