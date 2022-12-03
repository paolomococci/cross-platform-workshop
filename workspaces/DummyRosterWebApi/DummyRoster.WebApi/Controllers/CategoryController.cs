using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories;

namespace DummyRoster.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{

  private readonly ICategoryRepository iCategoryRepository;

  public CategoryController(
    ICategoryRepository iRepo
  )
  {
    this.iCategoryRepository = iRepo;
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
    // TODO
  }

  /* 
    GET: api/categories/[id]
   */
  [HttpGet("{id}", Name = nameof(GetCategory))]
  [ProducesResponseType(
    200,
    Type = typeof(Category)
  )]
  [ProducesResponseType(404)]
  public Task<IActionResult> GetCategory(int id)
  {
    throw new NotImplementedException();
    // TODO
  }

  /* 
    GET: api/categories
    GET: api/categories/?name=[name]
   */
  [HttpGet]
  [ProducesResponseType(
    200,
    Type = typeof(IEnumerable<Category>)
  )]
  public Task<IEnumerable<Category>> GetCategories(string? name)
  {
    throw new NotImplementedException();
    // TODO
  }

  /* 
    PUT: api/categories/id
    BODY: Category (JSON, XML)
   */
  [HttpPut("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public Task<IActionResult> Update(
    int id,
    [FromBody] Category entity
  )
  {
    throw new NotImplementedException();
    // TODO
  }

  /* 
    DELETE: api/categories/id
   */
  [HttpDelete("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public Task<IActionResult> Delete(int id)
  {
    throw new NotImplementedException();
    // TODO
  }

}
