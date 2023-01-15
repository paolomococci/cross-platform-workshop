using Microsoft.AspNetCore.Mvc;
using Pivot.Common.Models;

namespace Pivot.Mvc.Feather.Controllers;

public class LedgerController : Controller
{

  private readonly ILogger<HomeController> _logger;

  public LedgerController(
    ILogger<HomeController> logger
  )
  {
    _logger = logger;
  }

  public IActionResult Index()
  {
    return View();
  }

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
