using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Controllers.Interfaces;

public interface ICategoryController
{
  public Task<IActionResult> Create([FromBody] Category entity);
  public Task<IActionResult> Get(int id);
  public Task<IEnumerable<Category>> GetAll(string? country);
  public Task<IActionResult> Update(int id, [FromBody] Category entity);
  public Task<IActionResult> PartialUpdate(int id, [FromBody] Category entity);
  public Task<IActionResult> Delete(int id);
}
