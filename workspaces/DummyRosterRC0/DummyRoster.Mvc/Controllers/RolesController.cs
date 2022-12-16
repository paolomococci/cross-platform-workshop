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
      IdentityResult identityResult = await this.userManager.CreateAsync(
        identityUser,
        this.AdminPassword
      );
      if (identityResult.Succeeded)
      {
        Console.WriteLine(
          $"User: {identityUser.UserName} just successfully created!"
        );
      }
      else
      {
        foreach (IdentityError error in identityResult.Errors)
        {
          Console.WriteLine(
            $"Error: {error.Description}"
          );
        }
      }
    }
    if (!identityUser.EmailConfirmed)
    {
      string token = await this.userManager.GenerateEmailConfirmationTokenAsync(
        identityUser
      );
      IdentityResult identityResult = await this.userManager.ConfirmEmailAsync(
        identityUser,
        token
      );
      if (identityResult.Succeeded)
      {
        Console.WriteLine(
          $"User: email belonging to {identityUser.UserName} successfully confirmed!"
        );
      }
      else
      {
        foreach (IdentityError error in identityResult.Errors)
        {
          Console.WriteLine(
            $"Error: {error.Description}"
          );
        }
      }
    }
  }
}
