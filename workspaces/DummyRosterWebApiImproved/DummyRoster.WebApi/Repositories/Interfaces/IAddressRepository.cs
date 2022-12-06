using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories.Interfaces;

public interface IAddressRepository
{
  Task<Address?> CreateAsync(Address entity);
  Task<Address?> RetrieveAsync(int id);
}
