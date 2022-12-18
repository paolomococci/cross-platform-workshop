using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DummyRoster.Mvc.Models;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.Mvc.Controllers;

public class HomeController : Controller
{
  private readonly ILogger<HomeController> _logger;
  private readonly IHttpClientFactory httpClientFactory;

  public HomeController(
    ILogger<HomeController> logger,
    IHttpClientFactory httpClientFactory
  )
  {
    this._logger = logger;
    this.httpClientFactory = httpClientFactory;
  }

  [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any)]
  public IActionResult Index()
  {
    return View();
  }

  [Route("Restricted")]
  [Authorize(Roles = "Admins")]
  public IActionResult Privacy()
  {
    return View();
  }

  public async Task<IActionResult> Employees(string? name)
  {
    string apiUri = "";
    if (string.IsNullOrEmpty(name))
    {
      ViewData["Title"] = "All Employees";
      apiUri = "api/employees";
    }
    else
    {
      ViewData["Title"] = "Employees with a similar name";
      apiUri = $"api/employees*?name={name}";
    }
    HttpClient httpClient = this.httpClientFactory.CreateClient(
      name: "DummyRoster.WebApi"
    );
    HttpRequestMessage httpRequestMessage = new(
      method: HttpMethod.Get,
      requestUri: apiUri
    );
    HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(
      httpRequestMessage
    );
    IEnumerable<Employee>? employees = await httpResponseMessage
      .Content.ReadFromJsonAsync<IEnumerable<Employee>>();
    return View(employees);
  }

  public async Task<IActionResult> Customers(string? name)
  {
    string apiUri = "";
    if (string.IsNullOrEmpty(name))
    {
      ViewData["Title"] = "All Customers";
      apiUri = "api/customers";
    }
    else
    {
      ViewData["Title"] = "Customers with a similar name";
      apiUri = $"api/customers*?name={name}";
    }
    HttpClient httpClient = this.httpClientFactory.CreateClient(
      name: "DummyRoster.WebApi"
    );
    HttpRequestMessage httpRequestMessage = new(
      method: HttpMethod.Get,
      requestUri: apiUri
    );
    HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(
      httpRequestMessage
    );
    IEnumerable<Customer>? customers = await httpResponseMessage
      .Content.ReadFromJsonAsync<IEnumerable<Customer>>();
    return View(customers);
  }

  public async Task<IActionResult> Suppliers(string? name)
  {
    string apiUri = "";
    if (string.IsNullOrEmpty(name))
    {
      ViewData["Title"] = "All Suppliers";
      apiUri = "api/suppliers";
    }
    else
    {
      ViewData["Title"] = "Suppliers with a similar name";
      apiUri = $"api/suppliers*?name={name}";
    }
    HttpClient httpClient = this.httpClientFactory.CreateClient(
      name: "DummyRoster.WebApi"
    );
    HttpRequestMessage httpRequestMessage = new(
      method: HttpMethod.Get,
      requestUri: apiUri
    );
    HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(
      httpRequestMessage
    );
    IEnumerable<Supplier>? suppliers = await httpResponseMessage
      .Content.ReadFromJsonAsync<IEnumerable<Supplier>>();
    return View(suppliers);
  }

  public async Task<IActionResult> Carriers(string? name)
  {
    string apiUri = "";
    if (string.IsNullOrEmpty(name))
    {
      ViewData["Title"] = "All Carriers";
      apiUri = "api/carriers";
    }
    else
    {
      ViewData["Title"] = "Carriers with a similar name";
      apiUri = $"api/carriers*?name={name}";
    }
    HttpClient httpClient = this.httpClientFactory.CreateClient(
      name: "DummyRoster.WebApi"
    );
    HttpRequestMessage httpRequestMessage = new(
      method: HttpMethod.Get,
      requestUri: apiUri
    );
    HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(
      httpRequestMessage
    );
    IEnumerable<Carrier>? carriers = await httpResponseMessage
      .Content.ReadFromJsonAsync<IEnumerable<Carrier>>();
    return View(carriers);
  }

  public async Task<IActionResult> Addresses(string? name)
  {
    string apiUri = "";
    if (string.IsNullOrEmpty(name))
    {
      ViewData["Title"] = "All Addresses";
      apiUri = "api/addresses";
    }
    else
    {
      ViewData["Title"] = "Addresses with a similar name";
      apiUri = $"api/addresses*?name={name}";
    }
    HttpClient httpClient = this.httpClientFactory.CreateClient(
      name: "DummyRoster.WebApi"
    );
    HttpRequestMessage httpRequestMessage = new(
      method: HttpMethod.Get,
      requestUri: apiUri
    );
    HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(
      httpRequestMessage
    );
    IEnumerable<Address>? addresses = await httpResponseMessage
      .Content.ReadFromJsonAsync<IEnumerable<Address>>();
    return View(addresses);
  }

  public Task<IActionResult>? Credentials(string? email)
  {
    return null;
  }

  public async Task<IActionResult>? Categories(string? name)
  {
    string apiUri = "";
    if (string.IsNullOrEmpty(name))
    {
      ViewData["Title"] = "All Categories";
      apiUri = "api/categories";
    }
    else
    {
      ViewData["Title"] = "Categories with a similar name";
      apiUri = $"api/categories*?name={name}";
    }
    HttpClient httpClient = this.httpClientFactory.CreateClient(
      name: "DummyRoster.WebApi"
    );
    HttpRequestMessage httpRequestMessage = new(
      method: HttpMethod.Get,
      requestUri: apiUri
    );
    HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(
      httpRequestMessage
    );
    IEnumerable<Category>? categories = await httpResponseMessage
      .Content.ReadFromJsonAsync<IEnumerable<Category>>();
    return View(categories);
  }

  public Task<IActionResult>? Products(string? name)
  {
    return null;
  }

  public Task<IActionResult>? Forms(int? customerId)
  {
    return null;
  }

  public Task<IActionResult>? Invoices(int? formId)
  {
    return null;
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel
    {
      RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
    });
  }
}
