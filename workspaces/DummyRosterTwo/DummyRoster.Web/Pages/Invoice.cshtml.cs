using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

using DummyRoster.Common.DataContext.Data;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.Web.Pages;

public class InvoiceModel : PageModel {

  public IEnumerable<Invoice>? invoices { get; set; }
  private DummyRosterContext dummyRosterContext;

  public InvoiceModel(DummyRosterContext dummyRosterContextInjected) {
    this.dummyRosterContext = dummyRosterContextInjected;
  }

}
