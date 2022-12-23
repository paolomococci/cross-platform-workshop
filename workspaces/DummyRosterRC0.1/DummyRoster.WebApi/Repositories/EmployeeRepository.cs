using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using DummyRoster.Common.EntityModel.Data;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
  private static ConcurrentDictionary<int, Employee>? keyValuesCache;
  private DummyRosterContext dummyRosterContext;

  public EmployeeRepository(
    DummyRosterContext dummyRosterContext
  )
  {
    this.dummyRosterContext = dummyRosterContext;
    if (keyValuesCache is null)
    {
      keyValuesCache = new ConcurrentDictionary<int, Employee>(
        this.dummyRosterContext.Employees.ToDictionary(
          entity => entity.Id
        )
      );
    }
  }

  public async Task<Employee?> CreateAsync(Employee entity)
  {
    EntityEntry<Employee> entry = await this.dummyRosterContext.Employees.AddAsync(entity);
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

  public Task<Employee?> Retrieve(int id)
  {
    if (keyValuesCache is null) return null!;
    keyValuesCache.TryGetValue(id, out Employee? entity);
    return Task.FromResult(entity);
  }

  public Task<IEnumerable<Employee>> RetrieveAll()
  {
    return Task.FromResult(
      keyValuesCache is null ? Enumerable.Empty<Employee>() : keyValuesCache.Values
    );
  }

  public async Task<Employee?> UpdateAsync(int id, Employee entity)
  {
    this.dummyRosterContext.Employees.Update(entity);
    int changesSaved = await this.dummyRosterContext.SaveChangesAsync();
    if (changesSaved == 1)
    {
      return this.UpdateCache(id, entity);
    }
    return null;
  }

  public async Task<Employee?> PartialUpdateAsync(int id, Employee entity)
  {
    if (keyValuesCache is null) return null!;
    keyValuesCache.TryGetValue(id, out Employee? registered);
    if (registered != null)
    {
      if (entity.Name != null) registered.Name = entity.Name;
      if (entity.BirthDate != null) registered.BirthDate = entity.BirthDate;
      if (entity.Description != null) registered.Description = entity.Description;
      if (entity.Picture != null) registered.Picture = entity.Picture;
      if (entity.Belonging != null) registered.Belonging = entity.Belonging;
      if (entity.Role != null) registered.Role = entity.Role;
      if (entity.Loc != null) registered.Loc = entity.Loc;
      if (entity.Ref != null) registered.Ref = entity.Ref;
      this.dummyRosterContext.Employees.Update(registered);
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
    Employee? entity = this.dummyRosterContext.Employees.Find(id);
    if (entity is null)
    {
      return null;
    }
    this.dummyRosterContext.Employees.Remove(entity);
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

  private Employee UpdateCache(
    int id, 
    Employee entity
  )
  {
    Employee? alreadyRegistered;
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
