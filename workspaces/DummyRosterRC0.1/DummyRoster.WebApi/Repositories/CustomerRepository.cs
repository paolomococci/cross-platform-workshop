using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Repositories;

public class CustomerRepository : ICustomerRepository
{
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

  public Task<Customer?> Retrieve(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<Customer>> RetrieveAll()
  {
    throw new NotImplementedException();
  }

  public Task<Customer?> UpdateAsync(int id, Customer entity)
  {
    throw new NotImplementedException();
  }
}
