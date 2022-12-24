using Microsoft.AspNetCore.Mvc;

namespace DummyRoster.Mvc.Controllers;

public class CategoriesController : Controller
{
  private const string baseUri = "https://localhost:5001/api/categories";
  private readonly ILogger<CategoriesController> _logger;
  private readonly HttpClient httpClient;

  public CategoriesController(
    ILogger<CategoriesController> logger,
    IHttpClientFactory httpClientFactory
  )
  {
    this._logger = logger;
    this.httpClient = new HttpClient();
  }
}
