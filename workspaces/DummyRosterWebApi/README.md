# DummyRosterWebApi

## Scaffolding of DummyRosterWebApi workspace

```shell
mkdir DummyRosterWebApi
cd DummyRosterWebApi
echo "# DummyRosterWebApi > README.md
dotnet new gitignore
```

### Scaffolding of DummyRoster.WebApi project

From the main workspace I type the following commands:

```shell
dotnet new webapi --name DummyRoster.WebApi
sqlite3 DummyRoster.db -init dummyroster.sql
```
