using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DummyRoster.WebApi.Controllers;

public class CarrierController : ICarrierController
{
  public Task<IActionResult> Create([FromBody] Carrier entity)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> Delete(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> PartialUpdate(int id, [FromBody] Carrier entity)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<Carrier>> ReadAll(string? name)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> ReadCarrier(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> Update(int id, [FromBody] Carrier entity)
  {
    throw new NotImplementedException();
  }
}
