using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DummyRoster.WebApi.Controllers;

public class SupplierController : ControllerBase, ISupplierController
{
  public Task<IActionResult> Create([FromBody] Supplier entity)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> Delete(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> PartialUpdate(int id, [FromBody] Supplier entity)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<Supplier>> ReadAll(string? name)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> ReadSupplier(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> Update(int id, [FromBody] Supplier entity)
  {
    throw new NotImplementedException();
  }
}
