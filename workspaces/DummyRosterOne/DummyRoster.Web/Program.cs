var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseHsts();
  //app.UseDeveloperExceptionPage();
}
app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");

app.Run();
