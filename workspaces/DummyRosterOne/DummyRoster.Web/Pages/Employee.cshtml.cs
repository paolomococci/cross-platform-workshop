using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DummyRoster.Web.Pages;

public class EmployeeModel : PageModel {

  public IEnumerable<string>? Employees { get; set; }

  public void OnGet() {
    ViewData["Title"] = "DummyRoster Web - Employee";
    ViewData["CardTitle"] = "Employees";
    Employees = new[] {"Sample One", "Sample Two", "Sample Three", "Sample Four", "Sample Five"};
  }
}
