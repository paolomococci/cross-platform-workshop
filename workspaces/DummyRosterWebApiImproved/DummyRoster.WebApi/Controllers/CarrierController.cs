using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DummyRoster.WebApi.Controllers;

[Route("api/carriers")]
[ApiController]
public class CarrierController : ControllerBase, ICarrierController
{

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
  }

  /* 
    GET: api/carriers/[id]
   */
  [HttpGet("{id}", Name = nameof(Get))]
  [ProducesResponseType(
    200,
    Type = typeof(Carrier)
  )]
  [ProducesResponseType(404)]
  public Task<IActionResult> Get(int id)
  {
    throw new NotImplementedException();
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
  public Task<IEnumerable<Carrier>> GetAll(string? name)
  {
    throw new NotImplementedException();
  }

  /* 
    PUT: api/carriers/id
    BODY: Carrier (JSON, XML)
   */
  [HttpPut("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public Task<IActionResult> Update(int id, [FromBody] Carrier entity)
  {
    throw new NotImplementedException();
  }

  /* 
    PATCH: api/carriers/id
    BODY: Carrier (JSON, XML)
   */
  [HttpPatch("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public Task<IActionResult> PartialUpdate(int id, [FromBody] Carrier entity)
  {
    throw new NotImplementedException();
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
  }
}
