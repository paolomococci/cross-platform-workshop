using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Repositories;

public class CredentialRepository : ICredentialRepository
{
  public Task<Credential?> CreateAsync(Credential entity)
  {
    throw new NotImplementedException();
  }

  public Task<bool?> DeleteAsync(int id)
  {
    throw new NotImplementedException();
  }

  public Task<Credential?> PartialUpdateAsync(int id, Credential entity)
  {
    throw new NotImplementedException();
  }

  public Task<Credential?> Retrieve(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<Credential>> RetrieveAll()
  {
    throw new NotImplementedException();
  }

  public Task<Credential?> UpdateAsync(int id, Credential entity)
  {
    throw new NotImplementedException();
  }
}
