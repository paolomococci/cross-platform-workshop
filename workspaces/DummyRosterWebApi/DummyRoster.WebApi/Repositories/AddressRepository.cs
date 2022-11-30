using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.Common.DataContext.Data;

namespace DummyRoster.WebApi.Repositories;

public class AddressRepository : IAddressRepository
{
  private static ConcurrentDictionary<int, Address>? keyValuesCache;
  private DummyRosterContext dummyRosterContext;

  public AddressRepository(
    DummyRosterContext dummyRosterContext
  ) {
    this.dummyRosterContext = dummyRosterContext;
    if (keyValuesCache is null)
    {
      keyValuesCache = new ConcurrentDictionary<int, Address>(
        this.dummyRosterContext.Addresses.ToDictionary(
          entity => entity.Id
        )
      );
    }
  }
  
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
