using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Repositories;

public class FormRepository : IFormRepository
{
  public Task<Form?> CreateAsync(Form entity)
  {
    throw new NotImplementedException();
  }

  public Task<bool?> DeleteAsync(int id)
  {
    throw new NotImplementedException();
  }

  public Task<Form?> PartialUpdateAsync(int id, Form entity)
  {
    throw new NotImplementedException();
  }

  public Task<Form?> Retrieve(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<Form>> RetrieveAll()
  {
    throw new NotImplementedException();
  }

  public Task<Form?> UpdateAsync(int id, Form entity)
  {
    throw new NotImplementedException();
  }
}
