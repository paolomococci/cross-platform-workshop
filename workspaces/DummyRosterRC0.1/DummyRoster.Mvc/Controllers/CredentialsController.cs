using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.Mvc.Controllers;

public class CredentialsController : Controller
{
  private const string baseUri = "https://localhost:5001/api/credentials";
  private readonly ILogger<CredentialsController> _logger;
  private readonly HttpClient httpClient;

  public CredentialsController(
    ILogger<CredentialsController> logger,
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

  public async Task<IActionResult> Credentials(string? email)
  {
    string apiUri = "";
    if (string.IsNullOrEmpty(email))
    {
      ViewData["Title"] = "All Credentials";
      apiUri = $"{baseUri}";
    }
    else
    {
      ViewData["Title"] = $"Credentials with the email equal to {email}";
      apiUri = $"{baseUri}/?email={email}";
    }
    HttpRequestMessage httpRequestMessage = new(
      method: HttpMethod.Get,
      requestUri: apiUri
    );
    HttpResponseMessage httpResponseMessage = await this.httpClient.SendAsync(
      httpRequestMessage
    );
    IEnumerable<Credential>? credentials = await httpResponseMessage
      .Content.ReadFromJsonAsync<IEnumerable<Credential>>();
    return View(credentials);
  }
}
