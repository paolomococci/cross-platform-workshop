using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories.Interfaces;

public interface ICarrierRepository {
  Task<Carrier?> CreateAsync(Carrier address);
}
