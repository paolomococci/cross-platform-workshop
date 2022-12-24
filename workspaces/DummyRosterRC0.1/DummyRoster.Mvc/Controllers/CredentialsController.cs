using Microsoft.AspNetCore.Mvc;

namespace DummyRoster.Mvc.Controllers;

public class CredentialsController : Controller
{
  private const string baseUri = "https://localhost:5001/api/credentials";
  private readonly ILogger<CredentialsController> _logger;
  private readonly HttpClient httpClient;

  public CredentialsController(
    ILogger<CredentialsController> logger,
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
