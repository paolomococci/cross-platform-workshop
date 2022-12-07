using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Controllers;

[Route("api/suppliers")]
[ApiController]
public class SupplierController : ControllerBase, ISupplierController
{

  private readonly ISupplierRepository repository;

  public SupplierController(
    ISupplierRepository repo
  )
  {
    this.repository = repo;
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
  }

  /* 
    GET: api/suppliers/[id]
   */
  [HttpGet("{id}", Name = nameof(Get))]
  [ProducesResponseType(
    200,
    Type = typeof(Supplier)
  )]
  [ProducesResponseType(404)]
  public Task<IActionResult> Get(int id)
  {
    throw new NotImplementedException();
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
  public Task<IEnumerable<Supplier>> GetAll(string? name)
  {
    throw new NotImplementedException();
  }

  /* 
    PUT: api/suppliers/id
    BODY: Supplier (JSON, XML)
   */
  [HttpPut("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public Task<IActionResult> Update(int id, [FromBody] Supplier entity)
  {
    throw new NotImplementedException();
  }

  /* 
    PATCH: api/suppliers/id
    BODY: Supplier (JSON, XML)
   */
  [HttpPatch("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public Task<IActionResult> PartialUpdate(int id, [FromBody] Supplier entity)
  {
    throw new NotImplementedException();
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
  }
}
