using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.Mvc.Controllers;

public class ProductsController : Controller
{
  private const string baseUri = "https://localhost:5001/api/products";
  private readonly ILogger<ProductsController> _logger;
  private readonly HttpClient httpClient;

  public ProductsController(
    ILogger<ProductsController> logger,
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

  public async Task<IActionResult> Products(string? name)
  {
    string apiUri = "";
    if (string.IsNullOrEmpty(name))
    {
      ViewData["Title"] = "All Products";
      apiUri = $"{baseUri}";
    }
    else
    {
      ViewData["Title"] = $"Products with the name equal to {name}";
      apiUri = $"{baseUri}/?name={name}";
    }
    HttpRequestMessage httpRequestMessage = new(
      method: HttpMethod.Get,
      requestUri: apiUri
    );
    HttpResponseMessage httpResponseMessage = await this.httpClient.SendAsync(
      httpRequestMessage
    );
    IEnumerable<Product>? products = await httpResponseMessage
      .Content.ReadFromJsonAsync<IEnumerable<Product>>();
    return View(products);
  }
}
