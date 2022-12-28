using ClosedXML.Excel;

XLWorkbook xlWorkbook = new XLWorkbook();
xlWorkbook.Worksheets.Add("Hello").Cell("A1").SetValue<string>("Hello World!");

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
