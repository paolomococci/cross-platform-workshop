using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories;

public interface IEmployeeRepository {
  Task<Employee> CreateAsync(Employee employee);
  Task<Employee> RetrieveAsync(int id);
}
