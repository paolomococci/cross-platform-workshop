using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.Common.DataContext.Data;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Repositories;

public class InvoiceRepository
{
  private static ConcurrentDictionary<int, Invoice>? keyValuesCache;
  private DummyRosterContext dummyRosterContext;

  public InvoiceRepository(
    DummyRosterContext dummyRosterContext
  )
  {
    this.dummyRosterContext = dummyRosterContext;
    if (keyValuesCache is null)
    {
      keyValuesCache = new ConcurrentDictionary<int, Invoice>(
        this.dummyRosterContext.Invoices.ToDictionary(
          entity => entity.Id
        )
      );
    }
  }
}
