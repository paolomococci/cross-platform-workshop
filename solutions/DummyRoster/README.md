# DummyRoster project

## scaffolding

```shell
mkdir DummyRoster
cd DummyRoster
dotnet new gitignore
dotnet new sln
echo "# DummyRoster project" > README.md
mkdir src
cd src
mkdir core
mkdir infrastructure
mkdir presentation
cd core
dotnet new classlib --name DummyRoster.Common
dotnet new classlib --name DummyRoster.Common.EntityModel
dotnet new classlib --name DummyRoster.Common.DataContext
cd ../presentation
dotnet new webapi --name DummyRoster.WebApi
dotnet new webapp --name DummyRoster.Web
dotnet new mvc --name DummyRoster.Mvc
dotnet new webapi --name DummyRoster.OData
dotnet new webapi --name DummyRoster.GraphQL
dotnet new grpc --name DummyRoster.gRPC
```
