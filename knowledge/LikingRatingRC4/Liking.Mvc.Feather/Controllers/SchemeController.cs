using Microsoft.AspNetCore.Mvc;

namespace Liking.Mvc.Feather.Controllers;

public class SchemeController : Controller {

  private readonly ILogger<HomeController> _logger;
  private readonly IWebHostEnvironment webHostEnvironment;

  public SchemeController(
    ILogger<HomeController> logger,
    IWebHostEnvironment webHostEnvironment
  )
  {
    _logger = logger;
    this.webHostEnvironment = webHostEnvironment;
  }
}
