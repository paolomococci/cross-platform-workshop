using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FormController : ControllerBase, IFormController
{

  private readonly IFormRepository repository;

  public FormController(
    IFormRepository repo
  )
  {
    this.repository = repo;
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
  }

  /* 
    GET: api/forms/[id]
   */
  [HttpGet("{id}", Name = nameof(ReadForm))]
  [ProducesResponseType(
    200,
    Type = typeof(Form)
  )]
  [ProducesResponseType(404)]
  public Task<IActionResult> ReadForm(int id)
  {
    throw new NotImplementedException();
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
  public Task<IEnumerable<Form>> ReadAll(int? customerId)
  {
    throw new NotImplementedException();
  }

  /* 
    PUT: api/forms/id
    BODY: Form (JSON, XML)
   */
  [HttpPut("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public Task<IActionResult> Update(int id, [FromBody] Form entity)
  {
    throw new NotImplementedException();
  }

  /* 
    PATCH: api/forms/id
    BODY: Form (JSON, XML)
   */
  [HttpPatch("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public Task<IActionResult> PartialUpdate(int id, [FromBody] Form entity)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> Delete(int id)
  {
    throw new NotImplementedException();
  }
}
