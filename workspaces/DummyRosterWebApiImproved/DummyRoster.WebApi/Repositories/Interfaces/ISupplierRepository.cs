using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories.Interfaces;

public interface ISupplierRepository
{
  Task<Supplier?> CreateAsync(Supplier entity);
  Task<Supplier?> RetrieveAsync(int id);
}
