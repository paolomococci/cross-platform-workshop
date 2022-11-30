using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories;

public interface IFormRepository {
  Task<Form> CreateAsync(Form form);
  Task<Form> RetrieveAsync(int id);
}
