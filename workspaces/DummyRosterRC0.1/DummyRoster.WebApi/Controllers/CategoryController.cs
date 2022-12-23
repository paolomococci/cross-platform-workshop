using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Controllers;

public class CategoryController : ControllerBase, ICategoryController
{

  private readonly ICategoryRepository repository;

  public CategoryController(
    ICategoryRepository repo
  )
  {
    this.repository = repo;
  }
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
