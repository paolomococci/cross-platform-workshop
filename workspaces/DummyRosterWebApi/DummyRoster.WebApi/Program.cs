using Microsoft.AspNetCore.Mvc.Formatters;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.AspNetCore.HttpLogging;
using DummyRoster.Common.DataContext.Data;
using DummyRoster.WebApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DummyRosterContext>();

// Add services to the container.

builder.Services.AddControllers(
  options =>
  {
    Console.WriteLine("default output formatter:");
    foreach (IOutputFormatter item in options.OutputFormatters)
    {
      OutputFormatter? outputFormatter = item as OutputFormatter;
      if (outputFormatter == null)
      {
        Console.WriteLine($" {item.GetType().Name}");
      }
      else
      {
        Console.WriteLine(
          $" {0}, media type: {1}",
          arg0: outputFormatter.GetType().Name,
          arg1: string.Join(", ", outputFormatter.SupportedMediaTypes)
        );
      }
    }
  }
).AddXmlDataContractSerializerFormatters().AddXmlSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
  temp => {
    temp.SwaggerDoc(
      "v1",
      new() {
        Title = "DummyRoster.WebApi project",
        Version = "v1"
      }
    );
  }
);

// Enabling HTTP logging: limit its use to the auditing and debugging stages!
/*
builder.Services.AddHttpLogging(
  options => {
    options.LoggingFields = HttpLoggingFields.All;
    options.RequestBodyLogLimit = 4096;
    options.ResponseBodyLogLimit = 4096;
  }
);
*/

// From here I add the interfaces and classes regarding the repositories.
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<ICarrierRepository, CarrierRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IFormRepository, FormRepository>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI(
    temp => {
      temp.SwaggerEndpoint(
        "/swagger/v1/swagger.json",
        "DummyRoster.WebApi project Version 1"
      );
      temp.SupportedSubmitMethods(
        new[] {
          SubmitMethod.Get,
          SubmitMethod.Post,
          SubmitMethod.Put,
          SubmitMethod.Delete
        }
      );
    }
  );
}

// HTTP logging
//app.UseHttpLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
