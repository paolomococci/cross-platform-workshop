using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories.Interfaces;

public interface IAddressRepository
{
  Task<Address?> CreateAsync(Address entity);
  Task<Address?> Retrieve(int id);
  Task<IEnumerable<Address>> RetrieveAll();
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
