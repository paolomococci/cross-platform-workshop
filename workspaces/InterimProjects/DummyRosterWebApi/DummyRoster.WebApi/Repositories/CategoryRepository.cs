using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.Common.DataContext.Data;

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

  public async Task<Category?> CreateAsync(Category category)
  {
    EntityEntry<Category> entry = await this.dummyRosterContext.Categories.AddAsync(category);
    int changesWereSavedAsynchronously = await this.dummyRosterContext.SaveChangesAsync();
    if (changesWereSavedAsynchronously == 1)
    {
      if (keyValuesCache is null)
      {
        return category;
      }
      return keyValuesCache.AddOrUpdate(
        category.Id,
        category,
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
    Category? category = this.dummyRosterContext.Categories.Find(id);
    if (category is null)
    {
      return null;
    }
    this.dummyRosterContext.Categories.Remove(category);
    int changesSaved = await this.dummyRosterContext.SaveChangesAsync();
    if (changesSaved == 1)
    {
      if (keyValuesCache is null)
      {
        return null;
      }
      return keyValuesCache.TryRemove(id, out category);
    }
    else
    {
      return null;
    }
  }

  public Task<IEnumerable<Category>> RetrieveAllAsync()
  {
    return Task.FromResult(
      keyValuesCache is null ? Enumerable.Empty<Category>() : keyValuesCache.Values
    );
  }

  public Task<Category?> RetrieveAsync(int id)
  {
    if (keyValuesCache is null) return null!;
    keyValuesCache.TryGetValue(id, out Category? category);
    return Task.FromResult(category);
  }

  public async Task<Category?> UpdateAsync(int id, Category category)
  {
    this.dummyRosterContext.Categories.Update(category);
    int changesSaved = await this.dummyRosterContext.SaveChangesAsync();
    if (changesSaved == 1)
    {
      return this.UpdateCache(id, category);
    }
    return null;
  }

  private Category UpdateCache(int id, Category category)
  {
    Category? alreadyRegistered;
    if (keyValuesCache is not null)
    {
      if (keyValuesCache.TryGetValue(id, out alreadyRegistered))
      {
        if (keyValuesCache.TryUpdate(id, category, alreadyRegistered))
        {
          return category;
        }
      }
    }
    return null!;
  }
}
