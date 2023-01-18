# DummyRosterRC1

Release candidate which should implement both an webapi ​​and a blazorserver interface.

## Scaffolding of DummyRosterRC1 workspace

```shell
mkdir DummyRosterRC1
cd DummyRosterRC1
echo "# DummyRosterRC1" > README.md
dotnet new gitignore
```

## Initializing database SQLite DummyRoster.db

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

## Scaffolding of DummyRoster.Common.EntityModel project

From the main workspace I type the following commands:

```shell
dotnet new classlib --name DummyRoster.Common.EntityModel
cd DummyRoster.Common.EntityModel
rm Class1.cs
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 7.0.1
dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.1
```

### Migration of entity classes from database tables

From the DummyRoster.Common.EntityModel directory I type the following commands:

```shell
dotnet new tool-manifest
dotnet tool install --local dotnet-ef --version 7.0.1
dotnet ef dbcontext scaffold "Filename=../DummyRoster.db" Microsoft.EntityFrameworkCore.Sqlite --namespace DummyRoster.Common.EntityModel.Models --data-annotations --context-dir Data --output-dir Models
dotnet clean
dotnet build
```

## Scaffolding of DummyRoster.WebApi project

From the main workspace I type the following commands:

```shell
dotnet new webapi --name DummyRoster.WebApi
cd DummyRoster.WebApi
dotnet add ./DummyRoster.WebApi.csproj reference ../DummyRoster.Common.EntityModel/DummyRoster.Common.EntityModel.csproj
mkdir Controllers/Interfaces
mkdir Controllers/Interfaces
```

### REST request tests

From the DummyRoster.WebApi directory I type the following commands:

```shell
mkdir Tests
touch Tests/get_weather_forecast_tests.rest
touch Tests/employee_endpoint_tests.rest
touch Tests/customer_endpoint_tests.rest
touch Tests/supplier_endpoint_tests.rest
touch Tests/carrier_endpoint_tests.rest
touch Tests/address_endpoint_tests.rest
touch Tests/credential_endpoint_tests.rest
touch Tests/category_endpoint_tests.rest
touch Tests/product_endpoint_tests.rest
touch Tests/form_endpoint_tests.rest
touch Tests/invoice_endpoint_tests.rest
```

### From the DummyRoster.WebApi directory add the following repositories

```shell
echo -e "namespace DummyRoster.WebApi.Repositories.Interfaces;\n\npublic interface IEmployeeRepository {}" > Repositories/Interfaces/IEmployeeRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories.Interfaces;\n\npublic interface ICustomerRepository {}" > Repositories/Interfaces/ICustomerRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories.Interfaces;\n\npublic interface ISupplierRepository {}" > Repositories/Interfaces/ISupplierRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories.Interfaces;\n\npublic interface ICarrierRepository {}" > Repositories/Interfaces/ICarrierRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories.Interfaces;\n\npublic interface IAddressRepository {}" > Repositories/Interfaces/IAddressRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories.Interfaces;\n\npublic interface ICredentialRepository {}" > Repositories/Interfaces/ICredentialRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories.Interfaces;\n\npublic interface ICategoryRepository {}" > Repositories/Interfaces/ICategoryRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories.Interfaces;\n\npublic interface IProductRepository {}" > Repositories/Interfaces/IProductRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories.Interfaces;\n\npublic interface IFormRepository {}" > Repositories/Interfaces/IFormRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories.Interfaces;\n\npublic interface IInvoiceRepository {}" > Repositories/Interfaces/IInvoiceRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories;\n\npublic class EmployeeRepository {}" > Repositories/EmployeeRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories;\n\npublic class CustomerRepository {}" > Repositories/CustomerRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories;\n\npublic class SupplierRepository {}" > Repositories/SupplierRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories;\n\npublic class CarrierRepository {}" > Repositories/CarrierRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories;\n\npublic class AddressRepository {}" > Repositories/AddressRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories;\n\npublic class CredentialRepository {}" > Repositories/CredentialRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories;\n\npublic class CategoryRepository {}" > Repositories/CategoryRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories;\n\npublic class ProductRepository {}" > Repositories/ProductRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories;\n\npublic class FormRepository {}" > Repositories/FormRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories;\n\npublic class InvoiceRepository {}" > Repositories/InvoiceRepository.cs
```

