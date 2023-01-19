using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories;

namespace DummyRoster.WebApi.Controllers;

[Route("api/categories")]
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
  public async Task<IActionResult> Create([FromBody] Category entity)
  {
    if (entity == null)
    {
      return BadRequest();
    }
    Category? managedEntity = await this.iCategoryRepository.CreateAsync(entity);
    if (managedEntity == null)
    {
      return BadRequest("Unable to manage entity.");
    }
    return CreatedAtRoute(
      routeName: nameof(GetCategory),
      routeValues: new { id = managedEntity.Id },
      value: managedEntity
    );
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
  public async Task<IActionResult> GetCategory(int id)
  {
    Category? managedEntity = await this.iCategoryRepository.RetrieveAsync(id);
    if (managedEntity == null)
    {
      return NotFound();
    }
    return Ok(managedEntity);
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
  public async Task<IEnumerable<Category>> GetCategories(string? name)
  {
    if (string.IsNullOrWhiteSpace(name))
    {
      return await this.iCategoryRepository.RetrieveAllAsync();
    }
    return (await this.iCategoryRepository.RetrieveAllAsync()).Where(
      entity => entity.Name == name
    );
  }

  /* 
    PUT: api/categories/id
    BODY: Category (JSON, XML)
   */
  [HttpPut("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public async Task<IActionResult> Update(
    int id,
    [FromBody] Category entity
  )
  {
    Category? managedEntity = await this.iCategoryRepository.RetrieveAsync(id);
    if (managedEntity == null)
    {
      return NotFound();
    }
    await this.iCategoryRepository.UpdateAsync(id, entity);
    return new NoContentResult();
  }

  /* 
    DELETE: api/categories/id
   */
  [HttpDelete("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public async Task<IActionResult> Delete(int id)
  {
    bool deleted = false;
    Category? managedEntity = await this.iCategoryRepository.RetrieveAsync(id);
    if (managedEntity == null)
    {
      return NotFound();
    }
    deleted = (bool)await this.iCategoryRepository.DeleteAsync(id);
    if (deleted)
    {
      return new NoContentResult();
    }
    return BadRequest();
  }

}
