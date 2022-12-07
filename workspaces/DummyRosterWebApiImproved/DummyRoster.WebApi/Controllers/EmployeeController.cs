using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DummyRoster.WebApi.Controllers;

[Route("api/employees")]
[ApiController]
public class EmployeeController : ControllerBase, IEmployeeController
{

  /* 
    POST: api/employees
    BODY: Employee (JSON, XML)
   */
  [HttpPost]
  [ProducesResponseType(
    201,
    Type = typeof(Employee)
  )]
  [ProducesResponseType(400)]
  public Task<IActionResult> Create([FromBody] Employee entity)
  {
    throw new NotImplementedException();
  }

  /* 
    GET: api/employees/[id]
   */
  [HttpGet("{id}", Name = nameof(Get))]
  [ProducesResponseType(
    200,
    Type = typeof(Employee)
  )]
  [ProducesResponseType(404)]
  public Task<IActionResult> Get(int id)
  {
    throw new NotImplementedException();
  }

  /* 
    GET: api/employees
    GET: api/employees/?name=[name]
   */
  [HttpGet]
  [ProducesResponseType(
    200,
    Type = typeof(IEnumerable<Employee>)
  )]
  public Task<IEnumerable<Employee>> GetAll(string? name)
  {
    throw new NotImplementedException();
  }

  /* 
    PUT: api/employees/id
    BODY: Employee (JSON, XML)
   */
  [HttpPut("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public Task<IActionResult> Update(int id, [FromBody] Employee entity)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> PartialUpdate(int id, [FromBody] Employee entity)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> Delete(int id)
  {
    throw new NotImplementedException();
  }
}
