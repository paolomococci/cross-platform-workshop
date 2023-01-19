using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories.Interfaces;

public interface IFormRepository
{
  Task<Form?> CreateAsync(Form entity);
  Task<Form?> RetrieveAsync(int id);
  Task<IEnumerable<Form>> RetrieveAllAsync();
  Task<Form?> UpdateAsync(
    int id,
    Form entity
  );
  Task<Form?> PartialUpdateAsync(
    int id,
    Form entity
  );
  Task<bool?> DeleteAsync(int id);
}
