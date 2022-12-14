using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories.Interfaces;

public interface IProductRepository
{
  Task<Product?> CreateAsync(Product entity);
  Task<Product?> RetrieveAsync(int id);
  Task<IEnumerable<Product>> RetrieveAllAsync();
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
