using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Pivot.Mvc.Models;

namespace Pivot.Mvc.Controllers;

public class HomeController : Controller
{
  private readonly ILogger<HomeController> _logger;

  public HomeController(ILogger<HomeController> logger)
  {
    _logger = logger;
  }

  public IActionResult Index()
  {
    return View();
  }

  public IActionResult Privacy()
  {
    return View();
  }

  public IActionResult Pivot()
  {
    return View();
  }

  [HttpPost]
  public IActionResult Upload(List<IFormFile> items)
  {
    string uploadedPath = Path.Combine("../Uploaded", "Uploads");
    List<string> uploadedFiles = new List<string>();
    foreach (IFormFile item in items)
    {
      string fileName = Path.GetFileName(item.FileName);
      using (FileStream stream = new FileStream(Path.Combine(uploadedPath, fileName), FileMode.Create))
      {
        item.CopyTo(stream);
        uploadedFiles.Add(fileName);
        ViewBag.Message += string.Format("<em>{0}</em> uploaded.<br>", fileName);
      }
    }
    return View();
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }
}
