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
  )
  {
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

  public async Task<bool?> DeleteAsync(int id)
  {
    Address? address = this.dummyRosterContext.Addresses.Find(id);
    if (address is null)
    {
      return null;
    }
    this.dummyRosterContext.Addresses.Remove(address);
    int changesSaved = await this.dummyRosterContext.SaveChangesAsync();
    if (changesSaved == 1)
    {
      if (keyValuesCache is null)
      {
        return null;
      }
      return keyValuesCache.TryRemove(id, out address);
    }
    else
    {
      return null;
    }
  }

  public Task<IEnumerable<Address>> RetrieveAllAsync()
  {
    return Task.FromResult(
      keyValuesCache is null ? Enumerable.Empty<Address>() : keyValuesCache.Values
    );
  }

  public Task<Address?> RetrieveAsync(int id)
  {
    if (keyValuesCache is null) return null!;
    keyValuesCache.TryGetValue(id, out Address? address);
    return Task.FromResult(address);
  }

  public async Task<Address?> UpdateAsync(int id, Address address)
  {
    this.dummyRosterContext.Addresses.Update(address);
    int changesSaved = await this.dummyRosterContext.SaveChangesAsync();
    if (changesSaved == 1)
    {
      return this.UpdateCache(id, address);
    }
    return null;
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
