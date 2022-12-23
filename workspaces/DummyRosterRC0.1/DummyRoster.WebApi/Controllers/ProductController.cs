using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;

namespace DummyRoster.WebApi.Controllers;

public class ProductController : ControllerBase, IProductController
{
  public Task<IActionResult> Create([FromBody] Product entity)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> Delete(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> PartialUpdate(int id, [FromBody] Product entity)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<Product>> ReadAll(string? name)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> ReadProduct(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> Update(int id, [FromBody] Product entity)
  {
    throw new NotImplementedException();
  }
}
