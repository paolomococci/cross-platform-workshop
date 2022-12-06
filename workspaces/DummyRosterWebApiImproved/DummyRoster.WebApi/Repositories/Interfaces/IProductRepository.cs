using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories.Interfaces;

public interface IProductRepository
{
  Task<Product?> CreateAsync(Product entity);
}
