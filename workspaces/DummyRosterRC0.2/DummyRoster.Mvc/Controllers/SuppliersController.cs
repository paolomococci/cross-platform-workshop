using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.Mvc.Controllers;

public class SuppliersController : Controller
{
  private const string baseUri = "https://localhost:5001/api/suppliers";
  private readonly ILogger<SuppliersController> _logger;
  private readonly HttpClient httpClient;

  public SuppliersController(
    ILogger<SuppliersController> logger,
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

  [Route("Home/Suppliers")]
  public async Task<IActionResult> Suppliers(string? name)
  {
    string apiUri = "";
    if (string.IsNullOrEmpty(name))
    {
      ViewData["Title"] = "All Suppliers";
      apiUri = $"{baseUri}";
    }
    else
    {
      ViewData["Title"] = $"Suppliers with the name equal to {name}";
      apiUri = $"{baseUri}/?name={name}";
    }
    HttpRequestMessage httpRequestMessage = new(
      method: HttpMethod.Get,
      requestUri: apiUri
    );
    HttpResponseMessage httpResponseMessage = await this.httpClient.SendAsync(
      httpRequestMessage
    );
    IEnumerable<Supplier>? suppliers = await httpResponseMessage
      .Content.ReadFromJsonAsync<IEnumerable<Supplier>>();
    return View(suppliers);
  }
}
