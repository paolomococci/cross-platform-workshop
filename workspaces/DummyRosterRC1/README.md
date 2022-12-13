# DummyRosterRC1

Release candidate which should implement both an webapi ​​and a blazorserver interface.

## Scaffolding of DummyRosterRC1 workspace

```shell
mkdir DummyRosterRC1
cd DummyRosterRC1
echo "# DummyRosterRC1" > README.md
dotnet new gitignore
```

## Initializing database SQLite

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
