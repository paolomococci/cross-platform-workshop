using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

using DummyRoster.Common.DataContext.Data;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.Web.Pages;

public class ProductModel : PageModel {

  public IEnumerable<Product>? Products { get; set; }

  private DummyRosterContext dummyRosterContext;

  [BindProperty]
  public Product? Product { get; set; }

  public ProductModel(DummyRosterContext dummyRosterContextInjected) {
    this.dummyRosterContext = dummyRosterContextInjected;
  }

  public void OnGet() {
    ViewData["Title"] = "DummyRoster Web - Product";
    Products = dummyRosterContext.Products.OrderBy(
      product => product.RegistrationDate
    ).ThenBy(
      product => product.Name
    );
  }
}
