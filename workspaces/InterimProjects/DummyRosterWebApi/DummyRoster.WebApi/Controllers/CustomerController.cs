using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories;

namespace DummyRoster.WebApi.Controllers;

[Route("api/customers")]
[ApiController]
public class CustomerController : ControllerBase
{

  private readonly ICustomerRepository iCustomerRepository;

  public CustomerController(
    ICustomerRepository iRepo
  )
  {
    this.iCustomerRepository = iRepo;
  }

  /* 
    POST: api/customers
    BODY: Customer (JSON, XML)
   */
  [HttpPost]
  [ProducesResponseType(
    201,
    Type = typeof(Customer)
  )]
  [ProducesResponseType(400)]
  public async Task<IActionResult> Create([FromBody] Customer entity)
  {
    if (entity == null)
    {
      return BadRequest();
    }
    Customer? managedEntity = await this.iCustomerRepository.CreateAsync(entity);
    if (managedEntity == null)
    {
      return BadRequest("Unable to manage entity.");
    }
    return CreatedAtRoute(
      routeName: nameof(GetCustomer),
      routeValues: new { id = managedEntity.Id },
      value: managedEntity
    );
  }

  /* 
    GET: api/customers/[id]
   */
  [HttpGet("{id}", Name = nameof(GetCustomer))]
  [ProducesResponseType(
    200,
    Type = typeof(Customer)
  )]
  [ProducesResponseType(404)]
  public async Task<IActionResult> GetCustomer(int id)
  {
    Customer? managedEntity = await this.iCustomerRepository.RetrieveAsync(id);
    if (managedEntity == null)
    {
      return NotFound();
    }
    return Ok(managedEntity);
  }

  /* 
    GET: api/customers
    GET: api/customers/?name=[name]
   */
  [HttpGet]
  [ProducesResponseType(
    200,
    Type = typeof(IEnumerable<Customer>)
  )]
  public async Task<IEnumerable<Customer>> GetCustomers(string? name)
  {
    if (string.IsNullOrWhiteSpace(name))
    {
      return await this.iCustomerRepository.RetrieveAllAsync();
    }
    return (await this.iCustomerRepository.RetrieveAllAsync()).Where(
      entity => entity.Name == name
    );
  }

  /* 
    PUT: api/customers/id
    BODY: Customer (JSON, XML)
   */
  [HttpPut("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public async Task<IActionResult> Update(
    int id,
    [FromBody] Customer entity
  )
  {
    Customer? managedEntity = await this.iCustomerRepository.RetrieveAsync(id);
    if (managedEntity == null)
    {
      return NotFound();
    }
    await this.iCustomerRepository.UpdateAsync(id, entity);
    return new NoContentResult();
  }

  /* 
    DELETE: api/customers/id
   */
  [HttpDelete("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public async Task<IActionResult> Delete(int id)
  {
    bool deleted = false;
    Customer? managedEntity = await this.iCustomerRepository.RetrieveAsync(id);
    if (managedEntity == null)
    {
      return NotFound();
    }
    deleted = (bool)await this.iCustomerRepository.DeleteAsync(id);
    if (deleted)
    {
      return new NoContentResult();
    }
    return BadRequest();
  }

}
