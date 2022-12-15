using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase, ICategoryController
{

  private readonly ICategoryRepository repository;

  public CategoryController(
    ICategoryRepository repo
  )
  {
    this.repository = repo;
  }

  /* 
    POST: api/categories
    BODY: Category (JSON, XML)
   */
  [HttpPost]
  [ProducesResponseType(
    201,
    Type = typeof(Category)
  )]
  [ProducesResponseType(400)]
  public Task<IActionResult> Create([FromBody] Category entity)
  {
    throw new NotImplementedException();
  }

  /* 
    GET: api/categories/[id]
   */
  [HttpGet("{id}", Name = nameof(ReadCategory))]
  [ProducesResponseType(
    200,
    Type = typeof(Category)
  )]
  [ProducesResponseType(404)]
  public Task<IActionResult> ReadCategory(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<Category>> ReadAll(string? name)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> Update(int id, [FromBody] Category entity)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> PartialUpdate(int id, [FromBody] Category entity)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> Delete(int id)
  {
    throw new NotImplementedException();
  }
}
