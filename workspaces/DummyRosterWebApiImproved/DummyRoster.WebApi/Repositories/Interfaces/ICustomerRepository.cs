using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories.Interfaces;

public interface ICustomerRepository
{
  Task<Customer?> CreateAsync(Customer entity);
}
