using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController
{

  private readonly IEmployeeRepository repository;

  public EmployeeController(
    IEmployeeRepository repo
  )
  {
    this.repository = repo;
  }
}
