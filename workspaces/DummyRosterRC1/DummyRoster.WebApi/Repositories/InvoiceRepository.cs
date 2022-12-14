using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Repositories;

public class InvoiceRepository : IInvoiceRepository
{
  private static ConcurrentDictionary<int, Invoice>? keyValuesCache;
  private DummyRosterContext dummyRosterContext;

  public InvoiceRepository(
    DummyRosterContext dummyRosterContext
  )
  {
    this.dummyRosterContext = dummyRosterContext;
    if (keyValuesCache is null)
    {
      keyValuesCache = new ConcurrentDictionary<int, Invoice>(
        this.dummyRosterContext.Invoices.ToDictionary(
          entity => entity.Id
        )
      );
    }
  }

  public async Task<Invoice?> CreateAsync(Invoice entity)
  {
    EntityEntry<Invoice> entry = await this.dummyRosterContext.Invoices.AddAsync(entity);
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

  public Task<Invoice?> RetrieveAsync(int id)
  {
    if (keyValuesCache is null) return null!;
    keyValuesCache.TryGetValue(id, out Invoice? entity);
    return Task.FromResult(entity);
  }

  public Task<IEnumerable<Invoice>> RetrieveAllAsync()
  {
    throw new NotImplementedException();
  }

  public async Task<Invoice?> UpdateAsync(int id, Invoice entity)
  {
    throw new NotImplementedException();
  }

  public async Task<Invoice?> PartialUpdateAsync(int id, Invoice entity)
  {
    throw new NotImplementedException();
  }

  public async Task<bool?> DeleteAsync(int id)
  {
    throw new NotImplementedException();
  }

  private Invoice UpdateCache(
    int id, 
    Invoice entity
  )
  {
    Invoice? alreadyRegistered;
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
