using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.Common.DataContext.Data;

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

  public async Task<Employee?> CreateAsync(Employee employee)
  {
    EntityEntry<Employee> entry = await this.dummyRosterContext.Employees.AddAsync(employee);
    int changesWereSavedAsynchronously = await this.dummyRosterContext.SaveChangesAsync();
    if (changesWereSavedAsynchronously == 1)
    {
      if (keyValuesCache is null)
      {
        return employee;
      }
      return keyValuesCache.AddOrUpdate(
        employee.Id,
        employee,
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
    Employee? employee = this.dummyRosterContext.Employees.Find(id);
    if (employee is null)
    {
      return null;
    }
    this.dummyRosterContext.Employees.Remove(employee);
    int changesSaved = await this.dummyRosterContext.SaveChangesAsync();
    if (changesSaved == 1)
    {
      if (keyValuesCache is null)
      {
        return null;
      }
      return keyValuesCache.TryRemove(id, out employee);
    }
    else
    {
      return null;
    }
  }

  public Task<IEnumerable<Employee>> RetrieveAllAsync()
  {
    return Task.FromResult(
      keyValuesCache is null ? Enumerable.Empty<Employee>() : keyValuesCache.Values
    );
  }

  public Task<Employee?> RetrieveAsync(int id)
  {
    if (keyValuesCache is null) return null!;
    keyValuesCache.TryGetValue(id, out Employee? category);
    return Task.FromResult(category);
  }

  public async Task<Employee?> UpdateAsync(int id, Employee employee)
  {
    this.dummyRosterContext.Employees.Update(employee);
    int changesSaved = await this.dummyRosterContext.SaveChangesAsync();
    if (changesSaved == 1)
    {
      return this.UpdateCache(id, employee);
    }
    return null;
  }

  private Employee UpdateCache(int id, Employee employee)
  {
    Employee? alreadyRegistered;
    if (keyValuesCache is not null)
    {
      if (keyValuesCache.TryGetValue(id, out alreadyRegistered))
      {
        if (keyValuesCache.TryUpdate(id, employee, alreadyRegistered))
        {
          return employee;
        }
      }
    }
    return null!;
  }
}
