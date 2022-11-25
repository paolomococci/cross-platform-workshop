using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DummyRoster.Mvc.Controllers;

public class RolesController : Controller {

  private string adminRole = "Admins";
  private string userEmail = "admin.one@example.local";
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
    if (!(await this.roleManager.RoleExistsAsync(this.adminRole)))
    {
      await this.roleManager.CreateAsync(
        new IdentityRole(this.adminRole)
      );
    }
    IdentityUser identityUser = await this.userManager.FindByEmailAsync(this.userEmail);
    if (identityUser == null)
    {
      identityUser = new();
      identityUser.UserName = this.userEmail;
      identityUser.Email = this.userEmail;
    }
    // todo
    return Redirect("/");
  }
}
