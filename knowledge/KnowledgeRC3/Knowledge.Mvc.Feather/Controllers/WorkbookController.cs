using Microsoft.AspNetCore.Mvc;

namespace Knowledge.Mvc.Feather.Controllers;

public class WorkbookController : Controller 
{
  private readonly ILogger<HomeController> _logger;
  private readonly IWebHostEnvironment webHostEnvironment;

  public WorkbookController(
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

  public IActionResult Workbooks()
  {
    return View();
  }
}
