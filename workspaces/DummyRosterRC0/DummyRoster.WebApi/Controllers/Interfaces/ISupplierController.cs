using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Controllers.Interfaces;

public interface ISupplierController
{
  public Task<IActionResult> Create([FromBody] Supplier entity);
  public Task<IActionResult> ReadSupplier(int id);
  public Task<IEnumerable<Supplier>> ReadAll(string? name);
  public Task<IActionResult> Update(int id, [FromBody] Supplier entity);
  public Task<IActionResult> PartialUpdate(int id, [FromBody] Supplier entity);
  public Task<IActionResult> Delete(int id);
}
