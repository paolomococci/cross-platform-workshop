var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet(
  "/", 
  () => "Simple visual feedback from web application Knowledge!"
);

app.Run();
