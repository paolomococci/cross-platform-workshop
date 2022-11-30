using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories;

public interface IAddressRepository {
  Task<Address> CreateAsync(Address address);
}
