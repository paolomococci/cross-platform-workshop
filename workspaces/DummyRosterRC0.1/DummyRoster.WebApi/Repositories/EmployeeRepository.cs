using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
  public Task<Employee?> CreateAsync(Employee entity)
  {
    throw new NotImplementedException();
  }

  public Task<bool?> DeleteAsync(int id)
  {
    throw new NotImplementedException();
  }

  public Task<Employee?> PartialUpdateAsync(int id, Employee entity)
  {
    throw new NotImplementedException();
  }

  public Task<Employee?> Retrieve(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<Employee>> RetrieveAll()
  {
    throw new NotImplementedException();
  }

  public Task<Employee?> UpdateAsync(int id, Employee entity)
  {
    throw new NotImplementedException();
  }
}
