using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories;

namespace DummyRoster.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InvoiceController : ControllerBase {

  private readonly IInvoiceRepository iInvoiceRepository;

  public InvoiceController(
    IInvoiceRepository iRepo
  ) {
    this.iInvoiceRepository = iRepo;
  }
  // TODO
}
