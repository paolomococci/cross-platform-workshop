using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Controllers;

[ApiController]
[Route("api/employees")]
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
  [HttpGet("{id}", Name = nameof(Get))]
  [ProducesResponseType(
    200,
    Type = typeof(Employee)
  )]
  [ProducesResponseType(404)]
  public async Task<IActionResult> Get(int id)
  {
    Employee? managedEntity = await this.repository.RetrieveAsync(id);
    if (managedEntity == null)
    {
      return NotFound();
    }
    return Ok(managedEntity);
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
  public async Task<IEnumerable<Employee>> GetAll(string? name)
  {
    if (string.IsNullOrWhiteSpace(name))
    {
      return await this.repository.RetrieveAllAsync();
    }
    return (await this.repository.RetrieveAllAsync()).Where(
      entity => entity.Name == name
    );
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

  /* 
    PATCH: api/employees/id
    BODY: Employee (JSON, XML)
   */
  [HttpPatch("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public Task<IActionResult> PartialUpdate(int id, [FromBody] Employee entity)
  {
    throw new NotImplementedException();
  }

  /* 
    DELETE: api/employees/id
   */
  [HttpDelete("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public Task<IActionResult> Delete(int id)
  {
    throw new NotImplementedException();
  }
}
