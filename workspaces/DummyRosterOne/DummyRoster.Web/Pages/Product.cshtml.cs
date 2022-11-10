using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DummyRoster.Web.Pages;

public class ProductModel : PageModel {

  public IEnumerable<string>? Products { get; set; }

  public void OnGet() {
    ViewData["Title"] = "DummyRoster Web - Product";
    Products = new[] {"Sample One", "Sample Two", "Sample Three", "Sample Four", "Sample Five"};
  }
}
