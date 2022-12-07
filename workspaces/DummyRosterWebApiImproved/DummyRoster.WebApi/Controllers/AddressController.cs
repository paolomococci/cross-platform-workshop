using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Controllers;

[ApiController]
[Route("api/addresses")]
public class AddressController : ControllerBase, IAddressController
{

  private readonly IAddressRepository repository;

  public AddressController(
    IAddressRepository repo
  )
  {
    this.repository = repo;
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
    Address? managedEntity = await this.repository.CreateAsync(entity);
    if (managedEntity == null)
    {
      return BadRequest("Unable to manage entity!");
    }
    return CreatedAtRoute(
      routeName: nameof(ReadAddress),
      routeValues: new { id = managedEntity.Id },
      value: managedEntity
    );
  }

  /* 
    GET: api/addresses/[id]
   */
  [HttpGet("{id}", Name = nameof(ReadAddress))]
  [ProducesResponseType(
    200,
    Type = typeof(Address)
  )]
  [ProducesResponseType(404)]
  public async Task<IActionResult> ReadAddress(int id)
  {
    Address? managedEntity = await this.repository.RetrieveAsync(id);
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
  public async Task<IEnumerable<Address>> ReadAll(string? country)
  {
    if (string.IsNullOrWhiteSpace(country))
    {
      return await this.repository.RetrieveAllAsync();
    }
    return (await this.repository.RetrieveAllAsync()).Where(
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
  public Task<IActionResult> Update(int id, [FromBody] Address entity)
  {
    throw new NotImplementedException();
  }

  /* 
    PATCH: api/addresses/id
    BODY: Address (JSON, XML)
   */
  [HttpPatch("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public Task<IActionResult> PartialUpdate(int id, [FromBody] Address entity)
  {
    throw new NotImplementedException();
  }

  /* 
    DELETE: api/addresses/id
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
