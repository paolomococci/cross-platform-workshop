using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.Mvc.Controllers;

public class CategoriesController : Controller
{
  private const string baseUri = "https://localhost:5001/api/categories";
  private readonly ILogger<CategoriesController> _logger;
  private readonly HttpClient httpClient;

  public CategoriesController(
    ILogger<CategoriesController> logger,
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

  public async Task<IActionResult> Categories(string? name)
  {
    string apiUri = "";
    if (string.IsNullOrEmpty(name))
    {
      ViewData["Title"] = "All Categories";
      apiUri = $"{baseUri}";
    }
    else
    {
      ViewData["Title"] = $"Categories with the name equal to {name}";
      apiUri = $"{baseUri}/?name={name}";
    }
    HttpRequestMessage httpRequestMessage = new(
      method: HttpMethod.Get,
      requestUri: apiUri
    );
    HttpResponseMessage httpResponseMessage = await this.httpClient.SendAsync(
      httpRequestMessage
    );
    IEnumerable<Category>? categories = await httpResponseMessage
      .Content.ReadFromJsonAsync<IEnumerable<Category>>();
    return View(categories);
  }
}
