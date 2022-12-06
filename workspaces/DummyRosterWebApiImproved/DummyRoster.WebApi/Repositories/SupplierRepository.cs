using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.Common.DataContext.Data;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Repositories;

public class SupplierRepository : ISupplierRepository
{
  private static ConcurrentDictionary<int, Supplier>? keyValuesCache;
  private DummyRosterContext dummyRosterContext;

  public SupplierRepository(
    DummyRosterContext dummyRosterContext
  )
  {
    this.dummyRosterContext = dummyRosterContext;
    if (keyValuesCache is null)
    {
      keyValuesCache = new ConcurrentDictionary<int, Supplier>(
        this.dummyRosterContext.Suppliers.ToDictionary(
          entity => entity.Id
        )
      );
    }
  }

  public async Task<Supplier?> CreateAsync(Supplier entity)
  {
    EntityEntry<Supplier> entry = await this.dummyRosterContext.Suppliers.AddAsync(entity);
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

  public Task<Supplier?> RetrieveAsync(int id)
  {
    if (keyValuesCache is null) return null!;
    keyValuesCache.TryGetValue(id, out Supplier? entity);
    return Task.FromResult(entity);
  }

  public Task<IEnumerable<Supplier>> RetrieveAllAsync()
  {
    return Task.FromResult(
      keyValuesCache is null ? Enumerable.Empty<Supplier>() : keyValuesCache.Values
    );
  }

  public Task<Supplier?> UpdateAsync(int id, Supplier entity)
  {
    throw new NotImplementedException();
  }

  public Task<Supplier?> PartialUpdateAsync(int id, Supplier entity)
  {
    throw new NotImplementedException();
  }

  public Task<bool?> DeleteAsync(int id)
  {
    throw new NotImplementedException();
  }

  private Supplier UpdateCache(
    int id, 
    Supplier entity
  )
  {
    Supplier? alreadyRegistered;
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
