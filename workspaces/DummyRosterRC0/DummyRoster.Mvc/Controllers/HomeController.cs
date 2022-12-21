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
      apiUri = $"{baseUri}api/suppliers";
    }
    else
    {
      ViewData["Title"] = "Suppliers with a similar name";
      apiUri = $"{baseUri}api/suppliers/?name={name}";
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
      apiUri = $"{baseUri}api/carriers";
    }
    else
    {
      ViewData["Title"] = "Carriers with a similar name";
      apiUri = $"{baseUri}api/carriers/?name={name}";
    }
    HttpRequestMessage httpRequestMessage = new(
      method: HttpMethod.Get,
      requestUri: apiUri
    );
    HttpResponseMessage httpResponseMessage = await this.httpClient.SendAsync(
      httpRequestMessage
    );
    IEnumerable<Carrier>? carriers = await httpResponseMessage
      .Content.ReadFromJsonAsync<IEnumerable<Carrier>>();
    return View(carriers);
  }

  public async Task<IActionResult> Addresses(string? country)
  {
    string apiUri = "";
    if (string.IsNullOrEmpty(country))
    {
      ViewData["Title"] = "All Addresses";
      apiUri = $"{baseUri}api/addresses";
    }
    else
    {
      ViewData["Title"] = "Addresses with a similar country";
      apiUri = $"{baseUri}api/addresses/?country={country}";
    }
    HttpRequestMessage httpRequestMessage = new(
      method: HttpMethod.Get,
      requestUri: apiUri
    );
    HttpResponseMessage httpResponseMessage = await this.httpClient.SendAsync(
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
      apiUri = $"{baseUri}api/credentials";
    }
    else
    {
      ViewData["Title"] = "Credentials with a similar email";
      apiUri = $"{baseUri}api/credentials/?email={email}";
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

  public async Task<IActionResult> Categories(string? name)
  {
    string apiUri = "";
    if (string.IsNullOrEmpty(name))
    {
      ViewData["Title"] = "All Categories";
      apiUri = $"{baseUri}api/categories";
    }
    else
    {
      ViewData["Title"] = "Categories with a similar name";
      apiUri = $"{baseUri}api/categories/?name={name}";
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

  public async Task<IActionResult> Products(string? name)
  {
    string apiUri = "";
    if (string.IsNullOrEmpty(name))
    {
      ViewData["Title"] = "All Products";
      apiUri = $"{baseUri}api/products";
    }
    else
    {
      ViewData["Title"] = "Products with a similar name";
      apiUri = $"{baseUri}api/products/?name={name}";
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

  public async Task<IActionResult> Forms(int? customerId)
  {
    string apiUri = "";
    if (string.IsNullOrEmpty(customerId.ToString()))
    {
      ViewData["Title"] = "All Forms";
      apiUri = $"{baseUri}api/forms";
    }
    else
    {
      ViewData["Title"] = "Forms with a similar customerId";
      apiUri = $"{baseUri}api/forms/?customerId={customerId.ToString()}";
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

  public async Task<IActionResult> Invoices(int? formId)
  {
    string apiUri = "";
    if (string.IsNullOrEmpty(formId.ToString()))
    {
      ViewData["Title"] = "All Invoices";
      apiUri = $"{baseUri}api/invoices";
    }
    else
    {
      ViewData["Title"] = "Invoices with a similar formId";
      apiUri = $"{baseUri}api/invoices/?formId={formId.ToString()}";
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

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel
    {
      RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
    });
  }
}
