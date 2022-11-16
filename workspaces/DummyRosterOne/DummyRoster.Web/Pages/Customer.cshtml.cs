using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

using DummyRoster.Common.DataContext.Data;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.Web.Pages;

public class CustomerModel : PageModel {

  public IEnumerable<Customer>? Customers { get; set; }

  private DummyRosterContext dummyRosterContext;

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
}
