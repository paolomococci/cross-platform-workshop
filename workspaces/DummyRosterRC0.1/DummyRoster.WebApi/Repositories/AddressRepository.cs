using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Repositories;

public class AddressRepository : IAddressRepository
{
  public Task<Address?> CreateAsync(Address entity)
  {
    throw new NotImplementedException();
  }

  public Task<bool?> DeleteAsync(int id)
  {
    throw new NotImplementedException();
  }

  public Task<Address?> PartialUpdateAsync(int id, Address entity)
  {
    throw new NotImplementedException();
  }

  public Task<Address?> Retrieve(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<Address>> RetrieveAll()
  {
    throw new NotImplementedException();
  }

  public Task<Address?> UpdateAsync(int id, Address entity)
  {
    throw new NotImplementedException();
  }
}
