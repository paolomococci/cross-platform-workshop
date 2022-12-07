using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DummyRoster.WebApi.Controllers;

public class CarrierController : ControllerBase, ICarrierController
{
  public Task<IActionResult> Create([FromBody] Carrier entity)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> Get(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<Carrier>> GetAll(string? country)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> Update(int id, [FromBody] Carrier entity)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> PartialUpdate(int id, [FromBody] Carrier entity)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> Delete(int id)
  {
    throw new NotImplementedException();
  }
}
