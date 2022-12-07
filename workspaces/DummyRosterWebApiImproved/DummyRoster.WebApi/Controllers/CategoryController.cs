using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DummyRoster.WebApi.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoryController : ControllerBase, ICategoryController
{

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
  [HttpGet("{id}", Name = nameof(Get))]
  [ProducesResponseType(
    200,
    Type = typeof(Category)
  )]
  [ProducesResponseType(404)]
  public Task<IActionResult> Get(int id)
  {
    throw new NotImplementedException();
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
  public Task<IEnumerable<Category>> GetAll(string? name)
  {
    throw new NotImplementedException();
  }

  /* 
    PUT: api/categories/id
    BODY: Category (JSON, XML)
   */
  [HttpPut("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public Task<IActionResult> Update(int id, [FromBody] Category entity)
  {
    throw new NotImplementedException();
  }

  /* 
    PATCH: api/categories/id
    BODY: Category (JSON, XML)
   */
  [HttpPatch("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public Task<IActionResult> PartialUpdate(int id, [FromBody] Category entity)
  {
    throw new NotImplementedException();
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
  }
}
