using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DummyRoster.WebApi.Controllers;

[Route("api/forms")]
[ApiController]
public class FormController : ControllerBase, IFormController
{

  /* 
    POST: api/forms
    BODY: Form (JSON, XML)
   */
  [HttpPost]
  [ProducesResponseType(
    201,
    Type = typeof(Form)
  )]
  [ProducesResponseType(400)]
  public Task<IActionResult> Create([FromBody] Form entity)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> Get(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<Form>> GetAll(string? country)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> Update(int id, [FromBody] Form entity)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> PartialUpdate(int id, [FromBody] Form entity)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> Delete(int id)
  {
    throw new NotImplementedException();
  }
}
