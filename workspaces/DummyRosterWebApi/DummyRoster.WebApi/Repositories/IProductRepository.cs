using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories;

public interface IProductRepository
{
  Task<Product?> CreateAsync(Product product);
  Task<Product?> RetrieveAsync(int id);
  Task<IEnumerable<Product>> RetrieveAllAsync();
  Task<Product?> UpdateAsync(
    int id,
    Product product
  );
  Task<bool?> DeleteAsync(int id);
}
