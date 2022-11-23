using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

using DummyRoster.Common.DataContext.Data;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.Web.Pages;

public class SupplierModel : PageModel
{

  [BindProperty]
  public Supplier supplier { get; set; } = new();

  public IEnumerable<Supplier>? suppliers { get; set; }
  private DummyRosterContext dummyRosterContext;

  public SupplierModel(DummyRosterContext dummyRosterContextInjected)
  {
    this.dummyRosterContext = dummyRosterContextInjected;
  }

  public void OnGet()
  {
    ViewData["Title"] = "DummyRoster Web - Supplier";
    suppliers = dummyRosterContext.Suppliers.OrderBy(
      entity => entity.Country
    ).ThenBy(
      entity => entity.Name
    );
  }

  public IActionResult OnPost()
  {
    if ((this.supplier is not null) && ModelState.IsValid)
    {
      this.dummyRosterContext.Suppliers.Add(this.supplier);
      this.dummyRosterContext.SaveChanges();
      return RedirectToPage("/supplier");
    }
    return Page();
  }

}
