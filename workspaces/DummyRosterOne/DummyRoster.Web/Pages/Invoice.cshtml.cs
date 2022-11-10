using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DummyRoster.Web.Pages;

public class InvoiceModel : PageModel {

  public IEnumerable<string>? Invoices { get; set; }

  public void OnGet() {
    ViewData["Title"] = "DummyRoster Web - Invoice";
    ViewData["CardTitle"] = "Invoices";
    Invoices = new[] {"Sample One", "Sample Two", "Sample Three", "Sample Four", "Sample Five"};
  }
}
