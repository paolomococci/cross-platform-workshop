using DummyRoster.Common;

var builder = WebApplication.CreateBuilder(args);

/* todo */
builder.WebHost.UseUrls("https://127.0.0.1:5008");
builder.Services.AddCors();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
