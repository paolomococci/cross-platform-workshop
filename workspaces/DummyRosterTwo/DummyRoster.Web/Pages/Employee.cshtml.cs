using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

using DummyRoster.Common.DataContext.Data;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.Web.Pages;

public class EmployeeModel : PageModel {

  public IEnumerable<Employee>? employees { get; set; }
  private DummyRosterContext dummyRosterContext;

  public EmployeeModel(DummyRosterContext dummyRosterContextInjected) {
    this.dummyRosterContext = dummyRosterContextInjected;
  }

  public void OnGet() {}

  public IActionResult OnPost() {
    return Page();
  }

}
