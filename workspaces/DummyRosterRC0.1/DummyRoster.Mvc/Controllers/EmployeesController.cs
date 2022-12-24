using Microsoft.AspNetCore.Mvc;

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
    this.httpClient = new HttpClient();
  }
}
