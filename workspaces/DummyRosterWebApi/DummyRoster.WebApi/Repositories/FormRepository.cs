using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories;

public class FormRepository : IFormRepository
{
  public Task<Form?> CreateAsync(Form form)
  {
    throw new NotImplementedException();
  }

  public Task<bool?> DeleteAsync(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<Form>> RetrieveAllAsync()
  {
    throw new NotImplementedException();
  }

  public Task<Form?> RetrieveAsync(int id)
  {
    throw new NotImplementedException();
  }

  public Task<Form?> UpdateAsync(int id, Form form)
  {
    throw new NotImplementedException();
  }
}
