using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories.Interfaces;

public interface ICarrierRepository
{
  Task<Carrier?> CreateAsync(Carrier entity);
  Task<Carrier?> Retrieve(int id);
  Task<IEnumerable<Carrier>> RetrieveAll();
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
