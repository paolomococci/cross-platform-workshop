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
  public IActionResult Upload(DataCollectionModel collection)
  {
    if (collection.Dataset != null)
    {
      var unique = collection.SetTheDateInTheFilename();
      var upload = Path.Combine(
        this.webHostEnvironment.WebRootPath,
        "Store/datasets"
      );
      var path = Path.Combine(upload, unique);
      collection.Dataset.CopyTo(
        new FileStream(path, FileMode.Create)
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
      // todo
    }
    return RedirectToAction(
      "Index",
      "Home"
    );
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

  private string AppendDateTime(string datasetName)
  {
    var name = Path.GetFileName(datasetName);
    return Path.GetFileNameWithoutExtension(name) + $"_{DateTime.Now:yyyy-MM-dd_hh-mm-ss}" + Path.GetExtension(name);
  }
}
