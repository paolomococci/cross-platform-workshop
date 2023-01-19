using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories;

public interface ICustomerRepository
{
  Task<Customer?> CreateAsync(Customer customer);
  Task<Customer?> RetrieveAsync(int id);
  Task<IEnumerable<Customer>> RetrieveAllAsync();
  Task<Customer?> UpdateAsync(
    int id,
    Customer customer
  );
  Task<bool?> DeleteAsync(int id);
}
