using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories.Interfaces;

public interface IFormRepository
{
  Task<Form?> CreateAsync(Form entity);
}
