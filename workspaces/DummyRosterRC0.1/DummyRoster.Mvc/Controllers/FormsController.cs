using Microsoft.AspNetCore.Mvc;

namespace DummyRoster.Mvc.Controllers;

public class FormsController : Controller
{
  private const string baseUri = "https://localhost:5001/api/forms";
  private readonly ILogger<FormsController> _logger;
  private readonly HttpClient httpClient;

  public FormsController(
    ILogger<FormsController> logger,
    IHttpClientFactory httpClientFactory
  )
  {
    this._logger = logger;
    this.httpClient = new HttpClient();
  }
}
