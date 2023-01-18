using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using DummyRoster.Common.EntityModel.Data;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Repositories;

public class SupplierRepository : ISupplierRepository
{
  private static ConcurrentDictionary<int, Supplier>? keyValuesCache;
  private DummyRosterContext dummyRosterContext;

  public SupplierRepository(
    DummyRosterContext dummyRosterContext
  )
  {
    this.dummyRosterContext = dummyRosterContext;
    if (keyValuesCache is null)
    {
      keyValuesCache = new ConcurrentDictionary<int, Supplier>(
        this.dummyRosterContext.Suppliers.ToDictionary(
          entity => entity.Id
        )
      );
    }
  }

  public async Task<Supplier?> CreateAsync(Supplier entity)
  {
    EntityEntry<Supplier> entry = await this.dummyRosterContext.Suppliers.AddAsync(entity);
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

  public Task<Supplier?> Retrieve(int id)
  {
    if (keyValuesCache is null) return null!;
    keyValuesCache.TryGetValue(id, out Supplier? entity);
    return Task.FromResult(entity);
  }

  public Task<IEnumerable<Supplier>> RetrieveAll()
  {
    return Task.FromResult(
      keyValuesCache is null ? Enumerable.Empty<Supplier>() : keyValuesCache.Values
    );
  }

  public async Task<Supplier?> UpdateAsync(int id, Supplier entity)
  {
    this.dummyRosterContext.Suppliers.Update(entity);
    int changesSaved = await this.dummyRosterContext.SaveChangesAsync();
    if (changesSaved == 1)
    {
      return this.UpdateCache(id, entity);
    }
    return null;
  }

  public async Task<Supplier?> PartialUpdateAsync(int id, Supplier entity)
  {
    if (keyValuesCache is null) return null!;
    keyValuesCache.TryGetValue(id, out Supplier? registered);
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
      this.dummyRosterContext.Suppliers.Update(registered);
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
    Supplier? entity = this.dummyRosterContext.Suppliers.Find(id);
    if (entity is null)
    {
      return null;
    }
    this.dummyRosterContext.Suppliers.Remove(entity);
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

  private Supplier UpdateCache(
    int id, 
    Supplier entity
  )
  {
    Supplier? alreadyRegistered;
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
