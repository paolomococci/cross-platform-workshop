using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories;

namespace DummyRoster.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FormController : ControllerBase
{

  private readonly IFormRepository iFormRepository;

  public FormController(
    IFormRepository iRepo
  )
  {
    this.iFormRepository = iRepo;
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
    Form? managedEntity = await iFormRepository.CreateAsync(entity);
    if (managedEntity == null)
    {
      return BadRequest("Unable to manage entity.");
    }
    return CreatedAtRoute(
      routeName: nameof(GetForm),
      routeValues: new { id = managedEntity.Id },
      value: managedEntity
    );
  }

  /* 
    GET: api/forms/[id]
   */
  [HttpGet("{id}", Name = nameof(GetForm))]
  [ProducesResponseType(
    200,
    Type = typeof(Form)
  )]
  [ProducesResponseType(404)]
  public async Task<IActionResult> GetForm(int id)
  {
    Form? managedEntity = await iFormRepository.RetrieveAsync(id);
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
  public async Task<IEnumerable<Form>> GetForms(string? customerId)
  {
    throw new NotImplementedException();
    // TODO
  }

  /* 
    PUT: api/forms/id
    BODY: Form (JSON, XML)
   */
  [HttpPut("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public async Task<IActionResult> Update(
    int id,
    [FromBody] Form entity
  )
  {
    throw new NotImplementedException();
    // TODO
  }

  /* 
    DELETE: api/foroms/id
   */
  [HttpDelete("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public async Task<IActionResult> Delete(int id)
  {
    throw new NotImplementedException();
    // TODO
  }

}
