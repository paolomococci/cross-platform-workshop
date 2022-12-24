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
    HttpClientHandler httpClientHandler = new HttpClientHandler();
    httpClientHandler.ServerCertificateCustomValidationCallback += (
      sender,
      certificate,
      chain,
      error
    ) =>
    {
      return true;
    };
    this.httpClient = new HttpClient(httpClientHandler);
  }
}
