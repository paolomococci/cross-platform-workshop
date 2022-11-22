using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

using DummyRoster.Common.DataContext.Data;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.Web.Pages;

public class InvoiceModel : PageModel {

  [BindProperty]
  public Invoice invoice { get; set; } = new();

  public IEnumerable<Invoice>? invoices { get; set; }
  private DummyRosterContext dummyRosterContext;

  public InvoiceModel(DummyRosterContext dummyRosterContextInjected) {
    this.dummyRosterContext = dummyRosterContextInjected;
  }

  public void OnGet() {
    ViewData["Title"] = "DummyRoster Web - Invoice";
    invoices = dummyRosterContext.Invoices.OrderBy(
      entity => entity.Note
    ).ThenBy(
      entity => entity.Quantity
    );
  }

  public IActionResult OnPost() {
    return Page();
  }

}
