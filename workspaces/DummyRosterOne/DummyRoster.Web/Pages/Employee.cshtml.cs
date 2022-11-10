using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DummyRoster.Web.Pages;

public class EmployeeModel : PageModel {
  public IEnumerable<string>? Employees { get; set; }
}
