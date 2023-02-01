using Microsoft.AspNetCore.Mvc;

namespace ShallowML.Mvc.Feather.Controllers;

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
