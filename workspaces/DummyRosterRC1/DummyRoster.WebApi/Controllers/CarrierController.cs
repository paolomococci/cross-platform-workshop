using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CarrierController : ControllerBase, ICarrierController
{

  private readonly ICarrierRepository repository;

  public CarrierController(
    ICarrierRepository repo
  )
  {
    this.repository = repo;
  }

  /* 
    POST: api/carriers
    BODY: Carrier (JSON, XML)
   */
  [HttpPost]
  [ProducesResponseType(
    201,
    Type = typeof(Carrier)
  )]
  [ProducesResponseType(400)]
  public async Task<IActionResult> Create([FromBody] Carrier entity)
  {
    throw new NotImplementedException();
  }

  /* 
    GET: api/carriers/[id]
   */
  [HttpGet("{id}", Name = nameof(ReadCarrier))]
  [ProducesResponseType(
    200,
    Type = typeof(Carrier)
  )]
  [ProducesResponseType(404)]
  public async Task<IActionResult> ReadCarrier(int id)
  {
    throw new NotImplementedException();
  }

  /* 
    GET: api/carriers
    GET: api/carriers/?name=[name]
   */
  [HttpGet]
  [ProducesResponseType(
    200,
    Type = typeof(IEnumerable<Carrier>)
  )]
  public async Task<IEnumerable<Carrier>> ReadAll(string? name)
  {
    throw new NotImplementedException();
  }

  /* 
    PUT: api/carriers/id
    BODY: Carrier (JSON, XML)
   */
  [HttpPut("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public async Task<IActionResult> Update(int id, [FromBody] Carrier entity)
  {
    if (entity == null || entity.Id != id)
    {
      return BadRequest();
    }
    Carrier? managedEntity = await this.repository.Retrieve(id);
    if (managedEntity == null)
    {
      return NotFound();
    }
    await this.repository.UpdateAsync(id, entity);
    return new NoContentResult();
  }

  /* 
    PATCH: api/carriers/id
    BODY: Carrier (JSON, XML)
   */
  [HttpPatch("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public async Task<IActionResult> PartialUpdate(int id, [FromBody] Carrier entity)
  {
    if (entity == null || entity.Id != id)
    {
      return BadRequest();
    }
    Carrier? managedEntity = await this.repository.Retrieve(id);
    if (managedEntity == null)
    {
      return NotFound();
    }
    await this.repository.PartialUpdateAsync(id, entity);
    return new NoContentResult();
  }

  /* 
    DELETE: api/carriers/id
   */
  [HttpDelete("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public async Task<IActionResult> Delete(int id)
  {
    bool deleted = false;
    Carrier? managedEntity = await this.repository.Retrieve(id);
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
