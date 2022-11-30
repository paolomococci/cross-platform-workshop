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
  ) {
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
  
  public Task<Employee?> CreateAsync(Employee employee)
  {
    throw new NotImplementedException();
  }

  public Task<bool?> DeleteAsync(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<Employee>> RetrieveAllAsync()
  {
    throw new NotImplementedException();
  }

  public Task<Employee?> RetrieveAsync(int id)
  {
    if (keyValuesCache is null) return null!;
    keyValuesCache.TryGetValue(id, out Employee? category);
    return Task.FromResult(category);
  }

  public Task<Employee?> UpdateAsync(int id, Employee employee)
  {
    throw new NotImplementedException();
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
