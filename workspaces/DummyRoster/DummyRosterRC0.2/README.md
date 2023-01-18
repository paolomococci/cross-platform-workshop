# DummyRosterRC0.2

Release candidate which should implement both an webapi ​​and a mvc with Individual authentication, developed thanks to the .NET 7.0 framework.

## Scaffolding of DummyRosterRC0.2 workspace

```shell
mkdir DummyRosterRC0.2
cd DummyRosterRC0.2
echo "# DummyRosterRC0.2" > README.md
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
"Id" INTEGER PRIMARY KEY AUTOINCREMENT
```

## Scaffolding of DummyRoster.Common.EntityModel project

From the main workspace I type the following commands:

```shell
dotnet new classlib --framework "net7.0" --name DummyRoster.Common.EntityModel
cd DummyRoster.Common.EntityModel
rm Class1.cs
dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.1
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 7.0.1
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
dotnet new webapi --framework "net7.0" --name DummyRoster.WebApi
cd DummyRoster.WebApi
dotnet add package Microsoft.EntityFrameworkCore --version 7.0.1
dotnet add ./DummyRoster.WebApi.csproj reference ../DummyRoster.Common.EntityModel/DummyRoster.Common.EntityModel.csproj
mkdir Controllers/Interfaces
mkdir Repositories
mkdir Repositories/Interfaces
```

### REST request tests

From the DummyRoster.WebApi directory I type the following commands:

```shell
mkdir Tests
mkdir Tests/API
mkdir Tests/Forecasting
mkdir Tests/js
touch Tests/Forecasting/get_weather_forecast_tests.rest
touch Tests/API/employee_endpoint_tests.rest
touch Tests/API/customer_endpoint_tests.rest
touch Tests/API/supplier_endpoint_tests.rest
touch Tests/API/carrier_endpoint_tests.rest
touch Tests/API/address_endpoint_tests.rest
touch Tests/API/credential_endpoint_tests.rest
touch Tests/API/category_endpoint_tests.rest
touch Tests/API/product_endpoint_tests.rest
touch Tests/API/form_endpoint_tests.rest
touch Tests/API/invoice_endpoint_tests.rest
touch Tests/js/ComputeDataLength.js
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

### Add HTTP logging

After suitably modifying the Program.cs:

```text
...
using Microsoft.AspNetCore.HttpLogging;
...
builder.Services.AddHttpLogging(
  options => {
    options.LoggingFields = HttpLoggingFields.All;
    options.RequestBodyLogLimit = 4096;
    options.ResponseBodyLogLimit = 4096;
  }
);
...
app.UseHttpLogging();
...
```

Remember to edit file appsettings.Development.json as follows:

```text
...
      "Microsoft.AspNetCore": "Information"
...
```

### Finally, once the code has been developed and the necessary settings have been added, as far as project DummyRoster.WebApi is concerned, the time has come to test the API

```shell
dotnet clean
dotnet build
dotnet run
```

## Scaffolding of DummyRoster.Mvc project

From the main workspace I type the following commands:

```shell
dotnet new mvc --auth Individual --framework "net7.0" --name DummyRoster.Mvc
cd DummyRoster.Mvc
```

Note: sensitive data could be written as follows in file appsettings.json, excluding it from the source tree.

```text
  "UserAdmin": {
    "role": "Admins",
    "email": "your-example-email",
    "password": "your-example-password"
  }
