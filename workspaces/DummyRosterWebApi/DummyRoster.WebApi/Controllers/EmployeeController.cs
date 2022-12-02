using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories;

namespace DummyRoster.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{

  private readonly IEmployeeRepository iEmployeeRepository;

  public EmployeeController(
    IEmployeeRepository iRepo
  )
  {
    this.iEmployeeRepository = iRepo;
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
  public Task<IEnumerable<Employee>> GetEmployees(string? name)
  {
    throw new NotImplementedException();
    // TODO
  }

  /* 
    GET: api/employees/[id]
   */
  [HttpGet("{id}", Name = nameof(GetEmployee))]
  [ProducesResponseType(
    200, 
    Type = typeof(Employee)
  )]
  [ProducesResponseType(404)]
  public Task<IActionResult> GetEmployee(int id)
  {
    throw new NotImplementedException();
    // TODO
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
    // TODO
  }

}
