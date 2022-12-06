using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories.Interfaces;

public interface IAddressRepository {
  Task<Address?> CreateAsync(Address address);
}
