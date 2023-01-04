var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("https://localhost:8083");
builder.Services.AddCors();
builder.Services.AddControllers();

var app = builder.Build();
app.UseCors(
  configurePolicy: options => {
    options.WithMethods("GET");
    options.WithOrigins("https://localhost:8081");
  }
);
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
