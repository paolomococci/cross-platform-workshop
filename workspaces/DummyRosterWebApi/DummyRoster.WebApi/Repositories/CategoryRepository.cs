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
  ) {
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
    throw new NotImplementedException();
  }

  public Task<bool?> DeleteAsync(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<Category>> RetrieveAllAsync()
  {
    throw new NotImplementedException();
  }

  public Task<Category?> RetrieveAsync(int id)
  {
    if (keyValuesCache is null) return null!;
    keyValuesCache.TryGetValue(id, out Category? category);
    return Task.FromResult(category);
  }

  public Task<Category?> UpdateAsync(int id, Category category)
  {
    throw new NotImplementedException();
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
