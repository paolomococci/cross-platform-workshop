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
    this.httpClient = new HttpClient();
  }
}
