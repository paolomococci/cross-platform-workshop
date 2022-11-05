# DummyRoster solution

## scaffolding

```shell
mkdir DummyRoster
cd DummyRoster
dotnet new gitignore
dotnet new sln
echo "# DummyRoster solution" > README.md
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
dotnet new razorclasslib --name DummyRoster.Razor
cd DummyRoster.Razor
dotnet new razorcomponent --name Employee
dotnet new razorcomponent --name Customer
dotnet new razorcomponent --name Supplier
dotnet new razorcomponent --name Carrier
dotnet new razorcomponent --name Category
dotnet new razorcomponent --name Product
dotnet new razorcomponent --name Form
dotnet new razorcomponent --name Invoice
cd ..
mkdir RestRequestTests
cd RestRequestTests
touch get_employee_endpoint_test.http
touch get_customer_endpoint_test.http
touch get_supplier_endpoint_test.http
touch get_carrier_endpoint_test.http
touch get_category_endpoint_test.http
touch get_product_endpoint_test.http
touch get_form_endpoint_test.http
touch get_invoice_endpoint_test.http
cd ..
dotnet new blazorserver --name DummyRoster.BlazorServer
dotnet new blazorwasm --name DummyRoster.BlazorWasm
dotnet new angular --name DummyRoster.Angular
```

## now it's time to add the projects to the solution file

```shell
dotnet sln add src/core/DummyRoster.Common/DummyRoster.Common.csproj
dotnet sln add src/core/DummyRoster.Common.DataContext/DummyRoster.Common.DataContext.csproj
```
