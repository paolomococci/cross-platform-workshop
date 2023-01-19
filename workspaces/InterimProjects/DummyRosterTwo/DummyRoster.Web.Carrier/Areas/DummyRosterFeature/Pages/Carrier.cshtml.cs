using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using DummyRoster.Common.DataContext.Data;

namespace DummyRoster.Web.Carrier.DummyRosterFeature.Pages;

public class CarrierModel : PageModel
{
  private DummyRosterContext dummyRosterContext;
  public IQueryable<DummyRoster.Common.EntityModel.Models.Carrier> carriers { get; set; } = null!;

  public CarrierModel(
      DummyRosterContext dummyRosterContext
  )
  {
    this.dummyRosterContext = dummyRosterContext;
  }

  public void OnGet()
  {
    ViewData["Title"] = "DummyRoster Admin - Carrier";
    this.carriers = this.dummyRosterContext.Carriers.OrderBy(
      entity => entity.Country
    ).ThenBy(
      entity => entity.Name
    );
  }
}
