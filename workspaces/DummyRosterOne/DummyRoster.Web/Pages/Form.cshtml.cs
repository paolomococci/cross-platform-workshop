using Microsoft.AspNetCore.Mvc.RazorPages;

using DummyRoster.Common.DataContext.Data;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.Web.Pages;

public class FormModel : PageModel {

  public IEnumerable<Form>? Forms { get; set; }

  private DummyRosterContext dummyRosterContext;

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
}
