using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories;

public interface ISupplierRepository {
  Task<Supplier> CreateAsync(Supplier supplier);
}
