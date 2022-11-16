using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

using DummyRoster.Common.DataContext.Data;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.Web.Pages;

public class SupplierModel : PageModel {

  public IEnumerable<Supplier>? Suppliers { get; set; }

  private DummyRosterContext dummyRosterContext;

  [BindProperty]
  public Supplier? Supplier { get; set; }

  public SupplierModel(DummyRosterContext dummyRosterContextInjected) {
    this.dummyRosterContext = dummyRosterContextInjected;
  }

  public void OnGet() {
    ViewData["Title"] = "DummyRoster Web - Supplier";
    Suppliers = dummyRosterContext.Suppliers.OrderBy(
      supplier => supplier.Country
    ).ThenBy(
      supplier => supplier.Name
    );
  }

  public IActionResult OnPost() {
    return Page();
  }
}
