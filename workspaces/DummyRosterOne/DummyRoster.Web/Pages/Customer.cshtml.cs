using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DummyRoster.Web.Pages;

public class CustomerModel : PageModel {

  public IEnumerable<string>? Customers { get; set; }

  public void OnGet() {
    ViewData["Title"] = "DummyRoster Web - Customer";
    ViewData["CardTitle"] = "Customers";
    Customers = new[] {"Sample One", "Sample Two", "Sample Three", "Sample Four", "Sample Five"};
  }
}
