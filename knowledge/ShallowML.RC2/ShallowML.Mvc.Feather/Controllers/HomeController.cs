using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ShallowML.Mvc.Feather.Models;
using ShallowML.Common.Models;

namespace ShallowML.Mvc.Feather.Controllers;

public class HomeController : Controller
{
  private readonly ILogger<HomeController> _logger;
  private readonly IWebHostEnvironment webHostEnvironment;
  private ReportModel? report;

  public HomeController(
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

  public IActionResult Upload()
  {
    return View(new DataCollectionModel());
  }

  [HttpPost]
  public IActionResult Upload(DataCollectionModel dataCollection)
  {
    if (dataCollection.Dataset != null)
    {
      var unique = dataCollection.SetTheDateInTheFilename();
      var upload = Path.Combine(
        this.webHostEnvironment.WebRootPath,
        "Store/workbooks"
      );
      var datasetPath = Path.Combine(upload, unique);
      dataCollection.Dataset.CopyTo(
        new FileStream(datasetPath, FileMode.Create)
      );
    }
    return RedirectToAction(
      "Index",
      "Home"
    );
  }

  public IActionResult Uploaded()
  {
    List<string> listOfUploadedDataset = new();
    var store = Path.Combine(
        this.webHostEnvironment.WebRootPath,
        "Store/workbooks"
      );
    var uploadedFiles = Directory.GetFiles(store);
    foreach (var item in uploadedFiles)
    {
      var itemName = Path.GetFileName(item);
      listOfUploadedDataset.Add(itemName);
      ViewData["datasetList"] = listOfUploadedDataset;
    }
    return View();
  }

  [HttpPost]
  public IActionResult Process(string unique)
  {
    if (unique != null && unique != string.Empty)
    {
      string storeDatasetPath = Path.Combine(
        this.webHostEnvironment.WebRootPath,
        "Store/workbooks"
      );
      string storeSchemePath = Path.Combine(
        this.webHostEnvironment.WebRootPath,
        "Store/schemes"
      );
      SchemeModel scheme = new();
      string datasetPath = Path.Combine(storeDatasetPath, unique);
      this.report = scheme.CreateMLContext(
        datasetPath: datasetPath
      );
    }
    if (this.report != null)
    {
      return RedirectToAction(
      "Report",
      "Home",
      new ReportModel()
      {
        Name = this.report.Name,
        Area = this.report.Area,
        Price = this.report.Price
      }
    );
    }
    else
    {
      return RedirectToAction(
      "Index",
      "Home"
      );
    }
  }

[HttpGet]
  public IActionResult Report([FromQuery]
    string Name,
    string Area,
    string Price
  )
  {
    var report = new ReportModel()
      {
        Name = Name,
        Area = Area,
        Price = Price
      };
    return View(report);
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(
      new ErrorViewModel
      {
        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
      }
    );
  }
}
