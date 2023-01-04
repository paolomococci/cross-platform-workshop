using Microsoft.AspNetCore.Mvc;

namespace Pivot.Mvc.Controllers;

public class UploadController : Controller
{
  private readonly ILogger<HomeController> _logger;

  public UploadController(ILogger<HomeController> logger)
  {
    _logger = logger;
  }

  public IActionResult Index()
  {
    return View();
  }

  [HttpGet]
  public IActionResult Uploaded()
  {
    return View();
  }

  [HttpPost]
  public IActionResult Upload(List<IFormFile> items)
  {
    string uploadedPath = Path.Combine("../Uploaded", "Uploads");
    List<string> uploadedFiles = new List<string>();
    foreach (IFormFile item in items) {
      string fileName = Path.GetFileName(item.FileName);
      using (FileStream stream = new FileStream(Path.Combine(uploadedPath, fileName), FileMode.Create)) {
        item.CopyTo(stream);
        uploadedFiles.Add(fileName);
        ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
      }
    }
    return View();
  }
}
