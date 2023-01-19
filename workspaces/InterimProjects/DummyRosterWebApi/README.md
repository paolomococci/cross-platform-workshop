# DummyRosterWebApi

## Scaffolding of DummyRosterWebApi workspace

```shell
mkdir DummyRosterWebApi
cd DummyRosterWebApi
echo "# DummyRosterWebApi" > README.md
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
echo -e "namespace DummyRoster.WebApi.Repositories;\n\npublic interface IEmployeeRepository {}" > IEmployeeRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories;\n\npublic interface ICustomerRepository {}" > ICustomerRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories;\n\npublic interface ISupplierRepository {}" > ISupplierRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories;\n\npublic interface ICarrierRepository {}" > ICarrierRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories;\n\npublic interface IAddressRepository {}" > IAddressRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories;\n\npublic interface ICategoryRepository {}" > ICategoryRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories;\n\npublic interface IProductRepository {}" > IProductRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories;\n\npublic interface IFormRepository {}" > IFormRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories;\n\npublic interface IInvoiceRepository {}" > IInvoiceRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories;\n\npublic class EmployeeRepository {}" > EmployeeRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories;\n\npublic class CustomerRepository {}" > CustomerRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories;\n\npublic class SupplierRepository {}" > SupplierRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories;\n\npublic class CarrierRepository {}" > CarrierRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories;\n\npublic class AddressRepository {}" > AddressRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories;\n\npublic class CategoryRepository {}" > CategoryRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories;\n\npublic class ProductRepository {}" > ProductRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories;\n\npublic class FormRepository {}" > FormRepository.cs
echo -e "namespace DummyRoster.WebApi.Repositories;\n\npublic class InvoiceRepository {}" > InvoiceRepository.cs
cd ../Controllers
echo -e "namespace DummyRoster.WebApi.Controllers;\n\npublic class EmployeeController {}" > EmployeeController.cs
echo -e "namespace DummyRoster.WebApi.Controllers;\n\npublic class CustomerController {}" > CustomerController.cs
echo -e "namespace DummyRoster.WebApi.Controllers;\n\npublic class SupplierController {}" > SupplierController.cs
echo -e "namespace DummyRoster.WebApi.Controllers;\n\npublic class CarrierController {}" > CarrierController.cs
echo -e "namespace DummyRoster.WebApi.Controllers;\n\npublic class AddressController {}" > AddressController.cs
echo -e "namespace DummyRoster.WebApi.Controllers;\n\npublic class CategoryController {}" > CategoryController.cs
echo -e "namespace DummyRoster.WebApi.Controllers;\n\npublic class ProductController {}" > ProductController.cs
echo -e "namespace DummyRoster.WebApi.Controllers;\n\npublic class FormController {}" > FormController.cs
echo -e "namespace DummyRoster.WebApi.Controllers;\n\npublic class InvoiceController {}" > InvoiceController.cs
```

## REST request tests

From the main workspace I type the following commands:

```shell
mkdir RestRequestTests
cd RestRequestTests
touch get_weather_forecast_tests.http
touch employee_endpoint_test.http
touch customer_endpoint_test.http
touch supplier_endpoint_test.http
touch carrier_endpoint_test.http
touch address_endpoint_test.http
touch category_endpoint_test.http
touch product_endpoint_test.http
touch form_endpoint_test.http
touch invoice_endpoint_test.http
```

## Please note

Attention, for the database to automatically generate incrementally the identifiers must be indicated as follows:

```text
...
"Id" INTEGER PRIMARY KEY AUTOINCREMENT
...
```

And also the context .cs file must contain the following code in the OnConfiguring method:

```text
...
    modelBuilder.Entity<Address>(entity =>
    {
      entity.Property(e => e.Id).ValueGeneratedOnAdd();
    });
...
```
