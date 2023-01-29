using Microsoft.AspNetCore.Mvc;

namespace Liking.Mvc.Feather.Controllers;

public class SchemeController : Controller
{

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

  public IActionResult Index()
  {
    List<string> schemeProcessedList = new();
    var store = Path.Combine(
        this.webHostEnvironment.WebRootPath,
        "Store/schemes"
      );
    var uploadedFiles = Directory.GetFiles(store);
    foreach (var item in uploadedFiles)
    {
      var itemName = Path.GetFileName(item);
      schemeProcessedList.Add(itemName);
      ViewData["schemeListNames"] = schemeProcessedList;
    }
    return View();
  }

  public IActionResult Report() {
    return View();
  }
}
