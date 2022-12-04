using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories;

public interface ISupplierRepository
{
  Task<Supplier?> CreateAsync(Supplier supplier);
  Task<Supplier?> RetrieveAsync(int id);
  Task<IEnumerable<Supplier>> RetrieveAllAsync();
  Task<Supplier?> UpdateAsync(
    int id,
    Supplier supplier
  );
  Task<bool?> DeleteAsync(int id);
}
