using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.Common.DataContext.Data;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Repositories;

public class CustomerRepository
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
}
