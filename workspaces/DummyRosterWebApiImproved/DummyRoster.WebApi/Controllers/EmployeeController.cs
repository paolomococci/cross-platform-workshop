using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

  public Task<IActionResult> Get(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<Employee>> GetAll(string? country)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> PartialUpdate(int id, [FromBody] Employee entity)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> Update(int id, [FromBody] Employee entity)
  {
    throw new NotImplementedException();
  }
}
