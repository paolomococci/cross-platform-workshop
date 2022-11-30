using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories;

public interface ICategoryRepository {
  Task<Category> CreateAsync(Category category);
  Task<Category> RetrieveAsync(int id);
}
