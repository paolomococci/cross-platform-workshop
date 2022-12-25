using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.Mvc.Controllers;

// https://localhost:8081/Home/Addresses?name=
//[Route("")]
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

  [Route("Home/Addresses")]
  public async Task<IActionResult> Addresses(string? country)
  {
    string apiUri = "";
    if (string.IsNullOrEmpty(country))
    {
      ViewData["Title"] = "All Addresses";
      apiUri = $"{baseUri}";
    }
    else
    {
      ViewData["Title"] = $"Addresses with the country name equal to {country}";
      apiUri = $"{baseUri}/?country={country}";
    }
    HttpRequestMessage httpRequestMessage = new(
      method: HttpMethod.Get,
      requestUri: apiUri
    );
    HttpResponseMessage httpResponseMessage = await this.httpClient.SendAsync(
      httpRequestMessage
    );
    IEnumerable<Address>? addresses = await httpResponseMessage
      .Content.ReadFromJsonAsync<IEnumerable<Address>>();
    return View(addresses);
  }
}
