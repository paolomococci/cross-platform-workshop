using Microsoft.AspNetCore.Mvc;
using Pivot.Common.Models;

namespace Pivot.Api.Controllers;


[ApiController]
[Route("api")]
public class LedgerController : ControllerBase
{
  /* 
    GET: https://localhost:8083/api/pivot
   */
  [HttpGet("pivot")]
  [ProducesResponseType(200)]
  public IActionResult Generate()
  {
    using (MemoryStream memoryStream = new MemoryStream())
    {
      return this.File(
        fileContents: LedgerModel.Perform(memoryStream),
        contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
        fileDownloadName: "Pivot.xlsx"
      );
    }
  }
}
