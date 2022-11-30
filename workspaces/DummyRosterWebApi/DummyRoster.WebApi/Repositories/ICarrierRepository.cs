using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories;

public interface ICarrierRepository {
  Task<Carrier> CreateAsync(Carrier carrier);
}
