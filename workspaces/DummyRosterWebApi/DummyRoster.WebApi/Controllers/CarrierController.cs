using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories;

namespace DummyRoster.WebApi.Controllers;

[Route("api/carriers")]
[ApiController]
public class CarrierController : ControllerBase
{

  private readonly ICarrierRepository iCarrierRepository;

  public CarrierController(
    ICarrierRepository iRepo
  )
  {
    this.iCarrierRepository = iRepo;
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
    if (entity == null)
    {
      return BadRequest();
    }
    Carrier? managedEntity = await this.iCarrierRepository.CreateAsync(entity);
    if (managedEntity == null)
    {
      return BadRequest("Unable to manage entity.");
    }
    return CreatedAtRoute(
      routeName: nameof(GetCarrier),
      routeValues: new { id = managedEntity.Id },
      value: managedEntity
    );
  }

  /* 
    GET: api/carriers/[id]
   */
  [HttpGet("{id}", Name = nameof(GetCarrier))]
  [ProducesResponseType(
    200,
    Type = typeof(Carrier)
  )]
  [ProducesResponseType(404)]
  public async Task<IActionResult> GetCarrier(int id)
  {
    Carrier? managedEntity = await this.iCarrierRepository.RetrieveAsync(id);
    if (managedEntity == null)
    {
      return NotFound();
    }
    return Ok(managedEntity);
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
  public async Task<IEnumerable<Carrier>> GetCarriers(string? name)
  {
    if (string.IsNullOrWhiteSpace(name))
    {
      return await this.iCarrierRepository.RetrieveAllAsync();
    }
    return (await this.iCarrierRepository.RetrieveAllAsync()).Where(
      entity => entity.Name == name
    );
  }

  /* 
    PUT: api/carriers/id
    BODY: Carrier (JSON, XML)
   */
  [HttpPut("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public async Task<IActionResult> Update(
    int id,
    [FromBody] Carrier entity
  )
  {
    Carrier? managedEntity = await this.iCarrierRepository.RetrieveAsync(id);
    if (managedEntity == null)
    {
      return NotFound();
    }
    await this.iCarrierRepository.UpdateAsync(id, entity);
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
    Carrier? managedEntity = await this.iCarrierRepository.RetrieveAsync(id);
    if (managedEntity == null)
    {
      return NotFound();
    }
    deleted = (bool)await this.iCarrierRepository.DeleteAsync(id);
    if (deleted)
    {
      return new NoContentResult();
    }
    return BadRequest();
  }

}
