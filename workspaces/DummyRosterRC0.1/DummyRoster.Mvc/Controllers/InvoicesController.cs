using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;

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

  [Route("Home/Invoices")]
  public async Task<IActionResult> Invoices(int? formId)
  {
    string apiUri = "";
    if (string.IsNullOrEmpty(formId.ToString()))
    {
      ViewData["Title"] = "All Invoices";
      apiUri = $"{baseUri}";
    }
    else
    {
      ViewData["Title"] = $"Invoices with the form id {formId}";
      apiUri = $"{baseUri}/?formId={formId.ToString()}";
    }
    HttpRequestMessage httpRequestMessage = new(
      method: HttpMethod.Get,
      requestUri: apiUri
    );
    HttpResponseMessage httpResponseMessage = await this.httpClient.SendAsync(
      httpRequestMessage
    );
    IEnumerable<Invoice>? invoices = await httpResponseMessage
      .Content.ReadFromJsonAsync<IEnumerable<Invoice>>();
    return View(invoices);
  }
}
