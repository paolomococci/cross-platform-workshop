using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Knowledge.Mvc.Feather.Models;

namespace Knowledge.Mvc.Feather.Controllers;

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
  public IActionResult Upload(DataCollectionModel dataCollectionModel)
  {
    if (dataCollectionModel.Dataset != null)
    {
      var dataset = dataCollectionModel.Dataset;
      var datasetName = Path.GetFileName(dataset.FileName);
      var unique = this.AppendDateTime(datasetName);
    }
    return RedirectToAction(
      "Index",
      "Home"
    );
  }

  public IActionResult Uploaded()
  {
    return View();
  }

  public IActionResult Restricted()
  {
    return RedirectToAction(
      "Index",
      "Home"
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

  private object AppendDateTime(string datasetName)
  {
    var name = Path.GetFileName(datasetName);
    return Path.GetFileNameWithoutExtension(name) + $"_{DateTime.Now:yyyy-MM-dd_hh-mm-ss}" + Path.GetExtension(name);
  }
}
