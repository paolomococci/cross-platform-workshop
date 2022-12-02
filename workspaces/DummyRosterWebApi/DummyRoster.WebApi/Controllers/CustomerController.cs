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
    GET: api/customers/?country=[country]
   */
  [HttpGet]
  [ProducesResponseType(
    200, 
    Type = typeof(IEnumerable<Customer>)
  )]
  public Task<IEnumerable<Customer>> GetCustomers(string? country)
  {
    throw new NotImplementedException();
    // TODO
  }

}
