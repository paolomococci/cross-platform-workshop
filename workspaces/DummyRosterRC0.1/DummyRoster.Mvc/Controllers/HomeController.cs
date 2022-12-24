using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DummyRoster.Mvc.Models;

namespace DummyRoster.Mvc.Controllers;

public class HomeController : Controller
{
  private readonly ILogger<HomeController> _logger;

  public HomeController(ILogger<HomeController> logger)
  {
    _logger = logger;
  }

  [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any)]
  public IActionResult Index()
  {
    return View();
  }

  [Route("Restricted")]
  [Authorize(Roles = "Admins")]
  public IActionResult Restricted()
  {
    return View();
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }
}
