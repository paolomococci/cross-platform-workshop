using Microsoft.AspNetCore.Mvc;
using DummyRoster.Common.EntityModel.Models;
using DummyRoster.WebApi.Repositories;

namespace DummyRoster.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarrierController : ControllerBase {

  private readonly ICarrierRepository iCarrierRepository;

  public CarrierController(
    ICarrierRepository iRepo
  ) {
    this.iCarrierRepository = iRepo;
  }
  // TODO
}
