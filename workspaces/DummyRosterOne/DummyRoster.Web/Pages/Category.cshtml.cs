using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DummyRoster.Web.Pages;

public class CategoryModel : PageModel {
  
  public IEnumerable<string>? Categories { get; set; }

  public void OnGet() {}
}
