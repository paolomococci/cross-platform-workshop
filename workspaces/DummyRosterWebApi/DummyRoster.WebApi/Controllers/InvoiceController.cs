using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories;

namespace DummyRoster.WebApi.Controllers;

[Route("api/[controller]")]
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
    GET: api/invoices
    GET: api/invoices/?formId=[formId]
   */
  [HttpGet]
  [ProducesResponseType(
    200,
    Type = typeof(IEnumerable<Invoice>)
  )]
  public Task<IEnumerable<Invoice>> GetInvoices(string? formId)
  {
    throw new NotImplementedException();
    // TODO
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
  public Task<IActionResult> GetInvoice(int id)
  {
    throw new NotImplementedException();
    // TODO
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
  public Task<IActionResult> Create([FromBody] Invoice entity)
  {
    throw new NotImplementedException();
    // TODO
  }

  /* 
    PUT: api/invoices/id
    BODY: Invoice (JSON, XML)
   */
  [HttpPut("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public Task<IActionResult> Update(
    int id,
    [FromBody] Invoice entity
  )
  {
    throw new NotImplementedException();
    // TODO
  }

  /* 
    DELETE: api/invoices/id
   */
  [HttpDelete("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public Task<IActionResult> Delete(int id)
  {
    throw new NotImplementedException();
    // TODO
  }

}
