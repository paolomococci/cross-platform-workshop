using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.Common.DataContext.Data;

namespace DummyRoster.WebApi.Repositories;

public class CarrierRepository : ICarrierRepository
{
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
}
