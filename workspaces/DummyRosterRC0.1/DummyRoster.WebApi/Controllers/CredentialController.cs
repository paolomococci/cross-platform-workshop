using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Controllers;

public class CredentialController : ControllerBase, ICredentialController
{

  private readonly ICredentialRepository repository;

  public CredentialController(
    ICredentialRepository repo
  )
  {
    this.repository = repo;
  }
  public Task<IActionResult> Create([FromBody] Credential entity)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> Delete(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> PartialUpdate(int id, [FromBody] Credential entity)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<Credential>> ReadAll(string? email)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> ReadCredential(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IActionResult> Update(int id, [FromBody] Credential entity)
  {
    throw new NotImplementedException();
  }
}
