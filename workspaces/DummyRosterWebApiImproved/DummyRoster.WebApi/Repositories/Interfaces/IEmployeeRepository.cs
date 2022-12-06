using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories.Interfaces;

public interface IEmployeeRepository
{
  Task<Employee?> CreateAsync(Employee entity);
}
