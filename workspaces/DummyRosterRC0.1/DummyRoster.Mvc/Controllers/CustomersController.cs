using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;

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
