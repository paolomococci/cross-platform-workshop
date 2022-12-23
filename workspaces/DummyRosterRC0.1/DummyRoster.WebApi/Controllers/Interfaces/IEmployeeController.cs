using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Controllers.Interfaces;

public interface IEmployeeController
{
  public Task<IActionResult> Create([FromBody] Employee entity);
  public Task<IActionResult> ReadEmployee(int id);
  public Task<IEnumerable<Employee>> ReadAll(string? name);
  public Task<IActionResult> Update(int id, [FromBody] Employee entity);
  public Task<IActionResult> PartialUpdate(int id, [FromBody] Employee entity);
  public Task<IActionResult> Delete(int id);
}
