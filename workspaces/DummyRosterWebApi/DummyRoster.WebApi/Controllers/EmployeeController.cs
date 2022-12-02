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
    GET: api/employees/?country=[country]
   */
  [HttpGet]
  [ProducesResponseType(
    200, 
    Type = typeof(IEnumerable<Employee>)
  )]
  public Task<IEnumerable<Employee>> GetEmployees(string? country)
  {
    throw new NotImplementedException();
    // TODO
  }

}
