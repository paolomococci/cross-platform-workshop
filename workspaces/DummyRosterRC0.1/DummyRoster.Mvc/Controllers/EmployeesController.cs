using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.Mvc.Controllers;

public class EmployeesController : Controller
{
  private const string baseUri = "https://localhost:5001/api/employees";
  private readonly ILogger<EmployeesController> _logger;
  private readonly HttpClient httpClient;

  public EmployeesController(
    ILogger<EmployeesController> logger,
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

  public async Task<IActionResult> Employees(string? name)
  {
    string apiUri = "";
    if (string.IsNullOrEmpty(name))
    {
      ViewData["Title"] = "All Employees";
      apiUri = $"{baseUri}";
    }
    else
    {
      ViewData["Title"] = $"Employees with the name equal to {name}";
      apiUri = $"{baseUri}/?name={name}";
    }
    HttpRequestMessage httpRequestMessage = new(
      method: HttpMethod.Get,
      requestUri: apiUri
    );
    HttpResponseMessage httpResponseMessage = await this.httpClient.SendAsync(
      httpRequestMessage
    );
    IEnumerable<Employee>? employees = await httpResponseMessage
      .Content.ReadFromJsonAsync<IEnumerable<Employee>>();
    return View(employees);
  }
}
