using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Controllers;

[ApiController]
[Route("api/suppliers")]
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
  public async Task<IActionResult> Create([FromBody] Supplier entity)
  {
    if (entity == null)
    {
      return BadRequest();
    }
    Supplier? managedEntity = await this.repository.CreateAsync(entity);
    if (managedEntity == null)
    {
      return BadRequest("Unable to manage entity!");
    }
    return CreatedAtRoute(
      routeName: nameof(ReadSupplier),
      routeValues: new { id = managedEntity.Id },
      value: managedEntity
    );
  }

  /* 
    GET: api/suppliers/[id]
   */
  [HttpGet("{id}", Name = nameof(ReadSupplier))]
  [ProducesResponseType(
    200,
    Type = typeof(Supplier)
  )]
  [ProducesResponseType(404)]
  public async Task<IActionResult> ReadSupplier(int id)
  {
    Supplier? managedEntity = await this.repository.Retrieve(id);
    if (managedEntity == null)
    {
      return NotFound();
    }
    return Ok(managedEntity);
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
  public async Task<IEnumerable<Supplier>> ReadAll(string? name)
  {
    if (string.IsNullOrWhiteSpace(name))
    {
      return await this.repository.RetrieveAll();
    }
    return (await this.repository.RetrieveAll()).Where(
      entity => entity.Name == name
    );
  }

  /* 
    PUT: api/suppliers/id
    BODY: Supplier (JSON, XML)
   */
  [HttpPut("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public async Task<IActionResult> Update(int id, [FromBody] Supplier entity)
  {
    if (entity == null || entity.Id != id)
    {
      return BadRequest();
    }
    Supplier? managedEntity = await this.repository.Retrieve(id);
    if (managedEntity == null)
    {
      return NotFound();
    }
    await this.repository.UpdateAsync(id, entity);
    return new NoContentResult();
  }

  /* 
    PATCH: api/suppliers/id
    BODY: Supplier (JSON, XML)
   */
  [HttpPatch("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public async Task<IActionResult> PartialUpdate(int id, [FromBody] Supplier entity)
  {
    if (entity == null || entity.Id != id)
    {
      return BadRequest();
    }
    Supplier? managedEntity = await this.repository.Retrieve(id);
    if (managedEntity == null)
    {
      return NotFound();
    }
    await this.repository.PartialUpdateAsync(id, entity);
    return new NoContentResult();
  }

  /* 
    DELETE: api/suppliers/id
   */
  [HttpDelete("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public async Task<IActionResult> Delete(int id)
  {
    bool deleted = false;
    Supplier? managedEntity = await this.repository.Retrieve(id);
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
