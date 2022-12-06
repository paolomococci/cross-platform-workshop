using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.Common.DataContext.Data;

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
          entity => entity.FormId
        )
      );
    }
  }

  public async Task<Invoice?> CreateAsync(Invoice invoice)
  {
    EntityEntry<Invoice> entry = await this.dummyRosterContext.Invoices.AddAsync(invoice);
    int changesWereSavedAsynchronously = await this.dummyRosterContext.SaveChangesAsync();
    if (changesWereSavedAsynchronously == 1)
    {
      if (keyValuesCache is null)
      {
        return invoice;
      }
      return keyValuesCache.AddOrUpdate(
        invoice.FormId,
        invoice,
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
    Invoice? invoice = this.dummyRosterContext.Invoices.Find(id);
    if (invoice is null)
    {
      return null;
    }
    this.dummyRosterContext.Invoices.Remove(invoice);
    int changesSaved = await this.dummyRosterContext.SaveChangesAsync();
    if (changesSaved == 1)
    {
      if (keyValuesCache is null)
      {
        return null;
      }
      return keyValuesCache.TryRemove(id, out invoice);
    }
    else
    {
      return null;
    }
  }

  public Task<IEnumerable<Invoice>> RetrieveAllAsync()
  {
    return Task.FromResult(
      keyValuesCache is null ? Enumerable.Empty<Invoice>() : keyValuesCache.Values
    );
  }

  public Task<Invoice?> RetrieveAsync(int id)
  {
    if (keyValuesCache is null) return null!;
    keyValuesCache.TryGetValue(id, out Invoice? invoice);
    return Task.FromResult(invoice);
  }

  public async Task<Invoice?> UpdateAsync(int id, Invoice invoice)
  {
    this.dummyRosterContext.Invoices.Update(invoice);
    int changesSaved = await this.dummyRosterContext.SaveChangesAsync();
    if (changesSaved == 1)
    {
      return this.UpdateCache(id, invoice);
    }
    return null;
  }

  private Invoice UpdateCache(int id, Invoice invoice)
  {
    Invoice? alreadyRegistered;
    if (keyValuesCache is not null)
    {
      if (keyValuesCache.TryGetValue(id, out alreadyRegistered))
      {
        if (keyValuesCache.TryUpdate(id, invoice, alreadyRegistered))
        {
          return invoice;
        }
      }
    }
    return null!;
  }
}
