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
  [ProducesResponseType(404)]
  public IActionResult Generate() {
    return NotFound();
  }
}
