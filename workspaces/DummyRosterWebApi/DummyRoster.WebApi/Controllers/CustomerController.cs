using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories;

namespace DummyRoster.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{

  private readonly ICustomerRepository iCustomerRepository;

  public CustomerController(
    ICustomerRepository iRepo
  )
  {
    this.iCustomerRepository = iRepo;
  }

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
  public async Task<IActionResult?> Create([FromBody] Customer entity)
  {
    if (entity == null)
    {
      return BadRequest();
    }
    return null;
  }

  /* 
    GET: api/customers/[id]
   */
  [HttpGet("{id}", Name = nameof(GetCustomer))]
  [ProducesResponseType(
    200,
    Type = typeof(Customer)
  )]
  [ProducesResponseType(404)]
  public async Task<IActionResult> GetCustomer(int id)
  {
    throw new NotImplementedException();
    // TODO
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
  public async Task<IEnumerable<Customer>> GetCustomers(string? name)
  {
    throw new NotImplementedException();
    // TODO
  }

  /* 
    PUT: api/customers/id
    BODY: Customer (JSON, XML)
   */
  [HttpPut("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public async Task<IActionResult> Update(
    int id,
    [FromBody] Customer entity
  )
  {
    throw new NotImplementedException();
    // TODO
  }

  /* 
    DELETE: api/customers/id
   */
  [HttpDelete("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public async Task<IActionResult> Delete(int id)
  {
    throw new NotImplementedException();
    // TODO
  }

}
