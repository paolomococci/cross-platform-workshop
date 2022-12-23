using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DummyRoster.WebApi.Controllers;

public class AddressController : ControllerBase, IAddressController
{
  public Task<IActionResult> Create([FromBody] Address entity)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> Delete(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> PartialUpdate(int id, [FromBody] Address entity)
  {
    throw new NotImplementedException();
  }

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
}
