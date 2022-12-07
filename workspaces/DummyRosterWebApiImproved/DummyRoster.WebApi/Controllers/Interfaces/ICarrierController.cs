using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Controllers.Interfaces;

public interface ICarrierController
{
  public Task<IActionResult> Create([FromBody] Carrier entity);
  public Task<IActionResult> Get(int id);
  public Task<IEnumerable<Carrier>> GetAll(string? name);
  public Task<IActionResult> Update(int id, [FromBody] Carrier entity);
  public Task<IActionResult> PartialUpdate(int id, [FromBody] Carrier entity);
  public Task<IActionResult> Delete(int id);
}
