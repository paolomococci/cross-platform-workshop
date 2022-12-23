using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories.Interfaces;

public interface IFormRepository
{
  Task<Form?> CreateAsync(Form entity);
  Task<Form?> Retrieve(int id);
  Task<IEnumerable<Form>> RetrieveAll();
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
