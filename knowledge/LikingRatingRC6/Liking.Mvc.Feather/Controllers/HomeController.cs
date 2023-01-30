using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Liking.Mvc.Feather.Models;
using Liking.Common.Models;

namespace Liking.Mvc.Feather.Controllers;

public class HomeController : Controller
{
  private readonly ILogger<HomeController> _logger;
  private readonly IWebHostEnvironment webHostEnvironment;

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
        "Store/datasets"
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
        "Store/datasets"
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
        "Store/datasets"
      );
      string storeSchemePath = Path.Combine(
        this.webHostEnvironment.WebRootPath,
        "Store/schemes"
      );
      SchemeModel scheme = new();
      string datasetPath = Path.Combine(storeDatasetPath, unique);
      string schemePath = Path.Combine(storeSchemePath, $"scheme_{scheme.Id}.zip");
      var schemeReport = scheme.CreateMLContext(
        datasetPath: datasetPath,
        schemePath: schemePath
      );
      ReportModel report = new ReportModel
      {
        Accuracy = string.Format("{0:F3}", schemeReport.Accuracy),
        AreaUnderRocCurve = string.Format("{0:F3}", schemeReport.AreaUnderRocCurve),
        AreaUnderPrecisionRecallCurve = string.Format("{0:F3}", schemeReport.AreaUnderPrecisionRecallCurve),
        F1Score = string.Format("{0:F3}", schemeReport.F1Score),
        LogLoss = string.Format("{0:F3}", schemeReport.LogLoss),
        LogLossReduction = string.Format("{0:F3}", schemeReport.LogLossReduction),
        PositivePrecision = string.Format("{0:F3}", schemeReport.PositivePrecision),
        PositiveRecall = string.Format("{0:F3}", schemeReport.PositiveRecall),
        NegativePrecision = string.Format("{0:F3}", schemeReport.NegativePrecision),
        NegativeRecall = string.Format("{0:F3}", schemeReport.NegativeRecall),
      };
      ViewBag.Models = report;
    }
    return RedirectToAction(
      "Scheme",
      "Report"
    );
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
