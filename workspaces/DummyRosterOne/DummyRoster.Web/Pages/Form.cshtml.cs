using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DummyRoster.Web.Pages;

public class FormModel : PageModel {

  public IEnumerable<string>? Forms { get; set; }

  public void OnGet() {
    ViewData["Title"] = "DummyRoster Web - Form";
    Forms = new[] {"Sample One", "Sample Two", "Sample Three", "Sample Four", "Sample Five"};
  }
}
