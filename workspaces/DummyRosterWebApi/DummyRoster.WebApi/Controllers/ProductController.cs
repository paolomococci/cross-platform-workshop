using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories;

namespace DummyRoster.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{

  private readonly IProductRepository iProductRepository;

  public ProductController(
    IProductRepository iRepo
  )
  {
    this.iProductRepository = iRepo;
  }
  // TODO
}
