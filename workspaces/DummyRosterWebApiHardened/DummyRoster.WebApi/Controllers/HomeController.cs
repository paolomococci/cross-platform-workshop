using Microsoft.AspNetCore.Mvc;
using DummyRoster.WebApi.Controllers.Interfaces;
using DummyRoster.Common.DataContext.Data;

namespace DummyRoster.WebApi.Controllers;

public class HomeController : IHomeController
{
  ILogger<HomeController> logger;
  DummyRosterContext dummyRosterContext;
  IHttpClientFactory httpClientFactory;
  public Task<IActionResult> Customers(string name)
  {
    throw new NotImplementedException();
  }
}
