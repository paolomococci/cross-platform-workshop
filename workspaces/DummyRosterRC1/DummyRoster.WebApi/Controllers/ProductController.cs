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
  public Task<IActionResult> Create([FromBody] Product entity)
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
  public Task<IActionResult> ReadProduct(int id)
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
  public Task<IEnumerable<Product>> ReadAll(string? name)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> Update(int id, [FromBody] Product entity)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> PartialUpdate(int id, [FromBody] Product entity)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> Delete(int id)
  {
    throw new NotImplementedException();
  }
}
