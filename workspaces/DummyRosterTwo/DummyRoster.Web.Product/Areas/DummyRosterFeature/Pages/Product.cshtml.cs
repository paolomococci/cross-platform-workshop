using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using DummyRoster.Common.DataContext.Data;

namespace DummyRoster.Web.Product.DummyRosterFeature.Pages;

public class ProductModel : PageModel
{
  private DummyRosterContext dummyRosterContext;

  public ProductModel(
      DummyRosterContext dummyRosterContext
  )
  {
    this.dummyRosterContext = dummyRosterContext;
  }

  public void OnGet()
  {

  }
}
