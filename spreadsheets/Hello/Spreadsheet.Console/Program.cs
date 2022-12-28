using ClosedXML.Excel;

/* base path of spreadsheets */
string basePath = "../spreadsheets/";

XLWorkbook xlWorkbook = new XLWorkbook();

xlWorkbook.Worksheets.Add("Hello").Cell("A1").SetValue<string>("Hello World");

/* save the workbook */
xlWorkbook.SaveAs($"{basePath}Hello.xlsx");
