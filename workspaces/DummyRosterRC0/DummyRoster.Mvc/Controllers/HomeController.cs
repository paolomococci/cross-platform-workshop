using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DummyRoster.Mvc.Models;

namespace DummyRoster.Mvc.Controllers;

public class HomeController : Controller
{
  private readonly ILogger<HomeController> _logger;
  private readonly IHttpClientFactory httpClientFactory;

  public HomeController(
    ILogger<HomeController> logger,
    IHttpClientFactory httpClientFactory
  )
  {
    this._logger = logger;
    this.httpClientFactory = httpClientFactory;
  }

  [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any)]
  public IActionResult Index()
  {
    return View();
  }

  [Route("Restricted")]
  [Authorize(Roles = "Admins")]
  public IActionResult Privacy()
  {
    return View();
  }

  public Task<IActionResult>? Employees()
  {
    return null;
  }

  public Task<IActionResult>? Customers()
  {
    return null;
  }

  public Task<IActionResult>? Suppliers()
  {
    return null;
  }

  public Task<IActionResult>? Carriers()
  {
    return null;
  }

  public Task<IActionResult>? Addresses()
  {
    return null;
  }

  public Task<IActionResult>? Credentials()
  {
    return null;
  }

  public Task<IActionResult>? Categories()
  {
    return null;
  }

  public Task<IActionResult>? Products()
  {
    return null;
  }

  public Task<IActionResult>? Forms()
  {
    return null;
  }

  public Task<IActionResult>? Invoices()
  {
    return null;
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel
    {
      RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
    });
  }
}
