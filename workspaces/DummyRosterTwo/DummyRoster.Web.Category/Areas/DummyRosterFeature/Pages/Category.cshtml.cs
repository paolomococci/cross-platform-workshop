using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using DummyRoster.Common.DataContext.Data;

namespace DummyRoster.Web.Category.DummyRosterFeature.Pages;

public class CategoryModel : PageModel
{
  private DummyRosterContext dummyRosterContext;
  public DummyRoster.Common.EntityModel.Models.Category[] categories { get; set; } = null!;

  public CategoryModel(
      DummyRosterContext dummyRosterContext
  )
  {
    this.dummyRosterContext = dummyRosterContext;
  }

  public void OnGet()
  {

  }
}
