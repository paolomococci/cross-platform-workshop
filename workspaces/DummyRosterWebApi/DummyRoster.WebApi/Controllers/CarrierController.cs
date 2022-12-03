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
    POST: api/carriers
    BODY: Carrier (JSON, XML)
   */
  [HttpPost]
  [ProducesResponseType(
    201,
    Type = typeof(Carrier)
  )]
  [ProducesResponseType(400)]
  public Task<IActionResult> Create([FromBody] Carrier entity)
  {
    throw new NotImplementedException();
    // TODO
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

  /* 
    GET: api/carriers/[id]
   */
  [HttpGet("{id}", Name = nameof(GetCarrier))]
  [ProducesResponseType(
    200,
    Type = typeof(Carrier)
  )]
  [ProducesResponseType(404)]
  public Task<IActionResult> GetCarrier(int id)
  {
    throw new NotImplementedException();
    // TODO
  }

  /* 
    PUT: api/carriers/id
    BODY: Carrier (JSON, XML)
   */
  [HttpPut("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public Task<IActionResult> Update(
    int id,
    [FromBody] Carrier entity
  )
  {
    throw new NotImplementedException();
    // TODO
  }

  /* 
    DELETE: api/carriers/id
   */
  [HttpDelete("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public Task<IActionResult> Delete(int id)
  {
    throw new NotImplementedException();
    // TODO
  }

}
