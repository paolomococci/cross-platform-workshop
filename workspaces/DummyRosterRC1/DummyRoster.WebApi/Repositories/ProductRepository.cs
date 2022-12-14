using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Repositories;

public class ProductRepository : IProductRepository
{
  private static ConcurrentDictionary<int, Product>? keyValuesCache;
  private DummyRosterContext dummyRosterContext;

  public ProductRepository(
    DummyRosterContext dummyRosterContext
  )
  {
    this.dummyRosterContext = dummyRosterContext;
    if (keyValuesCache is null)
    {
      keyValuesCache = new ConcurrentDictionary<int, Product>(
        this.dummyRosterContext.Products.ToDictionary(
          entity => entity.Id
        )
      );
    }
  }

  public Task<Product?> CreateAsync(Product entity)
  {
    throw new NotImplementedException();
  }

  public Task<bool?> DeleteAsync(int id)
  {
    throw new NotImplementedException();
  }

  public Task<Product?> PartialUpdateAsync(int id, Product entity)
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

  public Task<Product?> UpdateAsync(int id, Product entity)
  {
    throw new NotImplementedException();
  }

  private Product UpdateCache(
    int id, 
    Product entity
  )
  {
    Product? alreadyRegistered;
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
