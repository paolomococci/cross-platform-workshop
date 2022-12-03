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
    GET: api/products
    GET: api/products/?name=[name]
   */
  [HttpGet]
  [ProducesResponseType(
    200, 
    Type = typeof(IEnumerable<Product>)
  )]
  public Task<IEnumerable<Product>> GetProducts(string? name)
  {
    throw new NotImplementedException();
    // TODO
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
  public Task<IActionResult> GetProduct(int id)
  {
    throw new NotImplementedException();
    // TODO
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
    // TODO
  }

  /* 
    PUT: api/products/id
    BODY: Product (JSON, XML)
   */
  [HttpPut("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public Task<IActionResult> Update(
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
  public Task<IActionResult> Delete(int id)
  {
    throw new NotImplementedException();
    // TODO
  }

}
