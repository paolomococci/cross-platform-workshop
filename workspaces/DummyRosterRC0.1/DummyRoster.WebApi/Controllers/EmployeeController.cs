using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;

namespace DummyRoster.WebApi.Controllers;

public class EmployeeController : ControllerBase, IEmployeeController
{
  public Task<IActionResult> Create([FromBody] Employee entity)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> Delete(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> PartialUpdate(int id, [FromBody] Employee entity)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<Employee>> ReadAll(string? name)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> ReadEmployee(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> Update(int id, [FromBody] Employee entity)
  {
    throw new NotImplementedException();
  }
}
