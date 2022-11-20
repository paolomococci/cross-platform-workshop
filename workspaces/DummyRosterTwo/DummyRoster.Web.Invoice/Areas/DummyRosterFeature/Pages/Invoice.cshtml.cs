﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using DummyRoster.Common.DataContext.Data;

namespace DummyRoster.Web.Invoice.DummyRosterFeature.Pages;

public class InvoiceModel : PageModel
{
  private DummyRosterContext dummyRosterContext;
  public DummyRoster.Common.EntityModel.Models.Invoice[] invoices { get; set; } = null!;

  public InvoiceModel(
      DummyRosterContext dummyRosterContext
  )
  {
    this.dummyRosterContext = dummyRosterContext;
  }

  public void OnGet()
  {

  }
}
