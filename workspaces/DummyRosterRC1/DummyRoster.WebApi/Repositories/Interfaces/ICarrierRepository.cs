using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories.Interfaces;

public interface ICarrierRepository
{
  Task<Carrier?> CreateAsync(Carrier entity);
  Task<Carrier?> RetrieveAsync(int id);
  Task<IEnumerable<Carrier>> RetrieveAllAsync();
  Task<Carrier?> UpdateAsync(
    int id,
    Carrier entity
  );
  Task<Carrier?> PartialUpdateAsync(
    int id,
    Carrier entity
  );
  Task<bool?> DeleteAsync(int id);
}
