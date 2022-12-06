using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories.Interfaces;

public interface IInvoiceRepository
{
  Task<Invoice?> CreateAsync(Invoice entity);
  Task<Invoice?> RetrieveAsync(int id);
  Task<IEnumerable<Invoice>> RetrieveAllAsync();
  Task<Invoice?> UpdateAsync(
    int id,
    Invoice entity
  );
  Task<Invoice?> PartialUpdateAsync(
    int id,
    Invoice entity
  );
  Task<bool?> DeleteAsync(int id);
}
