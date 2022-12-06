using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories.Interfaces;

public interface IInvoiceRepository {
  Task<Invoice?> CreateAsync(Invoice address);
}
