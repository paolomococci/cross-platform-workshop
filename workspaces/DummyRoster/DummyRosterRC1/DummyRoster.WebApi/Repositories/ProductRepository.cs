using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using DummyRoster.Common.EntityModel.Data;
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

  public Task<Product?> Retrieve(int id)
  {
    if (keyValuesCache is null) return null!;
    keyValuesCache.TryGetValue(id, out Product? entity);
    return Task.FromResult(entity);
  }

  public Task<IEnumerable<Product>> RetrieveAll()
  {
    return Task.FromResult(
      keyValuesCache is null ? Enumerable.Empty<Product>() : keyValuesCache.Values
    );
  }

  public async Task<Product?> UpdateAsync(int id, Product entity)
  {
    this.dummyRosterContext.Products.Update(entity);
    int changesSaved = await this.dummyRosterContext.SaveChangesAsync();
    if (changesSaved == 1)
    {
      return this.UpdateCache(id, entity);
    }
    return null;
  }

  public async Task<Product?> PartialUpdateAsync(int id, Product entity)
  {
    if (keyValuesCache is null) return null!;
    keyValuesCache.TryGetValue(id, out Product? registered);
    if (registered != null)
    {
      if (entity.Name != null) registered.Name = entity.Name;
      if (entity.Description != null) registered.Description = entity.Description;
      if (entity.Picture != null) registered.Picture = entity.Picture;
      if (entity.CategoryId != null) registered.CategoryId = entity.CategoryId;
      if (entity.SupplierId != null) registered.SupplierId = entity.SupplierId;
      if (entity.QuantityPerUnit != null) registered.QuantityPerUnit = entity.QuantityPerUnit;
      if (entity.UnitPrice != null) registered.UnitPrice = entity.UnitPrice;
      if (entity.UnitsInStock != null) registered.UnitsInStock = entity.UnitsInStock;
      if (entity.UnitsOnOrder != null) registered.UnitsOnOrder = entity.UnitsOnOrder;
      if (entity.ReorderLevel != null) registered.ReorderLevel = entity.ReorderLevel;
      if (entity.Discontinued != null) registered.Discontinued = entity.Discontinued;
      this.dummyRosterContext.Products.Update(registered);
      int changesSaved = await this.dummyRosterContext.SaveChangesAsync();
      if (changesSaved == 1)
      {
        return this.UpdateCache(id, registered);
      }
    }
    return null;
  }

  public async Task<bool?> DeleteAsync(int id)
  {
    Product? entity = this.dummyRosterContext.Products.Find(id);
    if (entity is null)
    {
      return null;
    }
    this.dummyRosterContext.Products.Remove(entity);
    int changesSaved = await this.dummyRosterContext.SaveChangesAsync();
    if (changesSaved == 1)
    {
      if (keyValuesCache is null)
      {
        return null;
      }
      return keyValuesCache.TryRemove(id, out entity);
    }
    else
    {
      return null;
    }
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
