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

### Get classes from database tables

From the DummyRoster.Common.EntityModel directory I type the following commands:

```shell
dotnet new tool-manifest
dotnet tool install --local dotnet-ef --version 7.0.0
dotnet ef dbcontext scaffold "Filename=../DummyRoster.db" Microsoft.EntityFrameworkCore.Sqlite --namespace DummyRoster.Common.EntityModel.Models --data-annotations --context-dir Data --output-dir Models
```

### Scaffolding of DummyRoster.Common.DataContext project

From the main workspace I type the following commands:

```shell
dotnet new classlib --name DummyRoster.Common.DataContext
cd DummyRoster.Common.DataContext
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 7.0.0
mv --verbose ../DummyRoster.Common.EntityModel/Data .
rm Class1.cs
echo -e "namespace DummyRoster.Common.DataContext.Data;\npublic class DummyRosterContextExtensions {}" > Data/DummyRosterContextExtensions.cs
```

### Scaffolding of DummyRoster.Web project

From the main workspace I type the following commands:

```shell
dotnet new web --name DummyRoster.Web
cd DummyRoster.Web
echo -e "namespace DummyRoster.Web;\npublic class Startup {}" > Startup.cs
dotnet watch
```

Note:
_"CTRL+R"_ to restart and _"CTRL+C"_ to stop

### Scaffolding Razor class libraries

From the main workspace I type the following commands:

```shell
dotnet new razorclasslib --support-pages-and-views --name DummyRoster.Web.Employee
dotnet new razorclasslib --support-pages-and-views --name DummyRoster.Web.Customer
dotnet new razorclasslib --support-pages-and-views --name DummyRoster.Web.Supplier
dotnet new razorclasslib --support-pages-and-views --name DummyRoster.Web.Carrier
dotnet new razorclasslib --support-pages-and-views --name DummyRoster.Web.Category
dotnet new razorclasslib --support-pages-and-views --name DummyRoster.Web.Product
dotnet new razorclasslib --support-pages-and-views --name DummyRoster.Web.Form
dotnet new razorclasslib --support-pages-and-views --name DummyRoster.Web.Invoice
```
