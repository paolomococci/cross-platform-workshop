using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AttitudeML.Mvc.Feather.Models;
using AttitudeML.Common.Models;

namespace AttitudeML.Mvc.Feather.Controllers;

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
      var workbook = dataCollection.SetTheDateInTheFilename();
      var upload = Path.Combine(
        this.webHostEnvironment.WebRootPath,
        "Store/workbooks"
      );
      var datasetPath = Path.Combine(upload, workbook);
      dataCollection.Dataset.CopyTo(
        new FileStream(datasetPath, FileMode.Create)
      );
    }
    return RedirectToAction(
      "Index",
      "Home"
    );
  }

  public IActionResult Interact()
  {
    List<string> workbooks = new();
    var store = Path.Combine(
        this.webHostEnvironment.WebRootPath,
        "Store/workbooks"
      );
    var uploadedWorkbooks = Directory.GetFiles(store);
    foreach (var item in uploadedWorkbooks)
    {
      var itemName = Path.GetFileName(item);
      workbooks.Add(itemName);
      ViewData["workbooks"] = workbooks;
    }
    return View();
  }

  [HttpPost]
  public IActionResult Process(
    string frozenScheme,
    string comment
  )
  {
    if (frozenScheme != null && frozenScheme != string.Empty && comment != string.Empty)
    {
      string storeSchemePath = Path.Combine(
        this.webHostEnvironment.WebRootPath,
        "Store/schemes"
      );
      SchemeModel scheme = new();
      string schemePath = Path.Combine(storeSchemePath, frozenScheme);
      PredictionModel predictionModel = scheme.Prediction(
        domainModel: new DomainModel() { Comment = comment },
        schemePath: schemePath
      );
      // todo
      //this.report
    }
    if (this.report != null)
    {
      return RedirectToAction(
      "Report",
      "Home",
      new ReportModel()
      {
        Name = this.report.Name
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
    string Name
  )
  {
    var report = new ReportModel()
      {
        Name = Name
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
