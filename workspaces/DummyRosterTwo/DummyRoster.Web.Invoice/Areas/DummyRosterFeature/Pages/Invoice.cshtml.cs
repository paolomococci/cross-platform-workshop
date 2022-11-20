using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using DummyRoster.Common.DataContext.Data;

namespace DummyRoster.Web.Invoice.DummyRosterFeature.Pages;

public class InvoiceModel : PageModel
{
  private DummyRosterContext dummyRosterContext;

  public InvoiceModel(
      DummyRosterContext dummyRosterContext
  )
  {
    this.dummyRosterContext = dummyRosterContext;
  }

  public void OnGet()
  {

  }
}
