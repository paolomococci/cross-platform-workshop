using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Controllers.Interfaces;

public interface ICustomerController
{
  public Task<IActionResult> Create([FromBody] Customer entity);
  public Task<IActionResult> ReadCustomer(int id);
  public Task<IEnumerable<Customer>> ReadAll(string? name);
  public Task<IActionResult> Update(int id, [FromBody] Customer entity);
  public Task<IActionResult> PartialUpdate(int id, [FromBody] Customer entity);
  public Task<IActionResult> Delete(int id);
}
