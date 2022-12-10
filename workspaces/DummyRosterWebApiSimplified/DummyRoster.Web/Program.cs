using DummyRoster.Common;

var builder = WebApplication.CreateBuilder(args);

/* todo */
builder.WebHost.UseUrls("https://127.0.0.1:5002");
builder.Services.AddCors();

var app = builder.Build();

/* todo */
app.UseCors(
  configurePolicy: options => {
    options.WithMethods("GET");
    options.WithOrigins("https://127.0.0.1:5001");
  }
);

app.MapGet("/", () => "Hello World!");

app.Run();
