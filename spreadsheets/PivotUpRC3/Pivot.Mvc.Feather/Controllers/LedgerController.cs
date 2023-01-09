using Microsoft.AspNetCore.Mvc;

namespace Pivot.Mvc.Feather.Controllers;

public class LedgerController : Controller {
  
  private readonly ILogger<HomeController> _logger;
  private readonly IWebHostEnvironment webHostEnvironment;

  public LedgerController(
    ILogger<HomeController> logger,
    IWebHostEnvironment webHostEnvironment
  )
  {
    _logger = logger;
    this.webHostEnvironment = webHostEnvironment;
  }

  public IActionResult Index()
  {
    return View();
  }
}
