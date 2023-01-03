var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Pivot.Web project feedback message.");

app.Run();
