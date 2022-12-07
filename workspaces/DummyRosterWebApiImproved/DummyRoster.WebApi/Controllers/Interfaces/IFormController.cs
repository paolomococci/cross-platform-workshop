using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Controllers.Interfaces;

public interface IFormController
{
  public Task<IActionResult> Create([FromBody] Form entity);
  public Task<IActionResult> ReadForm(int id);
  public Task<IEnumerable<Form>> ReadAll(int? customerId);
  public Task<IActionResult> Update(int id, [FromBody] Form entity);
  public Task<IActionResult> PartialUpdate(int id, [FromBody] Form entity);
  public Task<IActionResult> Delete(int id);
}
