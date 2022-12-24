using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DummyRoster.Mvc.Models;

namespace DummyRoster.Mvc.Controllers;

public class RolesController : Controller
{
  private readonly IConfiguration configuration;
  private readonly RoleManager<IdentityRole> roleManager;
  private readonly UserManager<IdentityUser> userManager;

  public RolesController(
    IConfiguration configuration,
    RoleManager<IdentityRole> roleManager,
    UserManager<IdentityUser> userManager
  )
  {
    this.configuration = configuration;
    this.roleManager = roleManager;
    this.userManager = userManager;
  }

  public async Task<IActionResult> Index()
  {
    try
    {
      
    }
    catch (System.Exception e)
    {
      System.Console.WriteLine(e.Message);
      return Redirect("/");
    }
  }
}
