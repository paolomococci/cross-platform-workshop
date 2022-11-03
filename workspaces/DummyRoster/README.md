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
```
