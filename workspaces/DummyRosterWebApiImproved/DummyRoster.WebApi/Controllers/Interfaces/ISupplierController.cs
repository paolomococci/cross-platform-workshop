using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Controllers.Interfaces;

public interface ISupplierController
{
  public Task<IActionResult> Create([FromBody] Supplier entity);
  public Task<IActionResult> Get(int id);
  public Task<IEnumerable<Supplier>> GetAll(string? country);
  public Task<IActionResult> Update(int id, [FromBody] Supplier entity);
  public Task<IActionResult> PartialUpdate(int id, [FromBody] Supplier entity);
  public Task<IActionResult> Delete(int id);
}

