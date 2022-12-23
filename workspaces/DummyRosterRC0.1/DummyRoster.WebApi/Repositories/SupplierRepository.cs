using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Repositories;

public class SupplierRepository : ISupplierRepository
{
  public Task<Supplier?> CreateAsync(Supplier entity)
  {
    throw new NotImplementedException();
  }

  public Task<bool?> DeleteAsync(int id)
  {
    throw new NotImplementedException();
  }

  public Task<Supplier?> PartialUpdateAsync(int id, Supplier entity)
  {
    throw new NotImplementedException();
  }

  public Task<Supplier?> Retrieve(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<Supplier>> RetrieveAll()
  {
    throw new NotImplementedException();
  }

  public Task<Supplier?> UpdateAsync(int id, Supplier entity)
  {
    throw new NotImplementedException();
  }
}
