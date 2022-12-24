using Microsoft.AspNetCore.Mvc;

namespace DummyRoster.Mvc.Controllers;

public class AddressesController : Controller
{
  private const string baseUri = "https://localhost:5001/api/addresses";
  private readonly ILogger<AddressesController> _logger;
  private readonly HttpClient httpClient;

  public AddressesController(
    ILogger<AddressesController> logger,
    IHttpClientFactory httpClientFactory
  )
  {
    this._logger = logger;
    this.httpClient = new HttpClient();
  }
}
