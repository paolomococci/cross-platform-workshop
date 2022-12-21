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
  private readonly HttpClient httpClient;
  private const string baseUri = "https://localhost:5001/";

  public HomeController(
    ILogger<HomeController> logger,
    IHttpClientFactory httpClientFactory
  )
  {
    this._logger = logger;
    this.httpClientFactory = httpClientFactory;
    /*
      How to fix, only in the development environment and when it is not convenient to do otherwise, the following error:
      "The SSL connection could not be established, see inner exception".
      The following code, applied to file HomeController.cs, is capable of overriding the validity of the certificate.
     */
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

  [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any)]
  public IActionResult Index()
  {
    return View();
  }

  [Route("Restricted")]
  [Authorize(Roles = "Admins")]
  public IActionResult Restricted()
  {
    return View();
  }

  public async Task<IActionResult> Employees(string? name)
  {
    string apiUri = "";
    if (string.IsNullOrEmpty(name))
    {
      ViewData["Title"] = "All Employees";
      apiUri = $"{baseUri}api/employees";
    }
    else
    {
      ViewData["Title"] = "Employees with a similar name";
      apiUri = $"{baseUri}api/employees/?name={name}";
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

  public async Task<IActionResult> Customers(string? name)
  {
    string apiUri = "";
    if (string.IsNullOrEmpty(name))
    {
      ViewData["Title"] = "All Customers";
      apiUri = $"{baseUri}api/customers";
    }
    else
    {
      ViewData["Title"] = "Customers with a similar name";
      apiUri = $"{baseUri}api/customers/?name={name}";
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
      apiUri = $"api/suppliers/?name={name}";
    }
    HttpRequestMessage httpRequestMessage = new(
      method: HttpMethod.Get,
      requestUri: apiUri
    );
    HttpResponseMessage httpResponseMessage = await this.httpClient.SendAsync(
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
      apiUri = $"api/carriers/?name={name}";
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
      apiUri = $"api/addresses/?name={name}";
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

  public async Task<IActionResult> Credentials(string? email)
  {
    string apiUri = "";
    if (string.IsNullOrEmpty(email))
    {
      ViewData["Title"] = "All Credentials";
      apiUri = "api/credentials";
    }
    else
    {
      ViewData["Title"] = "Credentials with a similar email";
      apiUri = $"api/credentials/?email={email}";
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
    IEnumerable<Credential>? credentials = await httpResponseMessage
      .Content.ReadFromJsonAsync<IEnumerable<Credential>>();
    return View(credentials);
  }

  public async Task<IActionResult> Categories(string? name)
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
      apiUri = $"api/categories/?name={name}";
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

  public async Task<IActionResult> Products(string? name)
  {
    string apiUri = "";
    if (string.IsNullOrEmpty(name))
    {
      ViewData["Title"] = "All Products";
      apiUri = "api/products";
    }
    else
    {
      ViewData["Title"] = "Products with a similar name";
      apiUri = $"api/products/?name={name}";
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
    IEnumerable<Product>? products = await httpResponseMessage
      .Content.ReadFromJsonAsync<IEnumerable<Product>>();
    return View(products);
  }

  public async Task<IActionResult> Forms(int? customerId)
  {
    string apiUri = "";
    if (string.IsNullOrEmpty(customerId.ToString()))
    {
      ViewData["Title"] = "All Forms";
      apiUri = "api/forms";
    }
    else
    {
      ViewData["Title"] = "Forms with a similar customerId";
      apiUri = $"api/forms/?customerId={customerId.ToString()}";
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
    IEnumerable<Form>? forms = await httpResponseMessage
      .Content.ReadFromJsonAsync<IEnumerable<Form>>();
    return View(forms);
  }

  public async Task<IActionResult> Invoices(int? formId)
  {
    string apiUri = "";
    if (string.IsNullOrEmpty(formId.ToString()))
    {
      ViewData["Title"] = "All Invoices";
      apiUri = "api/invoices";
    }
    else
    {
      ViewData["Title"] = "Invoices with a similar formId";
      apiUri = $"api/invoices/?formId={formId.ToString()}";
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
    IEnumerable<Invoice>? invoices = await httpResponseMessage
      .Content.ReadFromJsonAsync<IEnumerable<Invoice>>();
    return View(invoices);
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
