using Microsoft.AspNetCore.Mvc;

namespace DummyRoster.Mvc.Controllers;

public class InvoicesController : Controller
{
  private const string baseUri = "https://localhost:5001/api/invoices";
  private readonly ILogger<InvoicesController> _logger;
  private readonly HttpClient httpClient;

  public InvoicesController(
    ILogger<InvoicesController> logger,
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
