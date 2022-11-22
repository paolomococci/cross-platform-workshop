using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

using DummyRoster.Common.DataContext.Data;
using DummyRoster.Common.EntityModel.Models;

namespace DummyRoster.Web.Pages;

public class FormModel : PageModel {

  public IEnumerable<Form>? forms { get; set; }
  private DummyRosterContext dummyRosterContext;

  public FormModel(DummyRosterContext dummyRosterContextInjected) {
    this.dummyRosterContext = dummyRosterContextInjected;
  }

}
