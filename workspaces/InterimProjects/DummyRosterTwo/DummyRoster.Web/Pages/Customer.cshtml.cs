using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

using DummyRoster.Common.DataContext.Data;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.Web.Pages;

public class CustomerModel : PageModel
{

  [BindProperty]
  public Customer customer { get; set; } = new();

  public IEnumerable<Customer>? customers { get; set; }
  private DummyRosterContext dummyRosterContext;

  public CustomerModel(DummyRosterContext dummyRosterContextInjected)
  {
    this.dummyRosterContext = dummyRosterContextInjected;
  }

  public void OnGet()
  {
    ViewData["Title"] = "DummyRoster Web - Customer";
    customers = dummyRosterContext.Customers.OrderBy(
      entity => entity.Country
    ).ThenBy(
      entity => entity.Name
    );
  }

  public IActionResult OnPost()
  {
    if ((this.customer is not null) && ModelState.IsValid)
    {
      this.dummyRosterContext.Customers.Add(this.customer);
      this.dummyRosterContext.SaveChanges();
      return RedirectToPage("/customer");
    }
    return Page();
  }

}
