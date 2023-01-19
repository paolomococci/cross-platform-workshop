using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.Common.DataContext.Data;

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

  public async Task<Product?> CreateAsync(Product product)
  {
    EntityEntry<Product> entry = await this.dummyRosterContext.Products.AddAsync(product);
    int changesWereSavedAsynchronously = await this.dummyRosterContext.SaveChangesAsync();
    if (changesWereSavedAsynchronously == 1)
    {
      if (keyValuesCache is null)
      {
        return product;
      }
      return keyValuesCache.AddOrUpdate(
        product.Id,
        product,
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
    Product? product = this.dummyRosterContext.Products.Find(id);
    if (product is null)
    {
      return null;
    }
    this.dummyRosterContext.Products.Remove(product);
    int changesSaved = await this.dummyRosterContext.SaveChangesAsync();
    if (changesSaved == 1)
    {
      if (keyValuesCache is null)
      {
        return null;
      }
      return keyValuesCache.TryRemove(id, out product);
    }
    else
    {
      return null;
    }
  }

  public Task<IEnumerable<Product>> RetrieveAllAsync()
  {
    return Task.FromResult(
      keyValuesCache is null ? Enumerable.Empty<Product>() : keyValuesCache.Values
    );
  }

  public Task<Product?> RetrieveAsync(int id)
  {
    if (keyValuesCache is null) return null!;
    keyValuesCache.TryGetValue(id, out Product? product);
    return Task.FromResult(product);
  }

  public async Task<Product?> UpdateAsync(int id, Product product)
  {
    this.dummyRosterContext.Products.Update(product);
    int changesSaved = await this.dummyRosterContext.SaveChangesAsync();
    if (changesSaved == 1)
    {
      return this.UpdateCache(id, product);
    }
    return null;
  }

  private Product UpdateCache(int id, Product product)
  {
    Product? alreadyRegistered;
    if (keyValuesCache is not null)
    {
      if (keyValuesCache.TryGetValue(id, out alreadyRegistered))
      {
        if (keyValuesCache.TryUpdate(id, product, alreadyRegistered))
        {
          return product;
        }
      }
    }
    return null!;
  }
}
