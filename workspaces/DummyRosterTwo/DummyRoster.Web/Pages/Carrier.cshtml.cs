using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

using DummyRoster.Common.DataContext.Data;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.Web.Pages;

public class CarrierModel : PageModel {

  public IEnumerable<Carrier>? carriers { get; set; }
  private DummyRosterContext dummyRosterContext;

  public CarrierModel(DummyRosterContext dummyRosterContextInjected) {
    this.dummyRosterContext = dummyRosterContextInjected;
  }

  public void OnGet() {}

  public IActionResult OnPost() {
    return Page();
  }

}
