using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

using DummyRoster.Common.DataContext.Data;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.Web.Pages;

public class EmployeeModel : PageModel
{

  [BindProperty]
  public Employee employee { get; set; } = new();

  public IEnumerable<Employee>? employees { get; set; }
  private DummyRosterContext dummyRosterContext;

  public EmployeeModel(DummyRosterContext dummyRosterContextInjected)
  {
    this.dummyRosterContext = dummyRosterContextInjected;
  }

  public void OnGet()
  {
    ViewData["Title"] = "DummyRoster Web - Employee";
    employees = dummyRosterContext.Employees.OrderBy(
      entity => entity.Country
    ).ThenBy(
      entity => entity.Name
    );
  }

  public IActionResult OnPost()
  {
    if ((this.employee is not null) && ModelState.IsValid)
    {
      this.dummyRosterContext.Employees.Add(this.employee);
      this.dummyRosterContext.SaveChanges();
      return RedirectToPage("/employee");
    }
    return Page();
  }

}
