using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DummyRoster.Mvc.Controllers;

public class RolesController : Controller
{
  private string AdminRole = "Admin";
  private string AdminUserName = "";
  private string AdminPassword = "";

  private readonly RoleManager<IdentityRole> roleManager;
  private readonly UserManager<IdentityUser> userManager;

  public RolesController(
    RoleManager<IdentityRole> roleManager,
    UserManager<IdentityUser> userManager
  )
  {
    this.roleManager = roleManager;
    this.userManager = userManager;
  }

  public async Task<IActionResult> Index()
  {
    if (!(await this.roleManager.RoleExistsAsync(this.AdminRole)))
    {
      await this.roleManager.CreateAsync(
        new IdentityRole(this.AdminRole)
      );
    }
    IdentityUser identityUser = await this.userManager.FindByEmailAsync(
      this.AdminUserName
    );
    if (identityUser is null)
    {
      identityUser = new();
      identityUser.UserName = this.AdminUserName;
      identityUser.Email = this.AdminUserName;
    }
  }
}
