# DummyRosterWebApiRouged

## Scaffolding of DummyRosterWebApiRouged workspace

```shell
mkdir DummyRosterWebApiRouged
cd DummyRosterWebApiRouged
echo "# DummyRosterWebApiRouged" > README.md
dotnet new gitignore
```

### Scaffolding of DummyRoster.WebApi project

From the main workspace I type the following commands:

```shell
dotnet new webapi --name DummyRoster.WebApi
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

### Scaffolding of DummyRoster.Common.EntityModel project

From the main workspace I type the following commands:

```shell
dotnet new classlib --name DummyRoster.Common.EntityModel
cd DummyRoster.Common.EntityModel
rm Class1.cs
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 7.0.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.0
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
rm Class1.cs
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 7.0.0
mv --verbose ../DummyRoster.Common.EntityModel/Data .
echo -e "namespace DummyRoster.Common.DataContext.Data;\n\npublic class DummyRosterContextExtensions {}" > Data/DummyRosterContextExtensions.cs
dotnet add ./DummyRoster.Common.DataContext.csproj reference ../DummyRoster.Common.EntityModel/DummyRoster.Common.EntityModel.csproj
dotnet clean
dotnet build
```

### From the DummyRoster.WebApi project add a reference to the DummyRoster.Common.DataContext project

```shell
cd ../DummyRoster.WebApi
dotnet add ./DummyRoster.WebApi.csproj reference ../DummyRoster.Common.DataContext/DummyRoster.Common.DataContext.csproj
dotnet clean
dotnet build
dotnet run
mkdir Repositories
cd Repositories
mkdir Interfaces
cd Interfaces
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

## REST request tests

From the main workspace I type the following commands:

```shell
mkdir RestRequestTests
cd RestRequestTests
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

## From the DummyRoster.WebApi project add the following controllers

```shell
mkdir Controllers/Interfaces
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

### create a customers view

```shell
mkdir Views
mkdir Views/Home
echo -e "@{}\n\n<div></div>" > Views/Home/Index.cshtml
echo -e "@using DummyRoster.Common.EntityModel.Models\n@model IEnumerable<Customer>" > Views/Home/Customers.cshtml
```
