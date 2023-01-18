using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using DummyRoster.Common.EntityModel.Data;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories.Interfaces;

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

  public async Task<Address?> CreateAsync(Address entity)
  {
    EntityEntry<Address> entry = await this.dummyRosterContext.Addresses.AddAsync(entity);
    int changesWereSavedAsynchronously = await this.dummyRosterContext.SaveChangesAsync();
    if (changesWereSavedAsynchronously == 1)
    {
      if (keyValuesCache is null)
      {
        return entity;
      }
      return keyValuesCache.AddOrUpdate(
        entity.Id,
        entity,
        UpdateCache
      );
    }
    else
    {
      return null;
    }
  }

  public Task<Address?> Retrieve(int id)
  {
    if (keyValuesCache is null) return null!;
    keyValuesCache.TryGetValue(id, out Address? entity);
    return Task.FromResult(entity);
  }

  public Task<IEnumerable<Address>> RetrieveAll()
  {
    return Task.FromResult(
      keyValuesCache is null ? Enumerable.Empty<Address>() : keyValuesCache.Values
    );
  }

  public async Task<Address?> UpdateAsync(int id, Address entity)
  {
    this.dummyRosterContext.Addresses.Update(entity);
    int changesSaved = await this.dummyRosterContext.SaveChangesAsync();
    if (changesSaved == 1)
    {
      return this.UpdateCache(id, entity);
    }
    return null;
  }

  public async Task<Address?> PartialUpdateAsync(int id, Address entity)
  {
    if (keyValuesCache is null) return null!;
    keyValuesCache.TryGetValue(id, out Address? registered);
    if (registered != null)
    {
      if (entity.Name != null) registered.Name = entity.Name;
      if (entity.Civic != null) registered.Civic = entity.Civic;
      if (entity.City != null) registered.City = entity.City;
      if (entity.District != null) registered.District = entity.District;
      if (entity.Postcode != null) registered.Postcode = entity.Postcode;
      if (entity.Country != null) registered.Country = entity.Country;
      this.dummyRosterContext.Addresses.Update(registered);
      int changesSaved = await this.dummyRosterContext.SaveChangesAsync();
      if (changesSaved == 1)
      {
        return this.UpdateCache(id, registered);
      }
    }
    return null;
  }

  public async Task<bool?> DeleteAsync(int id)
  {
    Address? entity = this.dummyRosterContext.Addresses.Find(id);
    if (entity is null)
    {
      return null;
    }
    this.dummyRosterContext.Addresses.Remove(entity);
    int changesSaved = await this.dummyRosterContext.SaveChangesAsync();
    if (changesSaved == 1)
    {
      if (keyValuesCache is null)
      {
        return null;
      }
      return keyValuesCache.TryRemove(id, out entity);
    }
    else
    {
      return null;
    }
  }

  private Address UpdateCache(
    int id,
    Address entity
  )
  {
    Address? alreadyRegistered;
    if (keyValuesCache is not null)
    {
      if (keyValuesCache.TryGetValue(id, out alreadyRegistered))
      {
        if (keyValuesCache.TryUpdate(id, entity, alreadyRegistered))
        {
          return entity;
        }
      }
    }
    return null!;
  }
}
