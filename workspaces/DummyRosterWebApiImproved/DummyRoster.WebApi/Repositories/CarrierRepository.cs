using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.Common.DataContext.Data;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Repositories;

public class CarrierRepository : ICarrierRepository
{
  private static ConcurrentDictionary<int, Carrier>? keyValuesCache;
  private DummyRosterContext dummyRosterContext;

  public CarrierRepository(
    DummyRosterContext dummyRosterContext
  )
  {
    this.dummyRosterContext = dummyRosterContext;
    if (keyValuesCache is null)
    {
      keyValuesCache = new ConcurrentDictionary<int, Carrier>(
        this.dummyRosterContext.Carriers.ToDictionary(
          entity => entity.Id
        )
      );
    }
  }

  public async Task<Carrier?> CreateAsync(Carrier entity)
  {
    EntityEntry<Carrier> entry = await this.dummyRosterContext.Carriers.AddAsync(entity);
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

  public Task<Carrier?> RetrieveAsync(int id)
  {
    if (keyValuesCache is null) return null!;
    keyValuesCache.TryGetValue(id, out Carrier? entity);
    return Task.FromResult(entity);
  }

  public Task<IEnumerable<Carrier>> RetrieveAllAsync()
  {
    throw new NotImplementedException();
  }

  public Task<Carrier?> UpdateAsync(int id, Carrier entity)
  {
    throw new NotImplementedException();
  }

  public Task<Carrier?> PartialUpdateAsync(int id, Carrier entity)
  {
    throw new NotImplementedException();
  }

  public Task<bool?> DeleteAsync(int id)
  {
    throw new NotImplementedException();
  }

  private Carrier UpdateCache(
    int id, 
    Carrier entity
  )
  {
    Carrier? alreadyRegistered;
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
