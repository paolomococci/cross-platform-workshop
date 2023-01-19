using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using DummyRoster.Common.DataContext.Data;

namespace DummyRoster.Web.Customer.DummyRosterFeature.Pages;

public class CustomerModel : PageModel
{
  private DummyRosterContext dummyRosterContext;
  public IQueryable<DummyRoster.Common.EntityModel.Models.Customer> customers { get; set; } = null!;

  public CustomerModel(
      DummyRosterContext dummyRosterContext
  )
  {
    this.dummyRosterContext = dummyRosterContext;
  }

  public void OnGet()
  {
    ViewData["Title"] = "DummyRoster Admin - Customer";
    this.customers = this.dummyRosterContext.Customers.OrderBy(
      entity => entity.Country
    ).ThenBy(
      entity => entity.Name
    );
  }
}
