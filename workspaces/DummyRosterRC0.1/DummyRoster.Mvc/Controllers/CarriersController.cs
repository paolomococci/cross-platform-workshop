using Microsoft.AspNetCore.Mvc;

namespace DummyRoster.Mvc.Controllers;

public class CarriersController : Controller
{
  private const string baseUri = "https://localhost:5001/api/carriers";
  private readonly ILogger<CarriersController> _logger;
  private readonly HttpClient httpClient;

  public CarriersController(
    ILogger<CarriersController> logger,
    IHttpClientFactory httpClientFactory
  )
  {
    this._logger = logger;
    this.httpClient = new HttpClient();
  }
}
