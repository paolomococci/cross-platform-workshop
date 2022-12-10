using Microsoft.AspNetCore.Mvc;
using DummyRoster.WebApi.Controllers.Interfaces;
using DummyRoster.Common.DataContext.Data;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Controllers;

public class HomeController : Controller, IHomeController
{
  ILogger<HomeController> _logger;
  DummyRosterContext dummyRosterContext;
  IHttpClientFactory httpClientFactory;

  public HomeController(
    ILogger<HomeController> logger,
    DummyRosterContext dummyRosterContext,
    IHttpClientFactory httpClientFactory
  )
  {
    this._logger = logger;
    this.dummyRosterContext = dummyRosterContext;
    this.httpClientFactory = httpClientFactory;
  }

  public async Task<IActionResult> Customers(string name)
  {
    string uri;

    if (string.IsNullOrEmpty(name))
    {
      ViewData["Title"] = "all customers registered in the system";
      uri = "api/customers/?name={name}";
    }
    else
    {
      ViewData["Title"] = $"customers who have a name similar to {name}";
      uri = $"api/customers/";
    }

    HttpClient httpClient = this.httpClientFactory.CreateClient(
      name: "DummyRoster.WebApi"
    );

    HttpRequestMessage httpRequestMessage = new(
      method: HttpMethod.Get,
      requestUri: uri
    );

    HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(
      httpRequestMessage
    );

    IEnumerable<Customer>? customers = await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<Customer>>();

    return View(customers);
  }
}
