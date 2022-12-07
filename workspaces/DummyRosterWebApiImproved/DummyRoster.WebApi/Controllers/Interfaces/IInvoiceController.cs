using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Controllers.Interfaces;

public interface IInvoiceController
{
  public Task<IActionResult> Create([FromBody] Invoice entity);
  public Task<IActionResult> Get(int id);
  public Task<IEnumerable<Invoice>> GetAll(string? country);
  public Task<IActionResult> Update(int id, [FromBody] Invoice entity);
  public Task<IActionResult> PartialUpdate(int id, [FromBody] Invoice entity);
  public Task<IActionResult> Delete(int id);
}

