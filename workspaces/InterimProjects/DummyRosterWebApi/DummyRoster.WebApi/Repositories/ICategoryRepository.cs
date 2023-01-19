using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories;

public interface ICategoryRepository
{
  Task<Category?> CreateAsync(Category category);
  Task<Category?> RetrieveAsync(int id);
  Task<IEnumerable<Category>> RetrieveAllAsync();
  Task<Category?> UpdateAsync(
    int id,
    Category category
  );
  Task<bool?> DeleteAsync(int id);
}
