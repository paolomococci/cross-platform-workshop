using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.Common.DataContext.Data;

namespace DummyRoster.WebApi.Repositories;

public class FormRepository : IFormRepository
{
  private static ConcurrentDictionary<int, Form>? keyValuesCache;
  private DummyRosterContext dummyRosterContext;

  public FormRepository(
    DummyRosterContext dummyRosterContext
  ) {
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

  private Form UpdateCache(int id, Form form)
  {
    Form? alreadyRegistered;
    if (keyValuesCache is not null)
    {
      if (keyValuesCache.TryGetValue(id, out alreadyRegistered))
      {
        if (keyValuesCache.TryUpdate(id, form, alreadyRegistered))
        {
          return form;
        }
      }
    }
    return null!;
  }
}
