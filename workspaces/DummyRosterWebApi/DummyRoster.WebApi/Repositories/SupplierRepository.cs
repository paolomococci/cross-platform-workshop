using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.Common.DataContext.Data;

namespace DummyRoster.WebApi.Repositories;

public class SupplierRepository : ISupplierRepository
{
  private static ConcurrentDictionary<int, Supplier>? keyValuesCache;
  private DummyRosterContext dummyRosterContext;

  public SupplierRepository(
    DummyRosterContext dummyRosterContext
  ) {
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
  
  public Task<Supplier?> CreateAsync(Supplier supplier)
  {
    throw new NotImplementedException();
  }

  public Task<bool?> DeleteAsync(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<Supplier>> RetrieveAllAsync()
  {
    throw new NotImplementedException();
  }

  public Task<Supplier?> RetrieveAsync(int id)
  {
    if (keyValuesCache is null) return null!;
    keyValuesCache.TryGetValue(id, out Supplier? supplier);
    return Task.FromResult(supplier);
  }

  public Task<Supplier?> UpdateAsync(int id, Supplier supplier)
  {
    throw new NotImplementedException();
  }

  private Supplier UpdateCache(int id, Supplier supplier)
  {
    Supplier? alreadyRegistered;
    if (keyValuesCache is not null)
    {
      if (keyValuesCache.TryGetValue(id, out alreadyRegistered))
      {
        if (keyValuesCache.TryUpdate(id, supplier, alreadyRegistered))
        {
          return supplier;
        }
      }
    }
    return null!;
  }
}
