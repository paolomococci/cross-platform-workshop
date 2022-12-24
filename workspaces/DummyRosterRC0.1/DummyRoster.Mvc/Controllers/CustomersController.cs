using Microsoft.AspNetCore.Mvc;

namespace DummyRoster.Mvc.Controllers;

public class CustomersController : Controller
{
  private const string baseUri = "https://localhost:5001/api/customers";
  private readonly ILogger<CustomersController> _logger;
  private readonly HttpClient httpClient;

  public CustomersController(
    ILogger<CustomersController> logger,
    IHttpClientFactory httpClientFactory
  )
  {
    this._logger = logger;
    this.httpClient = new HttpClient();
  }
}
