using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories;

public class CustomerRepository : ICustomerRepository
{
  public Task<Customer?> CreateAsync(Customer customer)
  {
    throw new NotImplementedException();
  }

  public Task<bool?> DeleteAsync(int id)
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

  public Task<Customer?> UpdateAsync(int id, Customer customer)
  {
    throw new NotImplementedException();
  }
}
