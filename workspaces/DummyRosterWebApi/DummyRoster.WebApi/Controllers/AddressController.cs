using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories;

namespace DummyRoster.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AddressController : ControllerBase
{

  private readonly IAddressRepository iAddressRepository;

  public AddressController(
    IAddressRepository iRepo
  )
  {
    this.iAddressRepository = iRepo;
  }

  /* 
    GET: api/addresses
    GET: api/addresses/?country=[country]
   */
  [HttpGet]
  [ProducesResponseType(
    200, 
    Type = typeof(IEnumerable<Address>)
  )]
  public Task<IEnumerable<Address>> GetAddresses(string? country)
  {
    throw new NotImplementedException();
    // TODO
  }

  /* 
    GET: api/addresses/[id]
   */
  [HttpGet("{id}", Name = nameof(GetAddress))]
  [ProducesResponseType(
    200, 
    Type = typeof(Address)
  )]
  [ProducesResponseType(404)]
  public Task<IActionResult> GetAddress(int id)
  {
    throw new NotImplementedException();
    // TODO
  }

}
