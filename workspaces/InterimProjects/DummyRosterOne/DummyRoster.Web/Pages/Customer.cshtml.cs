using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

using DummyRoster.Common.DataContext.Data;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.Web.Pages;

public class CustomerModel : PageModel {

  public IEnumerable<Customer>? Customers { get; set; }

  private DummyRosterContext dummyRosterContext;

  [BindProperty]
  public Customer Customer { get; set; } = new();

  public CustomerModel(DummyRosterContext dummyRosterContextInjected) {
    this.dummyRosterContext = dummyRosterContextInjected;
  }

  public void OnGet() {
    ViewData["Title"] = "DummyRoster Web - Customer";
    Customers = dummyRosterContext.Customers.OrderBy(
      customer => customer.Country
    ).ThenBy(
      customer => customer.Name
    );
  }

  public IActionResult OnPost() {
    if ((this.Customer is not null) && ModelState.IsValid)
    {
      this.dummyRosterContext.Customers.Add(this.Customer);
      this.dummyRosterContext.SaveChanges();
      return RedirectToPage("/customer");
    }
    return Page();
  }
}
