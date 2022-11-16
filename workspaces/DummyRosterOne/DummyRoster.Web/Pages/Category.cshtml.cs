using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

using DummyRoster.Common.DataContext.Data;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.Web.Pages;

public class CategoryModel : PageModel {

  public IEnumerable<Category>? Categories { get; set; }

  private DummyRosterContext dummyRosterContext;

  [BindProperty]
  public Category? Category { get; set; }

  public CategoryModel(DummyRosterContext dummyRosterContextInjected) {
    this.dummyRosterContext = dummyRosterContextInjected;
  }

  public void OnGet() {
    ViewData["Title"] = "DummyRoster Web - Category";
    Categories = dummyRosterContext.Categories.OrderBy(
      category => category.RegistrationDate
    ).ThenBy(
      category => category.Name
    );
  }
}
