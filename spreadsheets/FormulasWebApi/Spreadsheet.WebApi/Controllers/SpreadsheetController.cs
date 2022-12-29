using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Spreadsheet.WebApi.Templates;

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
      return this.File(
        fileContents: AdjuvantTemplate.Perform(memoryStream),
        contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
        fileDownloadName: "Generated.xlsx"
      );
    }
  }
}
