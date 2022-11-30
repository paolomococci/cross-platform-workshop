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
  ) {
    this.dummyRosterContext = dummyRosterContext;
  }
  
  public Task<Invoice?> CreateAsync(Invoice invoice)
  {
    throw new NotImplementedException();
  }

  public Task<bool?> DeleteAsync(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<Invoice>> RetrieveAllAsync()
  {
    throw new NotImplementedException();
  }

  public Task<Invoice?> RetrieveAsync(int id)
  {
    throw new NotImplementedException();
  }

  public Task<Invoice?> UpdateAsync(int id, Invoice invoice)
  {
    throw new NotImplementedException();
  }
}
