using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Controllers.Interfaces;

public interface ICategoryController
{
  public Task<IActionResult> Create([FromBody] Category entity);
  public Task<IActionResult> ReadCategory(int id);
  public Task<IEnumerable<Category>> ReadAll(string? name);
  public Task<IActionResult> Update(int id, [FromBody] Category entity);
  public Task<IActionResult> PartialUpdate(int id, [FromBody] Category entity);
  public Task<IActionResult> Delete(int id);
}
