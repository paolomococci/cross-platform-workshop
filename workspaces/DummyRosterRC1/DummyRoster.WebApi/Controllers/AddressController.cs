using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase, IAddressController
{

  private readonly IAddressRepository repository;

  public AddressController(
    IAddressRepository repo
  )
  {
    this.repository = repo;
  }

  /* 
    POST: api/addresses
    BODY: Address (JSON, XML)
   */
  [HttpPost]
  [ProducesResponseType(
    201,
    Type = typeof(Address)
  )]
  [ProducesResponseType(400)]
  public Task<IActionResult> Create([FromBody] Address entity)
  {
    throw new NotImplementedException();
  }

  /* 
    GET: api/addresses/[id]
   */
  [HttpGet("{id}", Name = nameof(ReadAddress))]
  [ProducesResponseType(
    200,
    Type = typeof(Address)
  )]
  [ProducesResponseType(404)]
  public Task<IActionResult> ReadAddress(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<Address>> ReadAll(string? country)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> Update(int id, [FromBody] Address entity)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> PartialUpdate(int id, [FromBody] Address entity)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> Delete(int id)
  {
    throw new NotImplementedException();
  }
}
