using Microsoft.AspNetCore.Mvc;
using Pivot.Common.Models;

namespace Pivot.Web.Controllers;


[ApiController]
[Route("api/spreadsheets")]
public class LedgerController : ControllerBase
{
  /* 
    GET: http://localhost:8080/api/spreadsheets/generated
   */
  [HttpGet("generated")]
  [ProducesResponseType(200)]
  public IActionResult Generate()
  {
    using (MemoryStream memoryStream = new MemoryStream())
    {
      return this.File(
        fileContents: LedgerModel.Perform(memoryStream),
        contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
        fileDownloadName: "Ledger.xlsx"
      );
    }
  }
}
