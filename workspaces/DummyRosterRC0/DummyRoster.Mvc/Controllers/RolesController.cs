using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DummyRoster.Mvc.Controllers;

public class RolesController : Controller
{
  private string RoleAdmin = "Admin";
  private string EmailAdmin = "";

  private readonly RoleManager<IdentityRole> roleManager;
  private readonly UserManager<IdentityUser> userManager;

  public RolesController(
    RoleManager<IdentityRole> roleManager,
    UserManager<IdentityUser> userManager
  ) {
    this.roleManager = roleManager;
    this.userManager = userManager;
  }

  public async Task<IActionResult> Index() {
    if (!(await this.roleManager.RoleExistsAsync(this.RoleAdmin)))
    {
      await this.roleManager.CreateAsync(
        new IdentityRole(this.RoleAdmin)
      );
    }
    IdentityUser identityUser = await this.userManager.FindByEmailAsync(
      this.EmailAdmin
    );
  }
}
