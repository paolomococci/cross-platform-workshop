using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories;

namespace DummyRoster.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{

  private readonly IProductRepository iProductRepository;

  public ProductController(
    IProductRepository iRepo
  )
  {
    this.iProductRepository = iRepo;
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
    if (entity == null)
    {
      return BadRequest();
    }
    Product? managedEntity = await this.iProductRepository.CreateAsync(entity);
    if (managedEntity == null)
    {
      return BadRequest("Unable to manage entity.");
    }
    return CreatedAtRoute(
      routeName: nameof(GetProduct),
      routeValues: new { id = managedEntity.Id },
      value: managedEntity
    );
  }

  /* 
    GET: api/products/[id]
   */
  [HttpGet("{id}", Name = nameof(GetProduct))]
  [ProducesResponseType(
    200,
    Type = typeof(Product)
  )]
  [ProducesResponseType(404)]
  public async Task<IActionResult> GetProduct(int id)
  {
    Product? managedEntity = await this.iProductRepository.RetrieveAsync(id);
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
  public async Task<IEnumerable<Product>> GetProducts(string? name)
  {
    if (string.IsNullOrWhiteSpace(name))
    {
      return await this.iProductRepository.RetrieveAllAsync();
    }
    return (await this.iProductRepository.RetrieveAllAsync()).Where(
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
  public async Task<IActionResult> Update(
    int id,
    [FromBody] Product entity
  )
  {
    throw new NotImplementedException();
    // TODO
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
    throw new NotImplementedException();
    // TODO
  }

}
