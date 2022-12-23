using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DummyRoster.WebApi.Controllers;

public class CategoryController : ICategoryController
{
  public Task<IActionResult> Create([FromBody] Category entity)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> Delete(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> PartialUpdate(int id, [FromBody] Category entity)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<Category>> ReadAll(string? name)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> ReadCategory(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> Update(int id, [FromBody] Category entity)
  {
    throw new NotImplementedException();
  }
}
