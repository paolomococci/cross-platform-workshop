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
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 7.0.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.0
```

### Migration of entity classes from database tables

From the DummyRoster.Common.EntityModel directory I type the following commands:

```shell
dotnet new tool-manifest
dotnet tool install --local dotnet-ef --version 7.0.0
dotnet ef dbcontext scaffold "Filename=../DummyRoster.db" Microsoft.EntityFrameworkCore.Sqlite --namespace DummyRoster.Common.EntityModel.Models --data-annotations --context-dir Data --output-dir Models
cd DummyRoster.Common.EntityModel
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
cd Tests
touch get_weather_forecast_tests.rest
touch employee_endpoint_test.rest
touch customer_endpoint_test.rest
touch supplier_endpoint_test.rest
touch carrier_endpoint_test.rest
touch address_endpoint_test.rest
touch category_endpoint_test.rest
touch product_endpoint_test.rest
touch form_endpoint_test.rest
touch invoice_endpoint_test.rest
```

### From the DummyRoster.WebApi directory add the following repositories

```shell
cd Repositories/Interfaces
echo -e "namespace DummyRoster.WebApi.Repositories.Interfaces;\n\npublic interface IEmployeeRepository {}" > IEmployeeRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories.Interfaces;\n\npublic interface ICustomerRepository {}" > ICustomerRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories.Interfaces;\n\npublic interface ISupplierRepository {}" > ISupplierRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories.Interfaces;\n\npublic interface ICarrierRepository {}" > ICarrierRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories.Interfaces;\n\npublic interface IAddressRepository {}" > IAddressRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories.Interfaces;\n\npublic interface ICategoryRepository {}" > ICategoryRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories.Interfaces;\n\npublic interface IProductRepository {}" > IProductRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories.Interfaces;\n\npublic interface IFormRepository {}" > IFormRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories.Interfaces;\n\npublic interface IInvoiceRepository {}" > IInvoiceRepository.cs
cd ..
echo -e "namespace DummyRoster.WebApi.Repositories;\n\npublic class EmployeeRepository {}" > EmployeeRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories;\n\npublic class CustomerRepository {}" > CustomerRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories;\n\npublic class SupplierRepository {}" > SupplierRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories;\n\npublic class CarrierRepository {}" > CarrierRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories;\n\npublic class AddressRepository {}" > AddressRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories;\n\npublic class CategoryRepository {}" > CategoryRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories;\n\npublic class ProductRepository {}" > ProductRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories;\n\npublic class FormRepository {}" > FormRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories;\n\npublic class InvoiceRepository {}" > InvoiceRepository.cs
```

## From the DummyRoster.WebApi directory add the following controllers

```shell
echo -e "namespace DummyRoster.WebApi.Controllers.Interfaces;\n\npublic interface IEmployeeController {}" > Controllers/Interfaces/IEmployeeController.cs
echo -e "namespace DummyRoster.WebApi.Controllers.Interfaces;\n\npublic interface ICustomerController {}" > Controllers/Interfaces/ICustomerController.cs
echo -e "namespace DummyRoster.WebApi.Controllers.Interfaces;\n\npublic interface ISupplierController {}" > Controllers/Interfaces/ISupplierController.cs
echo -e "namespace DummyRoster.WebApi.Controllers.Interfaces;\n\npublic interface ICarrierController {}" > Controllers/Interfaces/ICarrierController.cs
echo -e "namespace DummyRoster.WebApi.Controllers.Interfaces;\n\npublic interface IAddressController {}" > Controllers/Interfaces/IAddressController.cs
echo -e "namespace DummyRoster.WebApi.Controllers.Interfaces;\n\npublic interface ICategoryController {}" > Controllers/Interfaces/ICategoryController.cs
echo -e "namespace DummyRoster.WebApi.Controllers.Interfaces;\n\npublic interface IProductController {}" > Controllers/Interfaces/IProductController.cs
echo -e "namespace DummyRoster.WebApi.Controllers.Interfaces;\n\npublic interface IFormController {}" > Controllers/Interfaces/IFormController.cs
echo -e "namespace DummyRoster.WebApi.Controllers.Interfaces;\n\npublic interface IInvoiceController {}" > Controllers/Interfaces/IInvoiceController.cs
echo -e "namespace DummyRoster.WebApi.Controllers.Interfaces;\n\npublic interface IHomeController {}" > Controllers/Interfaces/IHomeController.cs
echo -e "namespace DummyRoster.WebApi.Controllers;\n\npublic class EmployeeController {}" > Controllers/EmployeeController.cs
echo -e "namespace DummyRoster.WebApi.Controllers;\n\npublic class CustomerController {}" > Controllers/CustomerController.cs
echo -e "namespace DummyRoster.WebApi.Controllers;\n\npublic class SupplierController {}" > Controllers/SupplierController.cs
echo -e "namespace DummyRoster.WebApi.Controllers;\n\npublic class CarrierController {}" > Controllers/CarrierController.cs
echo -e "namespace DummyRoster.WebApi.Controllers;\n\npublic class AddressController {}" > Controllers/AddressController.cs
echo -e "namespace DummyRoster.WebApi.Controllers;\n\npublic class CategoryController {}" > Controllers/CategoryController.cs
echo -e "namespace DummyRoster.WebApi.Controllers;\n\npublic class ProductController {}" > Controllers/ProductController.cs
echo -e "namespace DummyRoster.WebApi.Controllers;\n\npublic class FormController {}" > Controllers/FormController.cs
echo -e "namespace DummyRoster.WebApi.Controllers;\n\npublic class InvoiceController {}" > Controllers/InvoiceController.cs
echo -e "namespace DummyRoster.WebApi.Controllers;\n\npublic class HomeController {}" > Controllers/HomeController.cs
```
