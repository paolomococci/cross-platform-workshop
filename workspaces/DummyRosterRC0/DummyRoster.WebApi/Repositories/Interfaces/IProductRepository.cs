using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories.Interfaces;

public interface IProductRepository
{
  Task<Product?> CreateAsync(Product entity);
  Task<Product?> Retrieve(int id);
  Task<IEnumerable<Product>> RetrieveAll();
  Task<Product?> UpdateAsync(
    int id,
    Product entity
  );
  Task<Product?> PartialUpdateAsync(
    int id,
    Product entity
  );
  Task<bool?> DeleteAsync(int id);
}
