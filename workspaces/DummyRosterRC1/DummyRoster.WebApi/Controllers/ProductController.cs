using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
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
  public async Task<IActionResult> Create([FromBody] Product entity)
  {
    throw new NotImplementedException();
  }

  /* 
    GET: api/products/[id]
   */
  [HttpGet("{id}", Name = nameof(ReadProduct))]
  [ProducesResponseType(
    200,
    Type = typeof(Product)
  )]
  [ProducesResponseType(404)]
  public async Task<IActionResult> ReadProduct(int id)
  {
    throw new NotImplementedException();
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
    throw new NotImplementedException();
  }

  /* 
    PUT: api/products/id
    BODY: Product (JSON, XML)
   */
  [HttpPut("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public async Task<IActionResult> Update(int id, [FromBody] Product entity)
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
  public async Task<IActionResult> PartialUpdate(int id, [FromBody] Product entity)
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
  public async Task<IActionResult> Delete(int id)
  {
    bool deleted = false;
    Product? managedEntity = await this.repository.Retrieve(id);
    if (managedEntity == null)
    {
      return NotFound();
    }
    deleted = (bool)await this.repository.DeleteAsync(id);
    if (deleted)
    {
      return new NoContentResult();
    }
    return BadRequest();
  }
}
