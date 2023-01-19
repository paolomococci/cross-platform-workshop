using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.Common.DataContext.Data;

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

  public async Task<Carrier?> CreateAsync(Carrier carrier)
  {
    EntityEntry<Carrier> entry = await this.dummyRosterContext.Carriers.AddAsync(carrier);
    int changesWereSavedAsynchronously = await this.dummyRosterContext.SaveChangesAsync();
    if (changesWereSavedAsynchronously == 1)
    {
      if (keyValuesCache is null)
      {
        return carrier;
      }
      return keyValuesCache.AddOrUpdate(
        carrier.Id,
        carrier,
        UpdateCache
      );
    }
    else
    {
      return null;
    }
  }

  public async Task<bool?> DeleteAsync(int id)
  {
    Carrier? carrier = this.dummyRosterContext.Carriers.Find(id);
    if (carrier is null)
    {
      return null;
    }
    this.dummyRosterContext.Carriers.Remove(carrier);
    int changesSaved = await this.dummyRosterContext.SaveChangesAsync();
    if (changesSaved == 1)
    {
      if (keyValuesCache is null)
      {
        return null;
      }
      return keyValuesCache.TryRemove(id, out carrier);
    }
    else
    {
      return null;
    }
  }

  public Task<IEnumerable<Carrier>> RetrieveAllAsync()
  {
    return Task.FromResult(
      keyValuesCache is null ? Enumerable.Empty<Carrier>() : keyValuesCache.Values
    );
  }

  public Task<Carrier?> RetrieveAsync(int id)
  {
    if (keyValuesCache is null) return null!;
    keyValuesCache.TryGetValue(id, out Carrier? carrier);
    return Task.FromResult(carrier);
  }

  public async Task<Carrier?> UpdateAsync(int id, Carrier carrier)
  {
    this.dummyRosterContext.Carriers.Update(carrier);
    int changesSaved = await this.dummyRosterContext.SaveChangesAsync();
    if (changesSaved == 1)
    {
      return this.UpdateCache(id, carrier);
    }
    return null;
  }

  private Carrier UpdateCache(int id, Carrier carrier)
  {
    Carrier? alreadyRegistered;
    if (keyValuesCache is not null)
    {
      if (keyValuesCache.TryGetValue(id, out alreadyRegistered))
      {
        if (keyValuesCache.TryUpdate(id, carrier, alreadyRegistered))
        {
          return carrier;
        }
      }
    }
    return null!;
  }
}
