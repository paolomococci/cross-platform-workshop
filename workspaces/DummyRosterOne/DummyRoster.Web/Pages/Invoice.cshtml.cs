using Microsoft.AspNetCore.Mvc.RazorPages;

using DummyRoster.Common.DataContext.Data;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.Web.Pages;

public class InvoiceModel : PageModel {

  public IEnumerable<Invoice>? Invoices { get; set; }

  private DummyRosterContext dummyRosterContext;

  public InvoiceModel(DummyRosterContext dummyRosterContextInjected) {
    this.dummyRosterContext = dummyRosterContextInjected;
  }

  public void OnGet() {
    ViewData["Title"] = "DummyRoster Web - Invoice";
    Invoices = dummyRosterContext.Invoices.OrderBy(
      invoice => invoice.RegistrationDate
    ).ThenBy(
      invoice => invoice.Quantity
    );
  }
}
