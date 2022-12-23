using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Controllers;

public class FormController : ControllerBase, IFormController
{

  private readonly IFormRepository repository;

  public FormController(
    IFormRepository repo
  )
  {
    this.repository = repo;
  }
  public Task<IActionResult> Create([FromBody] Form entity)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> Delete(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> PartialUpdate(int id, [FromBody] Form entity)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<Form>> ReadAll(int? customerId)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> ReadForm(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> Update(int id, [FromBody] Form entity)
  {
    throw new NotImplementedException();
  }
}
