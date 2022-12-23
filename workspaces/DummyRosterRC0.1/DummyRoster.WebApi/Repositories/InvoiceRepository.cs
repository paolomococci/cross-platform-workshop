using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Repositories;

public class InvoiceRepository : IInvoiceRepository
{
  public Task<Invoice?> CreateAsync(Invoice entity)
  {
    throw new NotImplementedException();
  }

  public Task<bool?> DeleteAsync(int id)
  {
    throw new NotImplementedException();
  }

  public Task<Invoice?> PartialUpdateAsync(int id, Invoice entity)
  {
    throw new NotImplementedException();
  }

  public Task<Invoice?> Retrieve(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<Invoice>> RetrieveAll()
  {
    throw new NotImplementedException();
  }

  public Task<Invoice?> UpdateAsync(int id, Invoice entity)
  {
    throw new NotImplementedException();
  }
}
