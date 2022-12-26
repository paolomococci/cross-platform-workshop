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

  [Route("Home/Customers")]
  public async Task<IActionResult> Customers(string? name)
  {
    string apiUri = "";
    if (string.IsNullOrEmpty(name))
    {
      ViewData["Title"] = "All Customers";
      apiUri = $"{baseUri}";
    }
    else
    {
      ViewData["Title"] = $"Customers with the name equal to {name}";
      apiUri = $"{baseUri}/?name={name}";
    }
    HttpRequestMessage httpRequestMessage = new(
      method: HttpMethod.Get,
      requestUri: apiUri
    );
    HttpResponseMessage httpResponseMessage = await this.httpClient.SendAsync(
      httpRequestMessage
    );
    IEnumerable<Customer>? customers = await httpResponseMessage
      .Content.ReadFromJsonAsync<IEnumerable<Customer>>();
    return View(customers);
  }
}
