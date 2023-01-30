using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.ML.Data;
using Liking.Mvc.Feather.Models;
using Liking.Common.Models;

namespace Liking.Mvc.Feather.Controllers;

public class HomeController : Controller
{
  private readonly ILogger<HomeController> _logger;
  private readonly IWebHostEnvironment webHostEnvironment;
  private CalibratedBinaryClassificationMetrics? schemeReport;

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
      this.schemeReport = scheme.CreateMLContext(
        datasetPath: datasetPath,
        schemePath: schemePath
      );
    }
    if (this.schemeReport != null)
    {
      return RedirectToAction(
      "Home",
      "Report",
      new ReportModel()
      {
        Accuracy = string.Format("{0:F3}", this.schemeReport.Accuracy),
        AreaUnderRocCurve = string.Format("{0:F3}", this.schemeReport.AreaUnderRocCurve),
        AreaUnderPrecisionRecallCurve = string.Format("{0:F3}", this.schemeReport.AreaUnderPrecisionRecallCurve),
        F1Score = string.Format("{0:F3}", this.schemeReport.F1Score),
        LogLoss = string.Format("{0:F3}", this.schemeReport.LogLoss),
        LogLossReduction = string.Format("{0:F3}", this.schemeReport.LogLossReduction),
        PositivePrecision = string.Format("{0:F3}", this.schemeReport.PositivePrecision),
        PositiveRecall = string.Format("{0:F3}", this.schemeReport.PositiveRecall),
        NegativePrecision = string.Format("{0:F3}", this.schemeReport.NegativePrecision),
        NegativeRecall = string.Format("{0:F3}", this.schemeReport.NegativeRecall)
      }
    );
    }
    else
    {
      return RedirectToAction(
      "Home",
      "Index"
      );
    }
  }

[HttpGet]
  public IActionResult Report(ReportModel reportModel)
  {
    return View(reportModel);
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
