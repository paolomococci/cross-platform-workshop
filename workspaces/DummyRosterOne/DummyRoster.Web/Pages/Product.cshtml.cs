using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

using DummyRoster.Common.DataContext.Data;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.Web.Pages;

public class ProductModel : PageModel {

  public IEnumerable<Product>? Products { get; set; }

  private DummyRosterContext dummyRosterContext;

  [BindProperty]
  public Product Product { get; set; } = new();

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

  public IActionResult OnPost() {
    if ((this.Product is not null) && ModelState.IsValid)
    {
      this.dummyRosterContext.Products.Add(this.Product);
      this.dummyRosterContext.SaveChanges();
      return RedirectToPage("/product");
    }
    return Page();
  }
}
