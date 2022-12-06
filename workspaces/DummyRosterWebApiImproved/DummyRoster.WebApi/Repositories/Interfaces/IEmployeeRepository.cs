using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories.Interfaces;

public interface IEmployeeRepository
{
  Task<Employee?> CreateAsync(Employee entity);
  Task<Employee?> RetrieveAsync(int id);
  Task<IEnumerable<Employee>> RetrieveAllAsync();
}
