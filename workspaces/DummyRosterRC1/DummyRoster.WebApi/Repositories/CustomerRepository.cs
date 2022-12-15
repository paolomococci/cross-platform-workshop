using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using DummyRoster.Common.EntityModel.Data;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Repositories;

public class CustomerRepository : ICustomerRepository
{
  private static ConcurrentDictionary<int, Customer>? keyValuesCache;
  private DummyRosterContext dummyRosterContext;

  public CustomerRepository(
    DummyRosterContext dummyRosterContext
  )
  {
    this.dummyRosterContext = dummyRosterContext;
    if (keyValuesCache is null)
    {
      keyValuesCache = new ConcurrentDictionary<int, Customer>(
        this.dummyRosterContext.Customers.ToDictionary(
          entity => entity.Id
        )
      );
    }
  }

  public async Task<Customer?> CreateAsync(Customer entity)
  {
    EntityEntry<Customer> entry = await this.dummyRosterContext.Customers.AddAsync(entity);
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

  public Task<Customer?> Retrieve(int id)
  {
    if (keyValuesCache is null) return null!;
    keyValuesCache.TryGetValue(id, out Customer? entity);
    return Task.FromResult(entity);
  }

  public Task<IEnumerable<Customer>> RetrieveAll()
  {
    return Task.FromResult(
      keyValuesCache is null ? Enumerable.Empty<Customer>() : keyValuesCache.Values
    );
  }

  public async Task<Customer?> UpdateAsync(int id, Customer entity)
  {
    this.dummyRosterContext.Customers.Update(entity);
    int changesSaved = await this.dummyRosterContext.SaveChangesAsync();
    if (changesSaved == 1)
    {
      return this.UpdateCache(id, entity);
    }
    return null;
  }

  public async Task<Customer?> PartialUpdateAsync(int id, Customer entity)
  {
    if (keyValuesCache is null) return null!;
    keyValuesCache.TryGetValue(id, out Customer? registered);
    if (registered != null)
    {
      if (entity.Name != null) registered.Name = entity.Name;
      if (entity.FoundationDate != null) registered.FoundationDate = entity.FoundationDate;
      if (entity.Description != null) registered.Description = entity.Description;
      if (entity.Picture != null) registered.Picture = entity.Picture;
      if (entity.Belonging != null) registered.Belonging = entity.Belonging;
      if (entity.Contact != null) registered.Contact = entity.Contact;
      if (entity.Loc != null) registered.Loc = entity.Loc;
      if (entity.Ref != null) registered.Ref = entity.Ref;
      this.dummyRosterContext.Customers.Update(registered);
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
    Customer? entity = this.dummyRosterContext.Customers.Find(id);
    if (entity is null)
    {
      return null;
    }
    this.dummyRosterContext.Customers.Remove(entity);
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

  private Customer UpdateCache(
    int id, 
    Customer entity
  )
  {
    Customer? alreadyRegistered;
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
