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

  public async Task<Form?> CreateAsync(Form form)
  {
    EntityEntry<Form> entry = await this.dummyRosterContext.Forms.AddAsync(form);
    int changesWereSavedAsynchronously = await this.dummyRosterContext.SaveChangesAsync();
    if (changesWereSavedAsynchronously == 1)
    {
      if (keyValuesCache is null)
      {
        return form;
      }
      return keyValuesCache.AddOrUpdate(
        form.Id,
        form,
        UpdateCache
      );
    }
    else
    {
      return null;
    }
  }

  public async Task<bool?> DeleteAsync(int id)
  {
    Form? form = this.dummyRosterContext.Forms.Find(id);
    if (form is null)
    {
      return null;
    }
    this.dummyRosterContext.Forms.Remove(form);
    int changesSaved = await this.dummyRosterContext.SaveChangesAsync();
    if (changesSaved == 1)
    {
      if (keyValuesCache is null)
      {
        return null;
      }
      return keyValuesCache.TryRemove(id, out form);
    }
    else
    {
      return null;
    }
  }

  public Task<IEnumerable<Form>> RetrieveAllAsync()
  {
    return Task.FromResult(
      keyValuesCache is null ? Enumerable.Empty<Form>() : keyValuesCache.Values
    );
  }

  public Task<Form?> RetrieveAsync(int id)
  {
    if (keyValuesCache is null) return null!;
    keyValuesCache.TryGetValue(id, out Form? form);
    return Task.FromResult(form);
  }

  public async Task<Form?> UpdateAsync(int id, Form form)
  {
    this.dummyRosterContext.Forms.Update(form);
    int changesSaved = await this.dummyRosterContext.SaveChangesAsync();
    if (changesSaved == 1)
    {
      return this.UpdateCache(id, form);
    }
    return null;
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
