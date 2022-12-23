using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Controllers;

public class FormController : ControllerBase, IFormController
{

  private readonly IFormRepository repository;

  public FormController(
    IFormRepository repo
  )
  {
    this.repository = repo;
  }

  /* 
    POST: api/forms
    BODY: Form (JSON, XML)
   */
  [HttpPost]
  [ProducesResponseType(
    201,
    Type = typeof(Form)
  )]
  [ProducesResponseType(400)]
  public async Task<IActionResult> Create([FromBody] Form entity)
  {
    if (entity == null)
    {
      return BadRequest();
    }
    Form? managedEntity = await this.repository.CreateAsync(entity);
    if (managedEntity == null)
    {
      return BadRequest("Unable to manage entity!");
    }
    return CreatedAtRoute(
      routeName: nameof(ReadForm),
      routeValues: new { id = managedEntity.Id },
      value: managedEntity
    );
  }

  /* 
    GET: api/forms/[id]
   */
  [HttpGet("{id}", Name = nameof(ReadForm))]
  [ProducesResponseType(
    200,
    Type = typeof(Form)
  )]
  [ProducesResponseType(404)]
  public async Task<IActionResult> ReadForm(int id)
  {
    Form? managedEntity = await this.repository.Retrieve(id);
    if (managedEntity == null)
    {
      return NotFound();
    }
    return Ok(managedEntity);
  }

  /* 
    GET: api/forms
    GET: api/forms/?customerId=[customerId]
   */
  [HttpGet]
  [ProducesResponseType(
    200,
    Type = typeof(IEnumerable<Form>)
  )]
  public async Task<IEnumerable<Form>> ReadAll(int? customerId)
  {
    if (customerId == null)
    {
      return await this.repository.RetrieveAll();
    }
    return (await this.repository.RetrieveAll()).Where(
      entity => entity.CustomerId == customerId
    );
  }

  /* 
    PUT: api/forms/id
    BODY: Form (JSON, XML)
   */
  [HttpPut("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public async Task<IActionResult> Update(int id, [FromBody] Form entity)
  {
    if (entity == null || entity.Id != id)
    {
      return BadRequest();
    }
    Form? managedEntity = await this.repository.Retrieve(id);
    if (managedEntity == null)
    {
      return NotFound();
    }
    await this.repository.UpdateAsync(id, entity);
    return new NoContentResult();
  }

  /* 
    PATCH: api/forms/id
    BODY: Form (JSON, XML)
   */
  [HttpPatch("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public async Task<IActionResult> PartialUpdate(int id, [FromBody] Form entity)
  {
    if (entity == null || entity.Id != id)
    {
      return BadRequest();
    }
    Form? managedEntity = await this.repository.Retrieve(id);
    if (managedEntity == null)
    {
      return NotFound();
    }
    await this.repository.PartialUpdateAsync(id, entity);
    return new NoContentResult();
  }

  /* 
    DELETE: api/forms/id
   */
  [HttpDelete("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public async Task<IActionResult> Delete(int id)
  {
    bool deleted = false;
    Form? managedEntity = await this.repository.Retrieve(id);
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
