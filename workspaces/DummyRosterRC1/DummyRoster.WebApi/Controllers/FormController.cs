using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Controllers.Interfaces;
using DummyRoster.WebApi.Repositories.Interfaces;

namespace DummyRoster.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FormController : ControllerBase, IFormController
{

  private readonly IFormRepository repository;

  public FormController(
    IFormRepository repo
  )
  {
    this.repository = repo;
  }
}
