using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DummyRoster.Mvc.Controllers;

public class RolesController : Controller
{
  private string adminRole;
  private string adminEmail;
  private string adminPassword;
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
    // querying the values ​​recorded in appsettings.json
    this.adminRole = this.configuration["UserAdminOne:group"];
    this.adminEmail = this.configuration["UserAdminOne:email"];
    this.adminPassword = this.configuration["UserAdminOne:password"];
  }

  public async Task<IActionResult> Index()
  {
    if (!(await this.roleManager.RoleExistsAsync(this.adminRole)))
    {
      await this.roleManager.CreateAsync(
        new IdentityRole(this.adminRole)
      );
    }
    IdentityUser identityUser = await this.userManager.FindByEmailAsync(this.adminEmail);
    if (identityUser == null)
    {
      identityUser = new();
      identityUser.UserName = this.adminEmail;
      identityUser.Email = this.adminEmail;
    }
    IdentityResult identityResult = await this.userManager.CreateAsync(
      identityUser,
      this.adminPassword
    );
    if (identityResult.Succeeded)
    {
      Console.WriteLine($"administrator {identityUser.UserName} identified correctly");
    }
    else
    {
      foreach (IdentityError item in identityResult.Errors)
      {
        Console.WriteLine(item.Description);
      }
    }
    // if the email is confirmed
    if (!identityUser.EmailConfirmed)
    {
      string token = await userManager.GenerateEmailConfirmationTokenAsync(identityUser);
      IdentityResult idResult = await userManager.ConfirmEmailAsync(
        identityUser,
        token
      );
    }
    return Redirect("/");
  }
}
