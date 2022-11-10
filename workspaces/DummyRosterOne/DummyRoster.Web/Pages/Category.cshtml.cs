using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DummyRoster.Web.Pages;

public class CategoryModel : PageModel {
  
  public IEnumerable<string>? Categories { get; set; }

  public void OnGet() {
    ViewData["Title"] = "DummyRoster Web - Category";
    ViewData["CardTitle"] = "Categories";
    Categories = new[] {"Sample One", "Sample Two", "Sample Three", "Sample Four", "Sample Five"};
  }
}
