using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Controllers;

public class SupplierController : ControllerBase, ISupplierController
{

  private readonly ISupplierRepository repository;

  public SupplierController(
    ISupplierRepository repo
  )
  {
    this.repository = repo;
  }
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
