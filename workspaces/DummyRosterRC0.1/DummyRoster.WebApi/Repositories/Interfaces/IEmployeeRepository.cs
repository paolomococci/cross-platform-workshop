using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.WebApi.Repositories.Interfaces;

public interface IEmployeeRepository
{
  Task<Employee?> CreateAsync(Employee entity);
  Task<Employee?> Retrieve(int id);
  Task<IEnumerable<Employee>> RetrieveAll();
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
