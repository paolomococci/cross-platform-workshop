using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories;

namespace DummyRoster.WebApi.Controllers;

[Route("api/invoices")]
[ApiController]
public class InvoiceController : ControllerBase
{

  private readonly IInvoiceRepository iInvoiceRepository;

  public InvoiceController(
    IInvoiceRepository iRepo
  )
  {
    this.iInvoiceRepository = iRepo;
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
    Invoice? managedEntity = await this.iInvoiceRepository.CreateAsync(entity);
    if (managedEntity == null)
    {
      return BadRequest("Unable to manage entity.");
    }
    return CreatedAtRoute(
      routeName: nameof(GetInvoices),
      routeValues: new { id = managedEntity.FormId },
      null
    );
  }

  /* 
    GET: api/invoices/[id]
   */
  [HttpGet("{id}", Name = nameof(GetInvoice))]
  [ProducesResponseType(
    200,
    Type = typeof(Invoice)
  )]
  [ProducesResponseType(404)]
  public async Task<IActionResult> GetInvoice(int id)
  {
    // TODO: remember that table Invoice does not have its own id
    Invoice? managedEntity = await this.iInvoiceRepository.RetrieveAsync(id);
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
  public async Task<IEnumerable<Invoice>> GetInvoices(string? formId)
  {
    if (!string.IsNullOrWhiteSpace(formId))
    {
      try
      {
        int temp = Int32.Parse(formId);
        return (await this.iInvoiceRepository.RetrieveAllAsync()).Where(
          entity => entity.FormId == temp
        );
      }
      catch (FormatException fe)
      {
        Console.WriteLine(fe.Message);
      }
    }
    return await this.iInvoiceRepository.RetrieveAllAsync();
  }

  /* 
    PUT: api/invoices/id
    BODY: Invoice (JSON, XML)
   */
  [HttpPut("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public async Task<IActionResult> Update(
    int id,
    [FromBody] Invoice entity
  )
  {
    // TODO: remember that table Invoice does not have its own id
    Invoice? managedEntity = await this.iInvoiceRepository.RetrieveAsync(id);
    if (managedEntity == null)
    {
      return NotFound();
    }
    await this.iInvoiceRepository.UpdateAsync(id, entity);
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
    // TODO: remember that table Invoice does not have its own id
    bool deleted = false;
    Invoice? managedEntity = await this.iInvoiceRepository.RetrieveAsync(id);
    if (managedEntity == null)
    {
      return NotFound();
    }
    deleted = (bool)await this.iInvoiceRepository.DeleteAsync(id);
    if (deleted)
    {
      return new NoContentResult();
    }
    return BadRequest();
  }

}
