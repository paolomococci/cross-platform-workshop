using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using DummyRoster.Common.EntityModel.Data;
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

  public async Task<Credential?> CreateAsync(Credential entity)
  {
    EntityEntry<Credential> entry = await this.dummyRosterContext.Credentials.AddAsync(entity);
    int changesWereSavedAsynchronously = await this.dummyRosterContext.SaveChangesAsync();
    if (changesWereSavedAsynchronously == 1)
    {
      if (keyValuesCache is null)
      {
        return entity;
      }
      return keyValuesCache.AddOrUpdate(
        entity.Id,
        entity,
        UpdateCache
      );
    }
    else
    {
      return null;
    }
  }

  public Task<Credential?> Retrieve(int id)
  {
    if (keyValuesCache is null) return null!;
    keyValuesCache.TryGetValue(id, out Credential? entity);
    return Task.FromResult(entity);
  }

  public Task<IEnumerable<Credential>> RetrieveAll()
  {
    return Task.FromResult(
      keyValuesCache is null ? Enumerable.Empty<Credential>() : keyValuesCache.Values
    );
  }

  public async Task<Credential?> UpdateAsync(int id, Credential entity)
  {
    this.dummyRosterContext.Credentials.Update(entity);
    int changesSaved = await this.dummyRosterContext.SaveChangesAsync();
    if (changesSaved == 1)
    {
      return this.UpdateCache(id, entity);
    }
    return null;
  }

  public async Task<Credential?> PartialUpdateAsync(int id, Credential entity)
  {
    if (keyValuesCache is null) return null!;
    keyValuesCache.TryGetValue(id, out Credential? registered);
    if (registered != null)
    {
      if (entity.Email != null) registered.Email = entity.Email;
      if (entity.Phone != null) registered.Phone = entity.Phone;
      if (entity.Fax != null) registered.Fax = entity.Fax;
      this.dummyRosterContext.Credentials.Update(registered);
      int changesSaved = await this.dummyRosterContext.SaveChangesAsync();
      if (changesSaved == 1)
      {
        return this.UpdateCache(id, registered);
      }
    }
    return null;
  }

  public async Task<bool?> DeleteAsync(int id)
  {
    Credential? entity = this.dummyRosterContext.Credentials.Find(id);
    if (entity is null)
    {
      return null;
    }
    this.dummyRosterContext.Credentials.Remove(entity);
    int changesSaved = await this.dummyRosterContext.SaveChangesAsync();
    if (changesSaved == 1)
    {
      if (keyValuesCache is null)
      {
        return null;
      }
      return keyValuesCache.TryRemove(id, out entity);
    }
    else
    {
      return null;
    }
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
