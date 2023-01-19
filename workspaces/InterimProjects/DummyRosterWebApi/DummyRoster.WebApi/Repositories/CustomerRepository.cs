using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.Common.DataContext.Data;

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

  public async Task<Customer?> CreateAsync(Customer customer)
  {
    EntityEntry<Customer> entry = await this.dummyRosterContext.Customers.AddAsync(customer);
    int changesWereSavedAsynchronously = await this.dummyRosterContext.SaveChangesAsync();
    if (changesWereSavedAsynchronously == 1)
    {
      if (keyValuesCache is null)
      {
        return customer;
      }
      return keyValuesCache.AddOrUpdate(
        customer.Id,
        customer,
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
    Customer? customer = this.dummyRosterContext.Customers.Find(id);
    if (customer is null)
    {
      return null;
    }
    this.dummyRosterContext.Customers.Remove(customer);
    int changesSaved = await this.dummyRosterContext.SaveChangesAsync();
    if (changesSaved == 1)
    {
      if (keyValuesCache is null)
      {
        return null;
      }
      return keyValuesCache.TryRemove(id, out customer);
    }
    else
    {
      return null;
    }
  }

  public Task<IEnumerable<Customer>> RetrieveAllAsync()
  {
    return Task.FromResult(
      keyValuesCache is null ? Enumerable.Empty<Customer>() : keyValuesCache.Values
    );
  }

  public Task<Customer?> RetrieveAsync(int id)
  {
    if (keyValuesCache is null) return null!;
    keyValuesCache.TryGetValue(id, out Customer? category);
    return Task.FromResult(category);
  }

  public async Task<Customer?> UpdateAsync(int id, Customer customer)
  {
    this.dummyRosterContext.Customers.Update(customer);
    int changesSaved = await this.dummyRosterContext.SaveChangesAsync();
    if (changesSaved == 1)
    {
      return this.UpdateCache(id, customer);
    }
    return null;
  }

  private Customer UpdateCache(int id, Customer customer)
  {
    Customer? alreadyRegistered;
    if (keyValuesCache is not null)
    {
      if (keyValuesCache.TryGetValue(id, out alreadyRegistered))
      {
        if (keyValuesCache.TryUpdate(id, customer, alreadyRegistered))
        {
          return customer;
        }
      }
    }
    return null!;
  }
}
