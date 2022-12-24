using Microsoft.AspNetCore.Mvc;

namespace DummyRoster.Mvc.Controllers;

public class ProductsController : Controller
{
  private const string baseUri = "https://localhost:5001/api/products";
  private readonly ILogger<ProductsController> _logger;
  private readonly HttpClient httpClient;

  public ProductsController(
    ILogger<ProductsController> logger,
    IHttpClientFactory httpClientFactory
  )
  {
    this._logger = logger;
    this.httpClient = new HttpClient();
  }
}
