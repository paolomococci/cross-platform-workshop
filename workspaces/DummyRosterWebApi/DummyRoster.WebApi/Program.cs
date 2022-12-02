using Microsoft.AspNetCore.Mvc.Formatters;
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
builder.Services.AddSwaggerGen();

// From here I add the interfaces and classes regarding the repositories.
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<ICarrierRepository, CarrierRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
