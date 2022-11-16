using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

using DummyRoster.Common.DataContext.Data;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.Web.Pages;

public class CarrierModel : PageModel {

  public IEnumerable<Carrier>? Carriers { get; set; }

  private DummyRosterContext dummyRosterContext;

  [BindProperty]
  public Carrier Carrier { get; set; } = new();

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
    if ((this.Carrier is not null) && ModelState.IsValid)
    {
      this.dummyRosterContext.Carriers.Add(this.Carrier);
      this.dummyRosterContext.SaveChanges();
      return RedirectToPage("/carrier");
    }
    return Page();
  }
}
