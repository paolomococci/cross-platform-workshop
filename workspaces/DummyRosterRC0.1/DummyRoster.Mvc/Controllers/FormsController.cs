using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.Mvc.Controllers;

public class FormsController : Controller
{
  private const string baseUri = "https://localhost:5001/api/forms";
  private readonly ILogger<FormsController> _logger;
  private readonly HttpClient httpClient;

  public FormsController(
    ILogger<FormsController> logger,
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

  public async Task<IActionResult> Forms(int? customerId)
  {
    string apiUri = "";
    if (string.IsNullOrEmpty(customerId.ToString()))
    {
      ViewData["Title"] = "All Forms";
      apiUri = $"{baseUri}";
    }
    else
    {
      ViewData["Title"] = $"Forms with the customer id {customerId}";
      apiUri = $"{baseUri}/?customerId={customerId.ToString()}";
    }
    HttpRequestMessage httpRequestMessage = new(
      method: HttpMethod.Get,
      requestUri: apiUri
    );
    HttpResponseMessage httpResponseMessage = await this.httpClient.SendAsync(
      httpRequestMessage
    );
    IEnumerable<Form>? forms = await httpResponseMessage
      .Content.ReadFromJsonAsync<IEnumerable<Form>>();
    return View(forms);
  }
}
