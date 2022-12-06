using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.Common.DataContext.Data;
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

  public async Task<Product?> CreateAsync(Product entity)
  {
    EntityEntry<Product> entry = await this.dummyRosterContext.Products.AddAsync(entity);
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

  public Task<Product?> RetrieveAsync(int id)
  {
    if (keyValuesCache is null) return null!;
    keyValuesCache.TryGetValue(id, out Product? entity);
    return Task.FromResult(entity);
  }

  public Task<IEnumerable<Product>> RetrieveAllAsync()
  {
    return Task.FromResult(
      keyValuesCache is null ? Enumerable.Empty<Product>() : keyValuesCache.Values
    );
  }

  public async Task<Product?> UpdateAsync(
    int id, 
    Product entity
  )
  {
    this.dummyRosterContext.Products.Update(entity);
    int changesSaved = await this.dummyRosterContext.SaveChangesAsync();
    if (changesSaved == 1)
    {
      return this.UpdateCache(id, entity);
    }
    return null;
  }

  public Task<Product?> PartialUpdateAsync(int id, Product entity)
  {
    throw new NotImplementedException();
  }

  public async Task<bool?> DeleteAsync(int id)
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
