using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DummyRoster.Web.Pages;

public class SupplierModel : PageModel {
  public IEnumerable<string>? Suppliers { get; set; }
}
