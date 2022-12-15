using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CredentialController : ControllerBase, ICredentialController
{

  private readonly ICredentialRepository repository;

  public CredentialController(
    ICredentialRepository repo
  )
  {
    this.repository = repo;
  }

  /* 
    POST: api/credentials
    BODY: Credential (JSON, XML)
   */
  [HttpPost]
  [ProducesResponseType(
    201,
    Type = typeof(Credential)
  )]
  [ProducesResponseType(400)]
  public Task<IActionResult> Create([FromBody] Credential entity)
  {
    throw new NotImplementedException();
  }

  /* 
    GET: api/credentials/[id]
   */
  [HttpGet("{id}", Name = nameof(ReadCredential))]
  [ProducesResponseType(
    200,
    Type = typeof(Credential)
  )]
  [ProducesResponseType(404)]
  public Task<IActionResult> ReadCredential(int id)
  {
    throw new NotImplementedException();
  }

  /* 
    GET: api/credentials
    GET: api/credentials/?email=[email]
   */
  [HttpGet]
  [ProducesResponseType(
    200,
    Type = typeof(IEnumerable<Credential>)
  )]
  public Task<IEnumerable<Credential>> ReadAll(string? email)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> Update(int id, [FromBody] Credential entity)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> PartialUpdate(int id, [FromBody] Credential entity)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> Delete(int id)
  {
    throw new NotImplementedException();
  }
}
