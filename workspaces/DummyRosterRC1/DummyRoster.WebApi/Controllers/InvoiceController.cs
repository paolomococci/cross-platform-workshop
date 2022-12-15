using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
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
  public Task<IActionResult> Create([FromBody] Invoice entity)
  {
    throw new NotImplementedException();
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
  public Task<IActionResult> ReadInvoice(int id)
  {
    throw new NotImplementedException();
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
  public Task<IEnumerable<Invoice>> ReadAll(int? formId)
  {
    throw new NotImplementedException();
  }

  /* 
    PUT: api/invoices/id
    BODY: Invoice (JSON, XML)
   */
  [HttpPut("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public Task<IActionResult> Update(int id, [FromBody] Invoice entity)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> PartialUpdate(int id, [FromBody] Invoice entity)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> Delete(int id)
  {
    throw new NotImplementedException();
  }
}
