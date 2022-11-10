using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DummyRoster.Web.Pages;

public class CarrierModel : PageModel {
  
  public IEnumerable<string>? Carriers { get; set; }

  public void OnGet() {}
}
