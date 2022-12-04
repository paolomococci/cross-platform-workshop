using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories;

namespace DummyRoster.WebApi.Controllers;

[Route("api/forms")]
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
    Form? managedEntity = await this.iFormRepository.CreateAsync(entity);
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
    Form? managedEntity = await this.iFormRepository.RetrieveAsync(id);
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
    if (!string.IsNullOrWhiteSpace(customerId))
    {
      try
      {
        int temp = Int32.Parse(customerId);
        return (await this.iFormRepository.RetrieveAllAsync()).Where(
          entity => entity.CustomerId == temp
        );
      }
      catch (FormatException fe)
      {
        Console.WriteLine(fe.Message);
      }
    }
    return await this.iFormRepository.RetrieveAllAsync();
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
    Form? managedEntity = await this.iFormRepository.RetrieveAsync(id);
    if (managedEntity == null)
    {
      return NotFound();
    }
    await this.iFormRepository.UpdateAsync(id, entity);
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
    Form? managedEntity = await this.iFormRepository.RetrieveAsync(id);
    if (managedEntity == null)
    {
      return NotFound();
    }
    deleted = (bool)await this.iFormRepository.DeleteAsync(id);
    if (deleted)
    {
      return new NoContentResult();
    }
    return BadRequest();
  }

}
