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
```
