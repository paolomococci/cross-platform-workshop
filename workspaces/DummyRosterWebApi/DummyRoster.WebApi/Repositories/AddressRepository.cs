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
  
  public async Task<Address?> CreateAsync(Address address)
  {
    EntityEntry<Address> entry = await this.dummyRosterContext.Addresses.AddAsync(address);
    int changesWereSavedAsynchronously = await this.dummyRosterContext.SaveChangesAsync();
    if (changesWereSavedAsynchronously == 1)
    {
      if (keyValuesCache is null)
      {
        return address;
      }
      return keyValuesCache.AddOrUpdate(
        address.Id,
        address,
        UpdateCache
      );
    }
    else
    {
      return null;
    }
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

  private Address UpdateCache(int id, Address address)
  {
    Address? alreadyRegistered;
    if (keyValuesCache is not null)
    {
      if (keyValuesCache.TryGetValue(id, out alreadyRegistered))
      {
        if (keyValuesCache.TryUpdate(id, address, alreadyRegistered))
        {
          return address;
        }
      }
    }
    return null!;
  }
}
