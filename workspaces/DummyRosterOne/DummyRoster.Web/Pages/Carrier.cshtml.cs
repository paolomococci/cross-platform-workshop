using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

using DummyRoster.Common.DataContext.Data;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.Web.Pages;

public class CarrierModel : PageModel {

  public IEnumerable<Carrier>? Carriers { get; set; }

  private DummyRosterContext dummyRosterContext;

  [BindProperty]
  public Carrier? Carrier { get; set; }

  public CarrierModel(DummyRosterContext dummyRosterContextInjected) {
    this.dummyRosterContext = dummyRosterContextInjected;
  }

  public void OnGet() {
    ViewData["Title"] = "DummyRoster Web - Carrier";
    Carriers = dummyRosterContext.Carriers.OrderBy(
      carrier => carrier.Country
    ).ThenBy(
      carrier => carrier.Name
    );
  }

  public IActionResult OnPost() {
    return Page();
  }
}
