using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories.Interfaces;

public interface IAddressRepository
{
  Task<Address?> CreateAsync(Address entity);
  Task<Address?> RetrieveAsync(int id);
  Task<IEnumerable<Address>> RetrieveAllAsync();
  Task<Address?> UpdateAsync(
    int id,
    Address entity
  );
  Task<Address?> PartialUpdateAsync(
    int id,
    Address entity
  );
  Task<bool?> DeleteAsync(int id);
}
