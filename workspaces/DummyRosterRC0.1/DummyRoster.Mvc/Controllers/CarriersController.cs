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
