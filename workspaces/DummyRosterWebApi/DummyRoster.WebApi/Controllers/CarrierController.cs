using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories;

namespace DummyRoster.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarrierController : ControllerBase
{

  private readonly ICarrierRepository iCarrierRepository;

  public CarrierController(
    ICarrierRepository iRepo
  )
  {
    this.iCarrierRepository = iRepo;
  }

  /* 
    GET: api/carriers
    GET: api/carriers/?name=[name]
   */
  [HttpGet]
  [ProducesResponseType(
    200, 
    Type = typeof(IEnumerable<Carrier>)
  )]
  public Task<IEnumerable<Carrier>> GetCarriers(string? name)
  {
    throw new NotImplementedException();
    // TODO
  }

}
