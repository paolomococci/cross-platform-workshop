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

}
