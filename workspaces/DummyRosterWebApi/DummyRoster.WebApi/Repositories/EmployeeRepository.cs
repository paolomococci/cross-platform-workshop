using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.Common.DataContext.Data;

namespace DummyRoster.WebApi.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
  private static ConcurrentDictionary<int, Employee>? keyValuesCache;
  private DummyRosterContext dummyRosterContext;
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
    throw new NotImplementedException();
  }

  public Task<Employee?> UpdateAsync(int id, Employee employee)
  {
    throw new NotImplementedException();
  }
}
