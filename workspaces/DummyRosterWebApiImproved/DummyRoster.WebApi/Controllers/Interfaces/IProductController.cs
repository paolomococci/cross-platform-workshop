using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Controllers.Interfaces;

public interface IProductController
{
  public Task<IActionResult> Create([FromBody] Product entity);
  public Task<IActionResult> Get(int id);
  public Task<IEnumerable<Product>> GetAll(string? country);
  public Task<IActionResult> Update(int id, [FromBody] Product entity);
  public Task<IActionResult> PartialUpdate(int id, [FromBody] Product entity);
  public Task<IActionResult> Delete(int id);
}

