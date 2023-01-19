using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories.Interfaces;

public interface IEmployeeRepository
{
  Task<Employee?> CreateAsync(Employee entity);
  Task<Employee?> RetrieveAsync(int id);
  Task<IEnumerable<Employee>> RetrieveAllAsync();
  Task<Employee?> UpdateAsync(
    int id,
    Employee entity
  );
  Task<Employee?> PartialUpdateAsync(
    int id,
    Employee entity
  );
  Task<bool?> DeleteAsync(int id);
}
