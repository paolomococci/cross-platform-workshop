using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories;

public class SupplierRepository : ISupplierRepository
{
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
    throw new NotImplementedException();
  }

  public Task<Supplier?> UpdateAsync(int id, Supplier supplier)
  {
    throw new NotImplementedException();
  }
}
