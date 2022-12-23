using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.HttpLogging;
using Swashbuckle.AspNetCore.SwaggerUI;
using DummyRoster.Common.EntityModel.Data;
using DummyRoster.WebApi.Repositories.Interfaces;
using DummyRoster.WebApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<DummyRosterContext>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
