using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DummyRoster.Web.Pages;

public class InvoiceModel : PageModel {
  public IEnumerable<string>? Invoices { get; set; }
}
