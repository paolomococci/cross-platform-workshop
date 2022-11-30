using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories;

public interface IProductRepository {
  Task<Product> CreateAsync(Product product);
}
