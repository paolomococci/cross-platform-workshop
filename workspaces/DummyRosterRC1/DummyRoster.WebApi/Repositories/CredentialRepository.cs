using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Repositories;

public class CredentialRepository : ICredentialRepository
{
  private static ConcurrentDictionary<int, Credential>? keyValuesCache;
  private DummyRosterContext dummyRosterContext;

  public CredentialRepository(
    DummyRosterContext dummyRosterContext
  )
  {
    this.dummyRosterContext = dummyRosterContext;
    if (keyValuesCache is null)
    {
      keyValuesCache = new ConcurrentDictionary<int, Credential>(
        this.dummyRosterContext.Credentials.ToDictionary(
          entity => entity.Id
        )
      );
    }
  }
}
