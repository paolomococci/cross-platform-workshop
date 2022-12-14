using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
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

  public Task<Category?> CreateAsync(Category entity)
  {
    throw new NotImplementedException();
  }

  public Task<bool?> DeleteAsync(int id)
  {
    throw new NotImplementedException();
  }

  public Task<Category?> PartialUpdateAsync(int id, Category entity)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<Category>> RetrieveAllAsync()
  {
    throw new NotImplementedException();
  }

  public Task<Category?> RetrieveAsync(int id)
  {
    throw new NotImplementedException();
  }

  public Task<Category?> UpdateAsync(int id, Category entity)
  {
    throw new NotImplementedException();
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
