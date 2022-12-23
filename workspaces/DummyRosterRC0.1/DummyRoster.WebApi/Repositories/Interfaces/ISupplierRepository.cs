using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories.Interfaces;

public interface ISupplierRepository
{
  Task<Supplier?> CreateAsync(Supplier entity);
  Task<Supplier?> Retrieve(int id);
  Task<IEnumerable<Supplier>> RetrieveAll();
  Task<Supplier?> UpdateAsync(
    int id,
    Supplier entity
  );
  Task<Supplier?> PartialUpdateAsync(
    int id,
    Supplier entity
  );
  Task<bool?> DeleteAsync(int id);
}
