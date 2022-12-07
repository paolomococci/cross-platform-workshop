using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase, IProductController
{

  private readonly IProductRepository repository;

  public ProductController(
    IProductRepository repo
  )
  {
    this.repository = repo;
  }

  /* 
    POST: api/products
    BODY: Product (JSON, XML)
   */
  [HttpPost]
  [ProducesResponseType(
    201,
    Type = typeof(Product)
  )]
  [ProducesResponseType(400)]
  public Task<IActionResult> Create([FromBody] Product entity)
  {
    throw new NotImplementedException();
  }

  /* 
    GET: api/products/[id]
   */
  [HttpGet("{id}", Name = nameof(Read))]
  [ProducesResponseType(
    200,
    Type = typeof(Product)
  )]
  [ProducesResponseType(404)]
  public async Task<IActionResult> Read(int id)
  {
    Product? managedEntity = await this.repository.RetrieveAsync(id);
    if (managedEntity == null)
    {
      return NotFound();
    }
    return Ok(managedEntity);
  }

  /* 
    GET: api/products
    GET: api/products/?name=[name]
   */
  [HttpGet]
  [ProducesResponseType(
    200,
    Type = typeof(IEnumerable<Product>)
  )]
  public async Task<IEnumerable<Product>> ReadAll(string? name)
  {
    if (string.IsNullOrWhiteSpace(name))
    {
      return await this.repository.RetrieveAllAsync();
    }
    return (await this.repository.RetrieveAllAsync()).Where(
      entity => entity.Name == name
    );
  }

  /* 
    PUT: api/products/id
    BODY: Product (JSON, XML)
   */
  [HttpPut("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public Task<IActionResult> Update(int id, [FromBody] Product entity)
  {
    throw new NotImplementedException();
  }

  /* 
    PATCH: api/products/id
    BODY: Product (JSON, XML)
   */
  [HttpPatch("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public Task<IActionResult> PartialUpdate(int id, [FromBody] Product entity)
  {
    throw new NotImplementedException();
  }

  /* 
    DELETE: api/products/id
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
