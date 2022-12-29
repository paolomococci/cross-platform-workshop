using ClosedXML.Excel;

namespace Spreadsheet.WebApi.Templates;

public class AdjuvantTemplate
{
  public static byte[] Perform(MemoryStream memoryStream)
  {
    XLWorkbook xlWorkbook = new XLWorkbook();
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
    xlWorkbook.SaveAs(memoryStream);
    memoryStream.Seek(
      0,
      SeekOrigin.Begin
    );
    return memoryStream.ToArray();
  }
}
