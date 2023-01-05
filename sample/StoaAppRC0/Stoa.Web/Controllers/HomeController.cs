using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Stoa.Web.Models;

namespace Stoa.Web.Controllers;

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

  public IActionResult Create()
  {
    return View();
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
}
