using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Controllers;

public class CredentialController : ControllerBase, ICredentialController
{

  private readonly ICredentialRepository repository;

  public CredentialController(
    ICredentialRepository repo
  )
  {
    this.repository = repo;
  }

  /* 
    POST: api/credentials
    BODY: Credential (JSON, XML)
   */
  [HttpPost]
  [ProducesResponseType(
    201,
    Type = typeof(Credential)
  )]
  [ProducesResponseType(400)]
  public async Task<IActionResult> Create([FromBody] Credential entity)
  {
    if (entity == null)
    {
      return BadRequest();
    }
    Credential? managedEntity = await this.repository.CreateAsync(entity);
    if (managedEntity == null)
    {
      return BadRequest("Unable to manage entity!");
    }
    return CreatedAtRoute(
      routeName: nameof(ReadCredential),
      routeValues: new { id = managedEntity.Id },
      value: managedEntity
    );
  }

  /* 
    GET: api/credentials/[id]
   */
  [HttpGet("{id}", Name = nameof(ReadCredential))]
  [ProducesResponseType(
    200,
    Type = typeof(Credential)
  )]
  [ProducesResponseType(404)]
  public async Task<IActionResult> ReadCredential(int id)
  {
    Credential? managedEntity = await this.repository.Retrieve(id);
    if (managedEntity == null)
    {
      return NotFound();
    }
    return Ok(managedEntity);
  }

  /* 
    GET: api/credentials
    GET: api/credentials/?email=[email]
   */
  [HttpGet]
  [ProducesResponseType(
    200,
    Type = typeof(IEnumerable<Credential>)
  )]
  public async Task<IEnumerable<Credential>> ReadAll(string? email)
  {
    if (string.IsNullOrWhiteSpace(email))
    {
      return await this.repository.RetrieveAll();
    }
    return (await this.repository.RetrieveAll()).Where(
      entity => entity.Email == email
    );
  }

  /* 
    PUT: api/credentials/id
    BODY: Credential (JSON, XML)
   */
  [HttpPut("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public async Task<IActionResult> Update(int id, [FromBody] Credential entity)
  {
    if (entity == null || entity.Id != id)
    {
      return BadRequest();
    }
    Credential? managedEntity = await this.repository.Retrieve(id);
    if (managedEntity == null)
    {
      return NotFound();
    }
    await this.repository.UpdateAsync(id, entity);
    return new NoContentResult();
  }

  /* 
    PATCH: api/credentials/id
    BODY: Credential (JSON, XML)
   */
  [HttpPatch("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public async Task<IActionResult> PartialUpdate(int id, [FromBody] Credential entity)
  {
    if (entity == null || entity.Id != id)
    {
      return BadRequest();
    }
    Credential? managedEntity = await this.repository.Retrieve(id);
    if (managedEntity == null)
    {
      return NotFound();
    }
    await this.repository.PartialUpdateAsync(id, entity);
    return new NoContentResult();
  }

  /* 
    DELETE: api/credentials/id
   */
  [HttpDelete("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public async Task<IActionResult> Delete(int id)
  {
    bool deleted = false;
    Credential? managedEntity = await this.repository.Retrieve(id);
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
