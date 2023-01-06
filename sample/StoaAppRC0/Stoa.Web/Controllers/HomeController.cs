using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Stoa.Web.Models;

namespace Stoa.Web.Controllers;

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

  public IActionResult Create()
  {
    return View(new PostModel());
  }

  [HttpPost]
  public IActionResult Create(PostModel postModel)
  {
    if (postModel.Caption != null && postModel.Description != null && postModel.Concept != null)
    {
      var caption = postModel.Caption;
      var description = postModel.Description;
      var concept = postModel.Concept;
      var conceptName = Path.GetFileName(concept.FileName);
      var conceptContentType = concept.ContentType;
      var unique = this.MakeUnique(conceptName);
      var upload = Path.Combine(
        this.webHostEnvironment.WebRootPath, 
        "Store"
      );
      var path = Path.Combine(upload, unique);
      postModel.Concept.CopyTo(
        new FileStream(path, FileMode.Create)
      );
    }
    // todo
    return RedirectToAction(
      "Index",
      "Home"
    );
  }

  public IActionResult Upload()
  {
    return View();
  }

  public IActionResult Uploaded()
  {
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

  private string MakeUnique(string file) {
    var name = Path.GetFileName(file);
    return Path.GetFileNameWithoutExtension(name) + "_" + Guid.NewGuid().ToString() + Path.GetExtension(name);
  }
}
