using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using DummyRoster.Common.EntityModel.Data;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Repositories;

public class CategoryRepository : ICategoryRepository
{
  private static ConcurrentDictionary<int, Category>? keyValuesCache;
  private DummyRosterContext dummyRosterContext;

  public CategoryRepository(
    DummyRosterContext dummyRosterContext
  )
  {
    this.dummyRosterContext = dummyRosterContext;
    if (keyValuesCache is null)
    {
      keyValuesCache = new ConcurrentDictionary<int, Category>(
        this.dummyRosterContext.Categories.ToDictionary(
          entity => entity.Id
        )
      );
    }
  }

  public async Task<Category?> CreateAsync(Category entity)
  {
    EntityEntry<Category> entry = await this.dummyRosterContext.Categories.AddAsync(entity);
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

  public Task<Category?> Retrieve(int id)
  {
    if (keyValuesCache is null) return null!;
    keyValuesCache.TryGetValue(id, out Category? entity);
    return Task.FromResult(entity);
  }

  public Task<IEnumerable<Category>> RetrieveAll()
  {
    return Task.FromResult(
      keyValuesCache is null ? Enumerable.Empty<Category>() : keyValuesCache.Values
    );
  }

  public async Task<Category?> UpdateAsync(int id, Category entity)
  {
    this.dummyRosterContext.Categories.Update(entity);
    int changesSaved = await this.dummyRosterContext.SaveChangesAsync();
    if (changesSaved == 1)
    {
      return this.UpdateCache(id, entity);
    }
    return null;
  }

  public async Task<Category?> PartialUpdateAsync(int id, Category entity)
  {
    if (keyValuesCache is null) return null!;
    keyValuesCache.TryGetValue(id, out Category? registered);
    if (registered != null)
    {
      if (entity.Name != null) registered.Name = entity.Name;
      if (entity.Description != null) registered.Description = entity.Description;
      if (entity.Picture != null) registered.Picture = entity.Picture;
      this.dummyRosterContext.Categories.Update(registered);
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
    Category? entity = this.dummyRosterContext.Categories.Find(id);
    if (entity is null)
    {
      return null;
    }
    this.dummyRosterContext.Categories.Remove(entity);
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

  private Category UpdateCache(
    int id, 
    Category entity
  )
  {
    Category? alreadyRegistered;
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
