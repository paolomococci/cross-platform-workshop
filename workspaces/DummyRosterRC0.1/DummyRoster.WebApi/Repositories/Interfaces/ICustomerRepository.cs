using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories.Interfaces;

public interface ICustomerRepository
{
  Task<Customer?> CreateAsync(Customer entity);
  Task<Customer?> Retrieve(int id);
  Task<IEnumerable<Customer>> RetrieveAll();
  Task<Customer?> UpdateAsync(
    int id,
    Customer entity
  );
  Task<Customer?> PartialUpdateAsync(
    int id,
    Customer entity
  );
  Task<bool?> DeleteAsync(int id);
}
