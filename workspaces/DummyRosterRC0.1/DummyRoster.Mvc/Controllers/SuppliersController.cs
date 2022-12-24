using Microsoft.AspNetCore.Mvc;

namespace DummyRoster.Mvc.Controllers;

public class SuppliersController : Controller {
  private const string baseUri = "https://localhost:5001/api/addresses";
  private readonly ILogger<SuppliersController> _logger;
  private readonly HttpClient httpClient;

  public SuppliersController(
    ILogger<SuppliersController> logger,
    IHttpClientFactory httpClientFactory
  )
  {
    this._logger = logger;
    this.httpClient = new HttpClient();
  }
}
