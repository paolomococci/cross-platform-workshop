using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.Common.DataContext.Data;

namespace DummyRoster.WebApi.Repositories;

public class CarrierRepository : ICarrierRepository
{
  private static ConcurrentDictionary<int, Carrier>? keyValuesCache;
  private DummyRosterContext dummyRosterContext;

  public CarrierRepository(
    DummyRosterContext dummyRosterContext
  ) {
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
  
  public Task<Carrier?> CreateAsync(Carrier carrier)
  {
    throw new NotImplementedException();
  }

  public Task<bool?> DeleteAsync(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<Carrier>> RetrieveAllAsync()
  {
    throw new NotImplementedException();
  }

  public Task<Carrier?> RetrieveAsync(int id)
  {
    throw new NotImplementedException();
  }

  public Task<Carrier?> UpdateAsync(int id, Carrier carrier)
  {
    throw new NotImplementedException();
  }

  private Carrier UpdateCache(int id, Carrier carrier)
  {
    throw new NotImplementedException();
  }
}
