using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories;

public class CategoryRepository : ICategoryRepository
{
  public Task<Category?> CreateAsync(Category category)
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
    throw new NotImplementedException();
  }

  public Task<Category?> UpdateAsync(int id, Category category)
  {
    throw new NotImplementedException();
  }
}
