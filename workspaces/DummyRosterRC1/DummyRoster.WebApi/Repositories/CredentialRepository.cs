using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Repositories;

public class CredentialRepository : ICredentialRepository
{
  private static ConcurrentDictionary<int, Credential>? keyValuesCache;
  private DummyRosterContext dummyRosterContext;

  public CredentialRepository(
    DummyRosterContext dummyRosterContext
  )
  {
    this.dummyRosterContext = dummyRosterContext;
    if (keyValuesCache is null)
    {
      keyValuesCache = new ConcurrentDictionary<int, Credential>(
        this.dummyRosterContext.Credentials.ToDictionary(
          entity => entity.Id
        )
      );
    }
  }

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

  public Task<IEnumerable<Credential>> RetrieveAllAsync()
  {
    throw new NotImplementedException();
  }

  public Task<Credential?> RetrieveAsync(int id)
  {
    throw new NotImplementedException();
  }

  public Task<Credential?> UpdateAsync(int id, Credential entity)
  {
    throw new NotImplementedException();
  }

  private Credential UpdateCache(
    int id, 
    Credential entity
  )
  {
    Credential? alreadyRegistered;
    if (keyValuesCache is not null)
    {
      if (keyValuesCache.TryGetValue(id, out alreadyRegistered))
      {
        if (keyValuesCache.TryUpdate(id, entity, alreadyRegistered))
        {
          return entity;
        }
      }
    }
    return null!;
  }
}
