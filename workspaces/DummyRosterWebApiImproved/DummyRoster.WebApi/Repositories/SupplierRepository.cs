using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.Common.DataContext.Data;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Repositories;

public class SupplierRepository
{
  private static ConcurrentDictionary<int, Supplier>? keyValuesCache;
  private DummyRosterContext dummyRosterContext;
}
