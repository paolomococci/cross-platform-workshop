using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;

namespace Spreadsheet.WebApi.Controllers;

[ApiController]
[Route("api/spreadsheets")]
public class SpreadsheetController : ControllerBase
{

  /* 
    GET: api/spreadsheets/generated
   */
  [HttpGet("generated")]
  [ProducesResponseType(200)]
  public IActionResult Generate()
  {
    using (MemoryStream memoryStream = new MemoryStream())
    {
      var xlWorkbook = new XLWorkbook();
      var sheetNames = new List<string>() {
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
      return this.File(
        fileContents: memoryStream.ToArray(),
        contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
        fileDownloadName: "Generated.xlsx"
      );
    }
  }
}
