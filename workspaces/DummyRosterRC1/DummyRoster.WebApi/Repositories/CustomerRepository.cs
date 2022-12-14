using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
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

  public Task<Customer?> CreateAsync(Customer entity)
  {
    throw new NotImplementedException();
  }

  public Task<bool?> DeleteAsync(int id)
  {
    throw new NotImplementedException();
  }

  public Task<Customer?> PartialUpdateAsync(int id, Customer entity)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<Customer>> RetrieveAllAsync()
  {
    throw new NotImplementedException();
  }

  public Task<Customer?> RetrieveAsync(int id)
  {
    throw new NotImplementedException();
  }

  public Task<Customer?> UpdateAsync(int id, Customer entity)
  {
    throw new NotImplementedException();
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
