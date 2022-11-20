using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using DummyRoster.Common.DataContext.Data;

namespace DummyRoster.Web.Employee.DummyRosterFeature.Pages;

public class EmployeeModel : PageModel
{
  private DummyRosterContext dummyRosterContext;
  public DummyRoster.Common.EntityModel.Models.Employee[] employees { get; set; } = null!;

  public EmployeeModel(
      DummyRosterContext dummyRosterContext
  )
  {
    this.dummyRosterContext = dummyRosterContext;
  }

  public void OnGet()
  {

  }
}
