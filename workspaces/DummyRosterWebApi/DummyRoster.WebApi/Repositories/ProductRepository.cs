using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.Common.DataContext.Data;

namespace DummyRoster.WebApi.Repositories;

public class ProductRepository : IProductRepository
{
  private static ConcurrentDictionary<int, Product>? keyValuesCache;
  private DummyRosterContext dummyRosterContext;
  public Task<Product?> CreateAsync(Product product)
  {
    throw new NotImplementedException();
  }

  public Task<bool?> DeleteAsync(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<Product>> RetrieveAllAsync()
  {
    throw new NotImplementedException();
  }

  public Task<Product?> RetrieveAsync(int id)
  {
    throw new NotImplementedException();
  }

  public Task<Product?> UpdateAsync(int id, Product product)
  {
    throw new NotImplementedException();
  }
}
