using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SupplierController : ControllerBase, ISupplierController
{

  private readonly ISupplierRepository repository;

  public SupplierController(
    ISupplierRepository repo
  )
  {
    this.repository = repo;
  }
}
