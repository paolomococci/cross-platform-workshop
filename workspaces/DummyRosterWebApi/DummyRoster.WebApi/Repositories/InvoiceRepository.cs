using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories;

public class InvoiceRepository : IInvoiceRepository
{
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
