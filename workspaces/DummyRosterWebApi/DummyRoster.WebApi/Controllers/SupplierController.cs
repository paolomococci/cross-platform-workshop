using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories;

namespace DummyRoster.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SupplierController : ControllerBase
{

  private readonly ISupplierRepository iSupplierRepository;

  public SupplierController(
    ISupplierRepository iRepo
  )
  {
    this.iSupplierRepository = iRepo;
  }

  /* 
    GET: api/suppliers
    GET: api/suppliers/?name=[name]
   */
  [HttpGet]
  [ProducesResponseType(
    200, 
    Type = typeof(IEnumerable<Supplier>)
  )]
  public Task<IEnumerable<Supplier>> GetSuppliers(string? name)
  {
    throw new NotImplementedException();
    // TODO
  }

  /* 
    GET: api/suppliers/[id]
   */
  [HttpGet("{id}", Name = nameof(GetSupplier))]
  [ProducesResponseType(
    200, 
    Type = typeof(Supplier)
  )]
  [ProducesResponseType(404)]
  public Task<IActionResult> GetSupplier(int id)
  {
    throw new NotImplementedException();
    // TODO
  }

  /* 
    POST: api/suppliers
    BODY: Supplier (JSON, XML)
   */
  [HttpPost]
  [ProducesResponseType(
    201, 
    Type = typeof(Supplier)
  )]
  [ProducesResponseType(400)]
  public Task<IActionResult> Create([FromBody] Supplier entity)
  {
    throw new NotImplementedException();
    // TODO
  }

  /* 
    PUT: api/suppliers/id
    BODY: Supplier (JSON, XML)
   */
  [HttpPut("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public Task<IActionResult> Update(
    int id,
    [FromBody] Supplier entity
  )
  {
    throw new NotImplementedException();
    // TODO
  }

  /* 
    DELETE: api/suppliers/id
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
