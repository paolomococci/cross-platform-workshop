using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories;

namespace DummyRoster.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{

  private readonly ICategoryRepository iCategoryRepository;

  public CategoryController(
    ICategoryRepository iRepo
  )
  {
    this.iCategoryRepository = iRepo;
  }

  /* 
    GET: api/categories
    GET: api/categories/?name=[name]
   */
  [HttpGet]
  [ProducesResponseType(
    200, 
    Type = typeof(IEnumerable<Category>)
  )]
  public Task<IEnumerable<Category>> GetCategories(string? name)
  {
    throw new NotImplementedException();
    // TODO
  }

}
