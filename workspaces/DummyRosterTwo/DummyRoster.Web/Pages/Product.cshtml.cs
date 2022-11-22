using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

using DummyRoster.Common.DataContext.Data;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.Web.Pages;

public class ProductModel : PageModel {

  [BindProperty]
  public Product product { get; set; } = new();

  public IEnumerable<Product>? products { get; set; }
  private DummyRosterContext dummyRosterContext;

  public ProductModel(DummyRosterContext dummyRosterContextInjected) {
    this.dummyRosterContext = dummyRosterContextInjected;
  }

  public void OnGet() {}

  public IActionResult OnPost() {
    return Page();
  }

}
