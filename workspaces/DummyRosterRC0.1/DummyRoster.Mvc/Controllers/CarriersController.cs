using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;

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

  [Route("Home/Carriers")]
  public async Task<IActionResult> Carriers(string? name)
  {
    string apiUri = "";
    if (string.IsNullOrEmpty(name))
    {
      ViewData["Title"] = "All Carriers";
      apiUri = $"{baseUri}";
    }
    else
    {
      ViewData["Title"] = $"Carriers with the name equal to {name}";
      apiUri = $"{baseUri}/?name={name}";
    }
    HttpRequestMessage httpRequestMessage = new(
      method: HttpMethod.Get,
      requestUri: apiUri
    );
    HttpResponseMessage httpResponseMessage = await this.httpClient.SendAsync(
      httpRequestMessage
    );
    IEnumerable<Carrier>? carriers = await httpResponseMessage
      .Content.ReadFromJsonAsync<IEnumerable<Carrier>>();
    return View(carriers);
  }
}
