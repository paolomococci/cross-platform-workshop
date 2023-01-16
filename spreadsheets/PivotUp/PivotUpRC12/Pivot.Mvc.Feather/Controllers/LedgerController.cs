using Microsoft.AspNetCore.Mvc;

namespace Pivot.Mvc.Feather.Controllers;

public class LedgerController : Controller
{

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

  public IActionResult Workbooks()
  {
    List<string> workbookProcessedList = new();
    var store = Path.Combine(
        this.webHostEnvironment.WebRootPath,
        "Store/workbooks"
      );
    var uploadedFiles = Directory.GetFiles(store);
    foreach (var item in uploadedFiles)
    {
      var itemName = Path.GetFileName(item);
      workbookProcessedList.Add(itemName);
      ViewData["workbookListNames"] = workbookProcessedList;
    }
    return View();
  }
}
