using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories;

public interface ICarrierRepository
{
  Task<Carrier?> CreateAsync(Carrier carrier);
  Task<Carrier?> RetrieveAsync(int id);
  Task<IEnumerable<Carrier>> RetrieveAllAsync();
  Task<Carrier?> UpdateAsync(
    int id,
    Carrier carrier
  );
  Task<bool?> DeleteAsync(int id);
}
