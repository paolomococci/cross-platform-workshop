using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories;

namespace DummyRoster.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SupplierController : ControllerBase
{

  private readonly ISupplierRepository iSupplierRepository;

  public SupplierController(
    ISupplierRepository iRepo
  )
  {
    this.iSupplierRepository = iRepo;
  }

  /* 
    GET: api/suppliers
    GET: api/suppliers/?country=[country]
   */
  [HttpGet]
  [ProducesResponseType(
    200, 
    Type = typeof(IEnumerable<Supplier>)
  )]
  public Task<IEnumerable<Supplier>> GetSuppliers(string? country)
  {
    throw new NotImplementedException();
    // TODO
  }

}
