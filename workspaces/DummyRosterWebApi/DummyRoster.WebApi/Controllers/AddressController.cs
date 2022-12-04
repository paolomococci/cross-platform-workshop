using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories;

namespace DummyRoster.WebApi.Controllers;

[Route("api/addresses")]
[ApiController]
public class AddressController : ControllerBase
{

  private readonly IAddressRepository iAddressRepository;

  public AddressController(
    IAddressRepository iRepo
  )
  {
    this.iAddressRepository = iRepo;
  }

  /* 
    POST: api/addresses
    BODY: Address (JSON, XML)
   */
  [HttpPost]
  [ProducesResponseType(
    201,
    Type = typeof(Address)
  )]
  [ProducesResponseType(400)]
  public async Task<IActionResult> Create([FromBody] Address entity)
  {
    if (entity == null)
    {
      return BadRequest();
    }
    Address? managedEntity = await this.iAddressRepository.CreateAsync(entity);
    if (managedEntity == null)
    {
      return BadRequest("Unable to manage entity.");
    }
    return CreatedAtRoute(
      routeName: nameof(GetAddress),
      routeValues: new { id = managedEntity.Id },
      value: managedEntity
    );
  }

  /* 
    GET: api/addresses/[id]
   */
  [HttpGet("{id}", Name = nameof(GetAddress))]
  [ProducesResponseType(
    200,
    Type = typeof(Address)
  )]
  [ProducesResponseType(404)]
  public async Task<IActionResult> GetAddress(int id)
  {
    Address? managedEntity = await this.iAddressRepository.RetrieveAsync(id);
    if (managedEntity == null)
    {
      return NotFound();
    }
    return Ok(managedEntity);
  }

  /* 
    GET: api/addresses
    GET: api/addresses/?country=[country]
   */
  [HttpGet]
  [ProducesResponseType(
    200,
    Type = typeof(IEnumerable<Address>)
  )]
  public async Task<IEnumerable<Address>> GetAddresses(string? country)
  {
    if (string.IsNullOrWhiteSpace(country))
    {
      return await this.iAddressRepository.RetrieveAllAsync();
    }
    return (await this.iAddressRepository.RetrieveAllAsync()).Where(
      entity => entity.Country == country
    );
  }

  /* 
    PUT: api/addresses/id
    BODY: Address (JSON, XML)
   */
  [HttpPut("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public async Task<IActionResult> Update(
    int id,
    [FromBody] Address entity
  )
  {
    if (entity == null || entity.Id != id)
    {
      return BadRequest();
    }
    Address? managedEntity = await this.iAddressRepository.RetrieveAsync(id);
    if (managedEntity == null)
    {
      return NotFound();
    }
    await this.iAddressRepository.UpdateAsync(id, entity);
    return new NoContentResult();
  }

  /* 
    DELETE: api/addresses/id
   */
  [HttpDelete("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public async Task<IActionResult> Delete(int id)
  {
    bool deleted = false;
    Address? managedEntity = await this.iAddressRepository.RetrieveAsync(id);
    if (managedEntity == null)
    {
      return NotFound();
    }
    deleted = (bool)await this.iAddressRepository.DeleteAsync(id);
    if (deleted)
    {
      return new NoContentResult();
    }
    return BadRequest();
  }

}
