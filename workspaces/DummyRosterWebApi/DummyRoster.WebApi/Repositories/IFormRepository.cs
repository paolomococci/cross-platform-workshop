using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories;

public interface IFormRepository
{
  Task<Form?> CreateAsync(Form form);
  Task<Form?> RetrieveAsync(int id);
  Task<IEnumerable<Form>> RetrieveAllAsync();
  Task<Form?> UpdateAsync(
    int id,
    Form form
  );
  Task<bool?> DeleteAsync(int id);
}
