using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase, IEmployeeController
{

  private readonly IEmployeeRepository repository;

  public EmployeeController(
    IEmployeeRepository repo
  )
  {
    this.repository = repo;
  }

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
  [HttpGet("{id}", Name = nameof(ReadEmployee))]
  [ProducesResponseType(
    200,
    Type = typeof(Employee)
  )]
  [ProducesResponseType(404)]
  public Task<IActionResult> ReadEmployee(int id)
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
  public Task<IEnumerable<Employee>> ReadAll(string? name)
  {
    throw new NotImplementedException();
  }

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
