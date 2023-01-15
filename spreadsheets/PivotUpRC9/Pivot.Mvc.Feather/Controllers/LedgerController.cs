using Microsoft.AspNetCore.Mvc;

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
}