```

Sensitive data which can then be retrieved via:

```text
private readonly IConfiguration configuration;
```

as done in DummyRoster.Mvc/Controllers/RolesController.cs

### and now you can proceed with the following commands

```shell
dotnet clean
dotnet build
dotnet run
```

At this point you need to login as an administrator.
You will immediately notice that access is denied.
Proceed with the logout and then enter the URL relating to "roles" directly in the address bar of the browser:

```text
https://127.0.0.1:8081/roles
```

And finally, the following confirmation message will appear on the console from which we launched the server:

```text
User: your-example-email added as Admins successfully.
```

From now on, with the right credentials, access will be allowed.

### From the DummyRoster.Mvc directory I add the reference to DummyRoster.Common.EntityModel:

```shell
dotnet add ./DummyRoster.Mvc.csproj reference ../DummyRoster.Common.EntityModel/DummyRoster.Common.EntityModel.csproj
```

### From the DummyRoster.Mvc directory I add a controllers for each entity to display:

```shell
echo -e "using Microsoft.AspNetCore.Mvc;\n\nnamespace DummyRoster.Mvc.Controllers;\n\npublic class EmployeesController : Controller {}" > Controllers/EmployeesController.cs
echo -e "using Microsoft.AspNetCore.Mvc;\n\nnamespace DummyRoster.Mvc.Controllers;\n\npublic class CustomersController : Controller {}" > Controllers/CustomersController.cs
echo -e "using Microsoft.AspNetCore.Mvc;\n\nnamespace DummyRoster.Mvc.Controllers;\n\npublic class SuppliersController : Controller {}" > Controllers/SuppliersController.cs
echo -e "using Microsoft.AspNetCore.Mvc;\n\nnamespace DummyRoster.Mvc.Controllers;\n\npublic class CarriersController : Controller {}" > Controllers/CarriersController.cs
echo -e "using Microsoft.AspNetCore.Mvc;\n\nnamespace DummyRoster.Mvc.Controllers;\n\npublic class AddressesController : Controller {}" > Controllers/AddressesController.cs
echo -e "using Microsoft.AspNetCore.Mvc;\n\nnamespace DummyRoster.Mvc.Controllers;\n\npublic class CredentialsController : Controller {}" > Controllers/CredentialsController.cs
echo -e "using Microsoft.AspNetCore.Mvc;\n\nnamespace DummyRoster.Mvc.Controllers;\n\npublic class CategoriesController : Controller {}" > Controllers/CategoriesController.cs
echo -e "using Microsoft.AspNetCore.Mvc;\n\nnamespace DummyRoster.Mvc.Controllers;\n\npublic class ProductsController : Controller {}" > Controllers/ProductsController.cs
echo -e "using Microsoft.AspNetCore.Mvc;\n\nnamespace DummyRoster.Mvc.Controllers;\n\npublic class FormsController : Controller {}" > Controllers/FormsController.cs
echo -e "using Microsoft.AspNetCore.Mvc;\n\nnamespace DummyRoster.Mvc.Controllers;\n\npublic class InvoicesController : Controller {}" > Controllers/InvoicesController.cs
```

### From the DummyRoster.Mvc directory I add a controller to manage the different roles:

```shell
echo -e "using Microsoft.AspNetCore.Mvc;\n\nnamespace DummyRoster.Mvc.Controllers;\n\npublic class RolesController : Controller {}" > Controllers/RolesController.cs
```

### From the DummyRoster.Mvc directory I add the following Razor files:

```shell
mkdir Views/Employees
echo -e "@using DummyRoster.Common.EntityModel.Models\n@model IEnumerable<Employee>\n\n<h1 class="display-4">@ViewData["Title"]</h1>" > Views/Employees/Employees.cshtml
mkdir Views/Customers
echo -e "@using DummyRoster.Common.EntityModel.Models\n@model IEnumerable<Customer>\n\n<h1 class="display-4">@ViewData["Title"]</h1>" > Views/Customers/Customers.cshtml
mkdir Views/Suppliers
echo -e "@using DummyRoster.Common.EntityModel.Models\n@model IEnumerable<Supplier>\n\n<h1 class="display-4">@ViewData["Title"]</h1>" > Views/Suppliers/Suppliers.cshtml
mkdir Views/Carriers
echo -e "@using DummyRoster.Common.EntityModel.Models\n@model IEnumerable<Carrier>\n\n<h1 class="display-4">@ViewData["Title"]</h1>" > Views/Carriers/Carriers.cshtml
mkdir Views/Addresses
echo -e "@using DummyRoster.Common.EntityModel.Models\n@model IEnumerable<Address>\n\n<h1 class="display-4">@ViewData["Title"]</h1>" > Views/Addresses/Addresses.cshtml
mkdir Views/Credentials
echo -e "@using DummyRoster.Common.EntityModel.Models\n@model IEnumerable<Credential>\n\n<h1 class="display-4">@ViewData["Title"]</h1>" > Views/Credentials/Credentials.cshtml
mkdir Views/Categories
echo -e "@using DummyRoster.Common.EntityModel.Models\n@model IEnumerable<Category>\n\n<h1 class="display-4">@ViewData["Title"]</h1>" > Views/Categories/Categories.cshtml
mkdir Views/Products
echo -e "@using DummyRoster.Common.EntityModel.Models\n@model IEnumerable<Product>\n\n<h1 class="display-4">@ViewData["Title"]</h1>" > Views/Products/Products.cshtml
mkdir Views/Forms
echo -e "@using DummyRoster.Common.EntityModel.Models\n@model IEnumerable<Form>\n\n<h1 class="display-4">@ViewData["Title"]</h1>" > Views/Forms/Forms.cshtml
mkdir Views/Invoices
echo -e "@using DummyRoster.Common.EntityModel.Models\n@model IEnumerable<Invoice>\n\n<h1 class="display-4">@ViewData["Title"]</h1>" > Views/Invoices/Invoices.cshtml
```

### Note, in file launchSettings.json:

```text
...

  "profiles": {
    "http": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "applicationUrl": "https://localhost:5011",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
...
```
