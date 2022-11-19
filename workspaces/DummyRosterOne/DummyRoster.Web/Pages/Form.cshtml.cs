using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

using DummyRoster.Common.DataContext.Data;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.Web.Pages;

public class FormModel : PageModel {

  public IEnumerable<Form>? Forms { get; set; }

  private DummyRosterContext dummyRosterContext;

  [BindProperty]
  public Form Form { get; set; } = new();

  public FormModel(DummyRosterContext dummyRosterContextInjected) {
    this.dummyRosterContext = dummyRosterContextInjected;
  }

  public void OnGet() {
    ViewData["Title"] = "DummyRoster Web - Form";
    Forms = dummyRosterContext.Forms.OrderBy(
      form => form.RequiredDate
    ).ThenBy(
      form => form.PromisedDate
    );
  }

  public IActionResult OnPost() {
    if ((this.Form is not null) && ModelState.IsValid)
    {
      this.dummyRosterContext.Forms.Add(this.Form);
      this.dummyRosterContext.SaveChanges();
      return RedirectToPage("/form");
    }
    return Page();
  }
}
