using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories;

namespace DummyRoster.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FormController : ControllerBase
{

  private readonly IFormRepository iFormRepository;

  public FormController(
    IFormRepository iRepo
  )
  {
    this.iFormRepository = iRepo;
  }

  /* 
    GET: api/forms
    GET: api/forms/?customerId=[customerId]
   */
  [HttpGet]
  [ProducesResponseType(
    200, 
    Type = typeof(IEnumerable<Form>)
  )]
  public Task<IEnumerable<Form>> GetForms(string? customerId)
  {
    throw new NotImplementedException();
    // TODO
  }

}
