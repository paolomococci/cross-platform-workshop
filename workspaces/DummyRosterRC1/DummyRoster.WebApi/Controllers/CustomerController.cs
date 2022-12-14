using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase, ICustomerController
{

  private readonly ICustomerRepository repository;

  public CustomerController(
    ICustomerRepository repo
  )
  {
    this.repository = repo;
  }
}
