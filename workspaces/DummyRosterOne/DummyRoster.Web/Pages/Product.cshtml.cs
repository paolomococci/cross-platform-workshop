using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DummyRoster.Web.Pages;

public class ProductModel : PageModel {
  public IEnumerable<string>? Products { get; set; }
}
