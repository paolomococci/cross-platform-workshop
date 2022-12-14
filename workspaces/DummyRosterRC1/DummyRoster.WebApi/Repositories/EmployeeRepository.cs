using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
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
}
