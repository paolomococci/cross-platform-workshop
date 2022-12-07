using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Controllers.Interfaces;

public interface IAddressController
{
  public Task<IActionResult> Create([FromBody] Address entity);
  public Task<IActionResult> ReadAddress(int id);
  public Task<IEnumerable<Address>> ReadAll(string? country);
  public Task<IActionResult> Update(int id, [FromBody] Address entity);
  public Task<IActionResult> PartialUpdate(int id, [FromBody] Address entity);
  public Task<IActionResult> Delete(int id);
}
