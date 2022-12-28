using ClosedXML.Excel;

XLWorkbook xlWorkbook = new XLWorkbook();

xlWorkbook.Worksheets.Add("Hello").Cell("A1").SetValue<string>("Hello World");
