using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Pivot.Mvc.Feather.Models;

namespace Pivot.Mvc.Feather.Controllers;

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
    return View(new PostModel());
  }

  [HttpPost]
  public IActionResult Upload(PostModel postModel)
  {
    if (postModel.Caption != null && postModel.Description != null && postModel.Concept != null)
    {
      var caption = postModel.Caption;
      var description = postModel.Description;
      var concept = postModel.Concept;
      var conceptName = Path.GetFileName(concept.FileName);
      var conceptContentType = concept.ContentType;
      var unique = this.AppendDateTime(conceptName);
      var upload = Path.Combine(
        this.webHostEnvironment.WebRootPath,
        "Store"
      );
      var path = Path.Combine(upload, unique);
      postModel.Concept.CopyTo(
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
    List<string> listOfUploadedFilenames = new();
    var store = Path.Combine(
        this.webHostEnvironment.WebRootPath,
        "Store"
      );
    var uploadedFiles = Directory.GetFiles(store);
    foreach (var item in uploadedFiles)
    {
      var itemName = Path.GetFileName(item);
      listOfUploadedFilenames.Add(itemName);
      ViewData["fileNameList"] = listOfUploadedFilenames;
    }
    return View();
  }

  public IActionResult Process() {
    // TODO
    return View();
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

  private string AppendDateTime(string file)
  {
    var name = Path.GetFileName(file);
    return Path.GetFileNameWithoutExtension(name) + $"_{DateTime.Now:yyyy-MM-dd_hh-mm-ss}" + Path.GetExtension(name);
  }
}
