using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Controllers.Interfaces;

public interface ICredentialController
{
  public Task<IActionResult> Create([FromBody] Credential entity);
  public Task<IActionResult> ReadCredential(int id);
  public Task<IEnumerable<Credential>> ReadAll(string? email);
  public Task<IActionResult> Update(int id, [FromBody] Credential entity);
  public Task<IActionResult> PartialUpdate(int id, [FromBody] Credential entity);
  public Task<IActionResult> Delete(int id);
}
