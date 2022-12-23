using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Controllers;

public class CarrierController : ControllerBase, ICarrierController
{

  private readonly ICarrierRepository repository;

  public CarrierController(
    ICarrierRepository repo
  )
  {
    this.repository = repo;
  }
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
