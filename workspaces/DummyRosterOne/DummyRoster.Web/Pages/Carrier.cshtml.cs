using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DummyRoster.Web.Pages;

public class CarrierModel : PageModel {

  public IEnumerable<string>? Carriers { get; set; }

  public void OnGet() {
    ViewData["Title"] = "DummyRoster Web - Carrier";
    ViewData["CardTitle"] = "Carriers";
    Carriers = new[] {"Sample One", "Sample Two", "Sample Three", "Sample Four", "Sample Five"};
  }
}
