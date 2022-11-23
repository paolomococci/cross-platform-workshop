using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

using DummyRoster.Common.DataContext.Data;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.Web.Pages;

public class FormModel : PageModel
{

  [BindProperty]
  public Form form { get; set; } = new();

  public IEnumerable<Form>? forms { get; set; }
  private DummyRosterContext dummyRosterContext;

  public FormModel(DummyRosterContext dummyRosterContextInjected)
  {
    this.dummyRosterContext = dummyRosterContextInjected;
  }

  public void OnGet()
  {
    ViewData["Title"] = "DummyRoster Web - Form";
    forms = dummyRosterContext.Forms.OrderBy(
      entity => entity.RequiredDate
    ).ThenBy(
      entity => entity.PromisedDate
    );
  }

  public IActionResult OnPost()
  {
    if ((this.form is not null) && ModelState.IsValid)
    {
      this.dummyRosterContext.Forms.Add(this.form);
      this.dummyRosterContext.SaveChanges();
      return RedirectToPage("/form");
    }
    return Page();
  }

}
