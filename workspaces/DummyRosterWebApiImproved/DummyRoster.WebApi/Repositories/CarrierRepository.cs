using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.Common.DataContext.Data;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Repositories;

public class CarrierRepository : ICarrierRepository
{
  private static ConcurrentDictionary<int, Carrier>? keyValuesCache;
  private DummyRosterContext dummyRosterContext;

  public CarrierRepository(
    DummyRosterContext dummyRosterContext
  )
  {
    this.dummyRosterContext = dummyRosterContext;
    if (keyValuesCache is null)
    {
      keyValuesCache = new ConcurrentDictionary<int, Carrier>(
        this.dummyRosterContext.Carriers.ToDictionary(
          entity => entity.Id
        )
      );
    }
  }

  private Carrier UpdateCache(
    int id, 
    Carrier entity
  )
  {
    Carrier? alreadyRegistered;
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
