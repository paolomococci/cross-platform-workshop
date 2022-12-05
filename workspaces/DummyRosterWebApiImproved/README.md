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
