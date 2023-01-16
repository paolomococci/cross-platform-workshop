using Microsoft.AspNetCore.Mvc;

namespace Pivot.Mvc.Controllers;

public class UploadController : Controller
{
  private readonly ILogger<HomeController> _logger;

  public UploadController(ILogger<HomeController> logger)
  {
    _logger = logger;
  }

  [HttpPost]
  public IActionResult Upload()
  {
    // todo
    return View();
  }

  [HttpGet]
  public IActionResult Uploaded()
  {
    return View();
  }
}
