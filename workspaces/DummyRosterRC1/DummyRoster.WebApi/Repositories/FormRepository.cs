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
}
