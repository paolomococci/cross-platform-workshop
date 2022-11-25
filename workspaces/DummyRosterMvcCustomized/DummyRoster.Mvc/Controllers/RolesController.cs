using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DummyRoster.Mvc.Controllers;

public class RolesController : Controller {

  private string adminRole = "Admins";
  private string userEmail = "admin.one@example.local";
  private readonly RoleManager<IdentityRole> roleManager;
  private readonly UserManager<IdentityUser> userManager;

  public RolesController() {}
}
