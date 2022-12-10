using Microsoft.AspNetCore.Mvc;
using DummyRoster.WebApi.Controllers.Interfaces;

namespace DummyRoster.WebApi.Controllers;

public class HomeController : IHomeController
{
  public Task<IActionResult> Customers(string name)
  {
    throw new NotImplementedException();
  }
}
