using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using DummyRoster.Common.DataContext.Data;

namespace DummyRoster.Web.Form.DummyRosterFeature.Pages;

public class FormModel : PageModel
{
  private DummyRosterContext dummyRosterContext;
  public IQueryable<DummyRoster.Common.EntityModel.Models.Form> forms { get; set; } = null!;

  public FormModel(
      DummyRosterContext dummyRosterContext
  )
  {
    this.dummyRosterContext = dummyRosterContext;
  }

  public void OnGet()
  {
    ViewData["Title"] = "DummyRoster Admin - Form";
    this.forms = this.dummyRosterContext.Forms.OrderBy(
      entity => entity.RequiredDate
    ).ThenBy(
      entity => entity.PromisedDate
    );
  }
}
