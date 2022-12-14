using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Repositories;

public class FormRepository : IFormRepository
{
  private static ConcurrentDictionary<int, Form>? keyValuesCache;
  private DummyRosterContext dummyRosterContext;

  public FormRepository(
    DummyRosterContext dummyRosterContext
  )
  {
    this.dummyRosterContext = dummyRosterContext;
    if (keyValuesCache is null)
    {
      keyValuesCache = new ConcurrentDictionary<int, Form>(
        this.dummyRosterContext.Forms.ToDictionary(
          entity => entity.Id
        )
      );
    }
  }

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

  public Task<IEnumerable<Form>> RetrieveAllAsync()
  {
    throw new NotImplementedException();
  }

  public Task<Form?> RetrieveAsync(int id)
  {
    throw new NotImplementedException();
  }

  public Task<Form?> UpdateAsync(int id, Form entity)
  {
    throw new NotImplementedException();
  }

  private Form UpdateCache(
    int id, 
    Form entity
  )
  {
    Form? alreadyRegistered;
    if (keyValuesCache is not null)
    {
      if (keyValuesCache.TryGetValue(id, out alreadyRegistered))
      {
        if (keyValuesCache.TryUpdate(id, entity, alreadyRegistered))
        {
          return entity;
        }
      }
    }
    return null!;
  }
}
