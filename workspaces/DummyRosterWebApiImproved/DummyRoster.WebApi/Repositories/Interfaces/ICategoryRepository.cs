using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories.Interfaces;

public interface ICategoryRepository
{
  Task<Category?> CreateAsync(Category entity);
  Task<Category?> RetrieveAsync(int id);
}
