using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DummyRoster.Web.Pages;

public class CustomerModel : PageModel {
  public IEnumerable<string>? Customers { get; set; }
}
