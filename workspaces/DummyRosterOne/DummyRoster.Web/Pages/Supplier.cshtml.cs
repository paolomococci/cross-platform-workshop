using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DummyRoster.Web.Pages;

public class SupplierModel : PageModel {

  public IEnumerable<string>? Suppliers { get; set; }

  public void OnGet() {
    ViewData["Title"] = "DummyRoster Web - Supplier";
    ViewData["CardTitle"] = "Suppliers";
    Suppliers = new[] {"Sample One", "Sample Two", "Sample Three", "Sample Four", "Sample Five"};
  }
}
