using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;

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
