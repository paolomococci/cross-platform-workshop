# DummyRosterWebApiSimplified

## Scaffolding of DummyRosterWebApiSimplified workspace

```shell
mkdir DummyRosterWebApiSimplified
cd DummyRosterWebApiSimplified
echo "# DummyRosterWebApiSimplified" > README.md
dotnet new gitignore
```

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

### Scaffolding of DummyRoster.Common project

From the main workspace I type the following commands:

```shell
dotnet new classlib --name DummyRoster.Common
cd DummyRoster.Common
mv Class1.cs Forecast.cs
```

### Scaffolding of DummyRoster.Web project

From the main workspace I type the following commands:

```shell
dotnet new web --name DummyRoster.Web
cd DummyRoster.Web
dotnet add ./DummyRoster.Web.csproj reference ../DummyRoster.Common/DummyRoster.Common.csproj
dotnet clean
dotnet build
dotnet run
```
