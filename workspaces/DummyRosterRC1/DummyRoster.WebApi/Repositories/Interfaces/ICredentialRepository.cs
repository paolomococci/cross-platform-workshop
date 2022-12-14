using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories.Interfaces;

public interface ICredentialRepository
{
  Task<Credential?> CreateAsync(Credential entity);
  Task<Credential?> RetrieveAsync(int id);
  Task<IEnumerable<Credential>> RetrieveAllAsync();
  Task<Credential?> UpdateAsync(
    int id,
    Credential entity
  );
  Task<Credential?> PartialUpdateAsync(
    int id,
    Credential entity
  );
  Task<bool?> DeleteAsync(int id);
}
