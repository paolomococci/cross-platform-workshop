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

  /* 
    GET: api/forms/[id]
   */
  [HttpGet("{id}", Name = nameof(GetForm))]
  [ProducesResponseType(
    200, 
    Type = typeof(Form)
  )]
  [ProducesResponseType(404)]
  public Task<IActionResult> GetForm(int id)
  {
    throw new NotImplementedException();
    // TODO
  }

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
    // TODO
  }

  /* 
    PUT: api/forms/id
    BODY: Form (JSON, XML)
   */
  [HttpPut("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public Task<IActionResult> Update(
    int id,
    [FromBody] Form entity
  )
  {
    throw new NotImplementedException();
    // TODO
  }

}
