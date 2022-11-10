using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DummyRoster.Web.Pages;

public class FormModel : PageModel {

  public IEnumerable<string>? Forms { get; set; }

  public void OnGet() {}
}
