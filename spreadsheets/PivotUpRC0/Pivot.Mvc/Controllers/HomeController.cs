using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Pivot.Mvc.Models;

namespace Pivot.Mvc.Controllers;

public class HomeController : Controller
{
  private readonly ILogger<HomeController> _logger;
  private readonly IHttpClientFactory httpClientFactory;

  public HomeController(
    ILogger<HomeController> logger,
    IHttpClientFactory httpClientFactory
  )
  {
    _logger = logger;
    this.httpClientFactory = httpClientFactory;
  }

  public IActionResult Index()
  {
    try
    {
      HttpClient httpClient = httpClientFactory.CreateClient(name: "Pivot.Api");
    }
    catch (System.Exception)
    {
      
      throw;
    }
    return View();
  }

  public IActionResult Privacy()
  {
    return View();
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }
}
