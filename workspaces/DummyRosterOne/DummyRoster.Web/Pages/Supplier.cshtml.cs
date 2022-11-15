using Microsoft.AspNetCore.Mvc.RazorPages;

using DummyRoster.Common.DataContext.Data;

namespace DummyRoster.Web.Pages;

public class SupplierModel : PageModel {

  public IEnumerable<string>? Suppliers { get; set; }

  private DummyRosterContext dummyRosterContext;

  public SupplierModel(DummyRosterContext injectedContext) {
    this.dummyRosterContext = injectedContext;
  }

  public void OnGet() {
    ViewData["Title"] = "DummyRoster Web - Supplier";
    ViewData["CardTitle"] = "Suppliers";
    Suppliers = new[] {"Sample One", "Sample Two", "Sample Three", "Sample Four", "Sample Five"};
  }
}
