using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase, ICustomerController
{

  private readonly ICustomerRepository repository;

  public CustomerController(
    ICustomerRepository repo
  )
  {
    this.repository = repo;
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
  }

  /* 
    GET: api/customers/[id]
   */
  [HttpGet("{id}", Name = nameof(ReadCustomer))]
  [ProducesResponseType(
    200,
    Type = typeof(Customer)
  )]
  [ProducesResponseType(404)]
  public Task<IActionResult> ReadCustomer(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<Customer>> ReadAll(string? name)
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
