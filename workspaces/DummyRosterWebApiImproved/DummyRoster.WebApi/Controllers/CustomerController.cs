using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DummyRoster.WebApi.Controllers;

[Route("api/customers")]
[ApiController]
public class CustomerController : ControllerBase, ICustomerController
{

  /* 
    POST: api/customers
    BODY: Customer (JSON, XML)
   */
  [HttpPost]
  [ProducesResponseType(
    201,
    Type = typeof(Customer)
  )]
  [ProducesResponseType(400)]
  public Task<IActionResult> Create([FromBody] Customer entity)
  {
    throw new NotImplementedException();
  }

  /* 
    GET: api/customers/[id]
   */
  [HttpGet("{id}", Name = nameof(Get))]
  [ProducesResponseType(
    200,
    Type = typeof(Customer)
  )]
  [ProducesResponseType(404)]
  public Task<IActionResult> Get(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<Customer>> GetAll(string? country)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> Update(int id, [FromBody] Customer entity)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> PartialUpdate(int id, [FromBody] Customer entity)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> Delete(int id)
  {
    throw new NotImplementedException();
  }
}
