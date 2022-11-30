using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories;

public class AddressRepository : IAddressRepository
{
  public Task<Address?> CreateAsync(Address address)
  {
    throw new NotImplementedException();
  }

  public Task<bool?> DeleteAsync(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<Address>> RetrieveAllAsync()
  {
    throw new NotImplementedException();
  }

  public Task<Address?> RetrieveAsync(int id)
  {
    throw new NotImplementedException();
  }

  public Task<Address?> UpdateAsync(int id, Address address)
  {
    throw new NotImplementedException();
  }
}
