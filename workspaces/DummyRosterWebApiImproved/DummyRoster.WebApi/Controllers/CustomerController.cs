using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using DummyRoster.WebApi.Repositories.Interfaces;

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

  /* 
    GET: api/customers
    GET: api/customers/?name=[name]
   */
  [HttpGet]
  [ProducesResponseType(
    200,
    Type = typeof(IEnumerable<Customer>)
  )]
  public Task<IEnumerable<Customer>> GetAll(string? name)
  {
    throw new NotImplementedException();
  }

  /* 
    PUT: api/customers/id
    BODY: Customer (JSON, XML)
   */
  [HttpPut("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public Task<IActionResult> Update(int id, [FromBody] Customer entity)
  {
    throw new NotImplementedException();
  }

  /* 
    PATCH: api/customers/id
    BODY: Customer (JSON, XML)
   */
  [HttpPatch("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public Task<IActionResult> PartialUpdate(int id, [FromBody] Customer entity)
  {
    throw new NotImplementedException();
  }

  /* 
    DELETE: api/customers/id
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
