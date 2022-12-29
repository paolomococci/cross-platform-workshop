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
    foreach (XLWorksheet sheetName in sheetNames)
    {
      XLWorksheet xlWorksheet = xlWorkbook.Worksheets.Add(sheetName);
      xlWorksheet.Cell("A1").Value = sheetName;
    }

    /* adds data and formulas to a specific spreadsheet */
    

    xlWorkbook.SaveAs(memoryStream);
    memoryStream.Seek(
      0,
      SeekOrigin.Begin
    );
    return memoryStream.ToArray();
  }
}
