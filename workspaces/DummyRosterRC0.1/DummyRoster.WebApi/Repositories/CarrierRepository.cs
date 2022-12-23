using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Repositories;

public class CarrierRepository : ICarrierRepository
{
  public Task<Carrier?> CreateAsync(Carrier entity)
  {
    throw new NotImplementedException();
  }

  public Task<bool?> DeleteAsync(int id)
  {
    throw new NotImplementedException();
  }

  public Task<Carrier?> PartialUpdateAsync(int id, Carrier entity)
  {
    throw new NotImplementedException();
  }

  public Task<Carrier?> Retrieve(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<Carrier>> RetrieveAll()
  {
    throw new NotImplementedException();
  }

  public Task<Carrier?> UpdateAsync(int id, Carrier entity)
  {
    throw new NotImplementedException();
  }
}
