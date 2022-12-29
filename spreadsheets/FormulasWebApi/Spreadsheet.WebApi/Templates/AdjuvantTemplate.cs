using ClosedXML.Excel;

namespace Spreadsheet.WebApi.Templates;

public class AdjuvantTemplate
{
  public static byte[] Perform(MemoryStream memoryStream)
  {
    /* generate the workbook */
    XLWorkbook xlWorkbook = new XLWorkbook();

    /* adds three spreadsheets */
    List<string> sheetNames = new List<string>() {
        "Sheet1",
        "Sheet2",
        "Sheet3"
      };
    foreach (var sheetName in sheetNames)
    {
      var xlWorksheet = xlWorkbook.Worksheets.Add(sheetName);
      xlWorksheet.Cell("A1").Value = sheetName;
    }

    /* adds data and formulas to a specific spreadsheet */
    var sheet1 = xlWorkbook.Worksheet(1);
    sheet1.Cell("B1").SetValue("Values");
    sheet1.Cell("B2").SetValue(4.55);
    sheet1.Cell("B3").SetValue(2.55);
    sheet1.Cell("B4").SetValue(4.2);
    sheet1.Cell("B5").SetValue(3.33);
    sheet1.Cell("A6").SetValue("Sum");
    sheet1.Cell("A7").SetValue("Average");
    sheet1.Cell("B6").FormulaA1 = "SUM(B2:B5)";
    sheet1.Cell("B7").FormulaA1 = "AVERAGE(B2:B5)";

    /* pack it all up */
    xlWorkbook.SaveAs(memoryStream);
    memoryStream.Seek(
      0,
      SeekOrigin.Begin
    );
    return memoryStream.ToArray();
  }
}
