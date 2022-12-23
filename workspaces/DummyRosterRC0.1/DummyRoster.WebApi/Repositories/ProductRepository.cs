using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Repositories;

public class ProductRepository : IProductRepository
{
  public Task<Product?> CreateAsync(Product entity)
  {
    throw new NotImplementedException();
  }

  public Task<bool?> DeleteAsync(int id)
  {
    throw new NotImplementedException();
  }

  public Task<Product?> PartialUpdateAsync(int id, Product entity)
  {
    throw new NotImplementedException();
  }

  public Task<Product?> Retrieve(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<Product>> RetrieveAll()
  {
    throw new NotImplementedException();
  }

  public Task<Product?> UpdateAsync(int id, Product entity)
  {
    throw new NotImplementedException();
  }
}
