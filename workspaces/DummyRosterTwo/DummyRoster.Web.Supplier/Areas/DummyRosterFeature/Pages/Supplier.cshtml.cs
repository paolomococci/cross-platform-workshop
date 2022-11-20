using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using DummyRoster.Common.DataContext.Data;

namespace DummyRoster.Web.Supplier.DummyRosterFeature.Pages;

public class SupplierModel : PageModel
{
  private DummyRosterContext dummyRosterContext;
  public DummyRoster.Common.EntityModel.Models.Supplier[] suppliers { get; set; } = null!;

  public SupplierModel(
      DummyRosterContext dummyRosterContext
  )
  {
    this.dummyRosterContext = dummyRosterContext;
  }

  public void OnGet()
  {

  }
}
