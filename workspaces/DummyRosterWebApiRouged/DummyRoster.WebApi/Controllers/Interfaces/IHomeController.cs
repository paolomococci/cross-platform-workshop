using Microsoft.AspNetCore.Mvc;

namespace DummyRoster.WebApi.Controllers.Interfaces;

public interface IHomeController
{
  public Task<IActionResult> Customers(string name);
}
