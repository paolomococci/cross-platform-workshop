using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient(
  name: "Pivot.Api",
  configureClient: options => {
    options.BaseAddress = new Uri("https://localhost:8083/");
    options.DefaultRequestHeaders.Accept.Add(
      new MediaTypeWithQualityHeaderValue(
        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
      )
    );
  }
);

var app = builder.Build();

app.MapGet(
  "/pivot",
  () => Results.Ok("https://localhost:8083/api/pivot")
);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
