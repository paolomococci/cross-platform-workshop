using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Repositories;

public class CategoryRepository : ICategoryRepository
{
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

  public Task<Category?> Retrieve(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<Category>> RetrieveAll()
  {
    throw new NotImplementedException();
  }

  public Task<Category?> UpdateAsync(int id, Category entity)
  {
    throw new NotImplementedException();
  }
}
