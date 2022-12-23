using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Controllers;

public class InvoiceController : ControllerBase, IInvoiceController
{

  private readonly IInvoiceRepository repository;

  public InvoiceController(
    IInvoiceRepository repo
  )
  {
    this.repository = repo;
  }

  /* 
    POST: api/invoices
    BODY: Invoice (JSON, XML)
   */
  [HttpPost]
  [ProducesResponseType(
    201,
    Type = typeof(Invoice)
  )]
  [ProducesResponseType(400)]
  public async Task<IActionResult> Create([FromBody] Invoice entity)
  {
    if (entity == null)
    {
      return BadRequest();
    }
    Invoice? managedEntity = await this.repository.CreateAsync(entity);
    if (managedEntity == null)
    {
      return BadRequest("Unable to manage entity!");
    }
    return CreatedAtRoute(
      routeName: nameof(ReadInvoice),
      routeValues: new { id = managedEntity.Id },
      value: managedEntity
    );
  }

  /* 
    GET: api/invoices/[id]
   */
  [HttpGet("{id}", Name = nameof(ReadInvoice))]
  [ProducesResponseType(
    200,
    Type = typeof(Invoice)
  )]
  [ProducesResponseType(404)]
  public async Task<IActionResult> ReadInvoice(int id)
  {
    Invoice? managedEntity = await this.repository.Retrieve(id);
    if (managedEntity == null)
    {
      return NotFound();
    }
    return Ok(managedEntity);
  }

  /* 
    GET: api/invoices
    GET: api/invoices/?formId=[formId]
   */
  [HttpGet]
  [ProducesResponseType(
    200,
    Type = typeof(IEnumerable<Invoice>)
  )]
  public async Task<IEnumerable<Invoice>> ReadAll(int? formId)
  {
    if (formId is null)
    {
      return await this.repository.RetrieveAll();
    }
    return (await this.repository.RetrieveAll()).Where(
      entity => entity.FormId == formId
    );
  }

  /* 
    PUT: api/invoices/id
    BODY: Invoice (JSON, XML)
   */
  [HttpPut("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public async Task<IActionResult> Update(int id, [FromBody] Invoice entity)
  {
    if (entity == null || entity.Id != id)
    {
      return BadRequest();
    }
    Invoice? managedEntity = await this.repository.Retrieve(id);
    if (managedEntity == null)
    {
      return NotFound();
    }
    await this.repository.UpdateAsync(id, entity);
    return new NoContentResult();
  }

  /* 
    PATCH: api/invoices/id
    BODY: Invoice (JSON, XML)
   */
  [HttpPatch("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public async Task<IActionResult> PartialUpdate(int id, [FromBody] Invoice entity)
  {
    if (entity == null || entity.Id != id)
    {
      return BadRequest();
    }
    Invoice? managedEntity = await this.repository.Retrieve(id);
    if (managedEntity == null)
    {
      return NotFound();
    }
    await this.repository.PartialUpdateAsync(id, entity);
    return new NoContentResult();
  }

  /* 
    DELETE: api/invoices/id
   */
  [HttpDelete("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public async Task<IActionResult> Delete(int id)
  {
    bool deleted = false;
    Invoice? managedEntity = await this.repository.Retrieve(id);
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
