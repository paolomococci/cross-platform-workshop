using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController
{

  private readonly IProductRepository repository;

  public ProductController(
    IProductRepository repo
  )
  {
    this.repository = repo;
  }
}
