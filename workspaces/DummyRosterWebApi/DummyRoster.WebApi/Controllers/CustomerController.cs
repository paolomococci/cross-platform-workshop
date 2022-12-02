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
    GET: api/customers
    GET: api/customers/?name=[name]
   */
  [HttpGet]
  [ProducesResponseType(
    200, 
    Type = typeof(IEnumerable<Customer>)
  )]
  public Task<IEnumerable<Customer>> GetCustomers(string? name)
  {
    throw new NotImplementedException();
    // TODO
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
  public Task<IActionResult> GetCustomer(int id)
  {
    throw new NotImplementedException();
    // TODO
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
  public Task<IActionResult> Create([FromBody] Customer entity)
  {
    throw new NotImplementedException();
    // TODO
  }

}