### From the DummyRoster.WebApi directory add the following controllers

```shell
echo -e "namespace DummyRoster.WebApi.Controllers.Interfaces;\n\npublic interface IEmployeeController {}" > Controllers/Interfaces/IEmployeeController.cs
echo -e "namespace DummyRoster.WebApi.Controllers.Interfaces;\n\npublic interface ICustomerController {}" > Controllers/Interfaces/ICustomerController.cs
echo -e "namespace DummyRoster.WebApi.Controllers.Interfaces;\n\npublic interface ISupplierController {}" > Controllers/Interfaces/ISupplierController.cs
echo -e "namespace DummyRoster.WebApi.Controllers.Interfaces;\n\npublic interface ICarrierController {}" > Controllers/Interfaces/ICarrierController.cs
echo -e "namespace DummyRoster.WebApi.Controllers.Interfaces;\n\npublic interface IAddressController {}" > Controllers/Interfaces/IAddressController.cs
echo -e "namespace DummyRoster.WebApi.Controllers.Interfaces;\n\npublic interface ICredentialController {}" > Controllers/Interfaces/ICredentialController.cs
echo -e "namespace DummyRoster.WebApi.Controllers.Interfaces;\n\npublic interface ICategoryController {}" > Controllers/Interfaces/ICategoryController.cs
echo -e "namespace DummyRoster.WebApi.Controllers.Interfaces;\n\npublic interface IProductController {}" > Controllers/Interfaces/IProductController.cs
echo -e "namespace DummyRoster.WebApi.Controllers.Interfaces;\n\npublic interface IFormController {}" > Controllers/Interfaces/IFormController.cs
echo -e "namespace DummyRoster.WebApi.Controllers.Interfaces;\n\npublic interface IInvoiceController {}" > Controllers/Interfaces/IInvoiceController.cs
echo -e "namespace DummyRoster.WebApi.Controllers;\n\npublic class EmployeeController {}" > Controllers/EmployeeController.cs
echo -e "namespace DummyRoster.WebApi.Controllers;\n\npublic class CustomerController {}" > Controllers/CustomerController.cs
echo -e "namespace DummyRoster.WebApi.Controllers;\n\npublic class SupplierController {}" > Controllers/SupplierController.cs
echo -e "namespace DummyRoster.WebApi.Controllers;\n\npublic class CarrierController {}" > Controllers/CarrierController.cs
echo -e "namespace DummyRoster.WebApi.Controllers;\n\npublic class AddressController {}" > Controllers/AddressController.cs
echo -e "namespace DummyRoster.WebApi.Controllers;\n\npublic class CredentialController {}" > Controllers/CredentialController.cs
echo -e "namespace DummyRoster.WebApi.Controllers;\n\npublic class CategoryController {}" > Controllers/CategoryController.cs
echo -e "namespace DummyRoster.WebApi.Controllers;\n\npublic class ProductController {}" > Controllers/ProductController.cs
echo -e "namespace DummyRoster.WebApi.Controllers;\n\npublic class FormController {}" > Controllers/FormController.cs
echo -e "namespace DummyRoster.WebApi.Controllers;\n\npublic class InvoiceController {}" > Controllers/InvoiceController.cs
```

### Add Entity Framework Core database health checks

From the DummyRoster.WebApi directory:

```shell
dotnet add package Microsoft.Extensions.Diagnostics.HealthChecks.EntityFrameworkCore --version 6.0.12
```

### Finally, once the code has been developed and the necessary settings have been added, as far as project DummyRoster.WebApi is concerned, the time has come to test the API

```shell
dotnet clean
dotnet build
dotnet run
```

## Scaffolding of DummyRoster.BlazorServer project

From the main workspace I type the following commands:

```shell
dotnet new blazorserver --name DummyRoster.BlazorServer
cd DummyRoster.BlazorServer
dotnet clean
dotnet build
dotnet run
```
