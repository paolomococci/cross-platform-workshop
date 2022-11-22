using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

using DummyRoster.Common.DataContext.Data;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.Web.Pages;

public class CategoryModel : PageModel {

  [BindProperty]
  public Category category { get; set; } = new();

  public IEnumerable<Category>? categories { get; set; }
  private DummyRosterContext dummyRosterContext;

  public CategoryModel(DummyRosterContext dummyRosterContextInjected) {
    this.dummyRosterContext = dummyRosterContextInjected;
  }

  public void OnGet() {
    ViewData["Title"] = "DummyRoster Web - Category";
    categories = dummyRosterContext.Categories.OrderBy(
      entity => entity.Description
    ).ThenBy(
      entity => entity.Name
    );
  }

  public IActionResult OnPost() {
    return Page();
  }

}
