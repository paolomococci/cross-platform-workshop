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
    List<string> schemes = new();
    var store = Path.Combine(
        this.webHostEnvironment.WebRootPath,
        "Store/schemes"
      );
    var uploadedSchemes = Directory.GetFiles(store);
    foreach (var item in uploadedSchemes)
    {
      var itemName = Path.GetFileName(item);
      schemes.Add(itemName);
      ViewData["schemes"] = schemes;
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
      this.report = new ReportModel() {
        Comment = comment,
        Disposition = Convert.ToBoolean(predictionModel.PredictedLabel)
      };
    }
    if (this.report != null)
    {
      return RedirectToAction(
      "Report",
      "Home",
      new ReportModel()
      {
        Comment = this.report.Comment,
        Disposition = this.report.Disposition
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
    string Comment,
    bool Disposition
  )
  {
    var report = new ReportModel()
      {
        Comment = Comment,
        Disposition = Disposition
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
