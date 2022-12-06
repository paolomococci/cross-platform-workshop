using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories.Interfaces;

public interface IInvoiceRepository
{
  Task<Invoice?> CreateAsync(Invoice entity);
  Task<Invoice?> RetrieveAsync(int id);
  Task<IEnumerable<Invoice>> RetrieveAllAsync();
}
