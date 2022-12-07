using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DummyRoster.WebApi.Controllers;

[Route("api/invoices")]
[ApiController]
public class InvoiceController : ControllerBase, IInvoiceController
{
  public Task<IActionResult> Create([FromBody] Invoice entity)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> Get(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<Invoice>> GetAll(string? country)
  {
    throw new NotImplementedException();
  }

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
