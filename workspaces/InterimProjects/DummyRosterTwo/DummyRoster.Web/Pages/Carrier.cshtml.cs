using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

using DummyRoster.Common.DataContext.Data;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.Web.Pages;

public class CarrierModel : PageModel
{

  [BindProperty]
  public Carrier carrier { get; set; } = new();

  public IEnumerable<Carrier>? carriers { get; set; }
  private DummyRosterContext dummyRosterContext;

  public CarrierModel(DummyRosterContext dummyRosterContextInjected)
  {
    this.dummyRosterContext = dummyRosterContextInjected;
  }

  public void OnGet()
  {
    ViewData["Title"] = "DummyRoster Web - Carrier";
    carriers = dummyRosterContext.Carriers.OrderBy(
      entity => entity.Country
    ).ThenBy(
      entity => entity.Name
    );
  }

  public IActionResult OnPost()
  {
    if ((this.carrier is not null) && ModelState.IsValid)
    {
      this.dummyRosterContext.Carriers.Add(this.carrier);
      this.dummyRosterContext.SaveChanges();
      return RedirectToPage("/carrier");
    }
    return Page();
  }

}
