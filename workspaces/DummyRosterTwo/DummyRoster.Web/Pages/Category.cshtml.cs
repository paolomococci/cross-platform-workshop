using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

using DummyRoster.Common.DataContext.Data;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.Web.Pages;

public class CategoryModel : PageModel {

  public IEnumerable<Category>? categories { get; set; }
  private DummyRosterContext dummyRosterContext;

  public CategoryModel(DummyRosterContext dummyRosterContextInjected) {
    this.dummyRosterContext = dummyRosterContextInjected;
  }

}
