var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet(
  "/", 
  () => "Functional feedback from application PivotUp"
);

app.Run();
