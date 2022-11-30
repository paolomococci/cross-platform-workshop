using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories;

public interface IInvoiceRepository {
  Task<Invoice> CreateAsync(Invoice invoice);
  Task<Invoice> RetrieveAsync(int id);
}
