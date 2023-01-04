using Microsoft.AspNetCore.Mvc;

namespace Pivot.Mvc.Controllers;

public class UploadController : Controller
{
  private readonly ILogger<HomeController> _logger;

  public UploadController(ILogger<HomeController> logger)
  {
    _logger = logger;
  }

  public IActionResult Index()
  {
    return View();
  }
}
