using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories.Interfaces;

public interface ICategoryRepository
{
  Task<Category?> CreateAsync(Category entity);
  Task<Category?> Retrieve(int id);
  Task<IEnumerable<Category>> RetrieveAll();
  Task<Category?> UpdateAsync(
    int id,
    Category entity
  );
  Task<Category?> PartialUpdateAsync(
    int id,
    Category entity
  );
  Task<bool?> DeleteAsync(int id);
}
