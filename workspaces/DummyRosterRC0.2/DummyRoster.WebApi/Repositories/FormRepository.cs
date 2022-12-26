using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using DummyRoster.Common.EntityModel.Data;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Repositories;

public class FormRepository : IFormRepository
{
  private static ConcurrentDictionary<int, Form>? keyValuesCache;
  private DummyRosterContext dummyRosterContext;

  public FormRepository(
    DummyRosterContext dummyRosterContext
  )
  {
    this.dummyRosterContext = dummyRosterContext;
    if (keyValuesCache is null)
    {
      keyValuesCache = new ConcurrentDictionary<int, Form>(
        this.dummyRosterContext.Forms.ToDictionary(
          entity => entity.Id
        )
      );
    }
  }

  public async Task<Form?> CreateAsync(Form entity)
  {
    EntityEntry<Form> entry = await this.dummyRosterContext.Forms.AddAsync(entity);
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

  public Task<Form?> Retrieve(int id)
  {
    if (keyValuesCache is null) return null!;
    keyValuesCache.TryGetValue(id, out Form? entity);
    return Task.FromResult(entity);
  }

  public Task<IEnumerable<Form>> RetrieveAll()
  {
    return Task.FromResult(
      keyValuesCache is null ? Enumerable.Empty<Form>() : keyValuesCache.Values
    );
  }

  public async Task<Form?> UpdateAsync(int id, Form entity)
  {
    this.dummyRosterContext.Forms.Update(entity);
    int changesSaved = await this.dummyRosterContext.SaveChangesAsync();
    if (changesSaved == 1)
    {
      return this.UpdateCache(id, entity);
    }
    return null;
  }

  public async Task<Form?> PartialUpdateAsync(int id, Form entity)
  {
    if (keyValuesCache is null) return null!;
    keyValuesCache.TryGetValue(id, out Form? registered);
    if (registered != null)
    {
      if (entity.Description != null) registered.Description = entity.Description;
      if (entity.CustomerId != null) registered.CustomerId = entity.CustomerId;
      if (entity.CarrierId != null) registered.CarrierId = entity.CarrierId;
      if (entity.EmployeeId != null) registered.EmployeeId = entity.EmployeeId;
      if (entity.FormDate != null) registered.FormDate = entity.FormDate;
      if (entity.RequiredDate != null) registered.RequiredDate = entity.RequiredDate;
      if (entity.PromisedDate != null) registered.PromisedDate = entity.PromisedDate;
      if (entity.ShippingCost != null) registered.ShippingCost = entity.ShippingCost;
      this.dummyRosterContext.Forms.Update(registered);
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
    Form? entity = this.dummyRosterContext.Forms.Find(id);
    if (entity is null)
    {
      return null;
    }
    this.dummyRosterContext.Forms.Remove(entity);
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

  private Form UpdateCache(
    int id, 
    Form entity
  )
  {
    Form? alreadyRegistered;
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
