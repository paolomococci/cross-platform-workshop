using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DummyRoster.Mvc.Controllers;

public class RolesController : Controller
{
  private readonly ILogger<RolesController> _logger;
  private readonly IConfiguration configuration;
  private readonly RoleManager<IdentityRole> roleManager;
  private readonly UserManager<IdentityUser> userManager;

  public RolesController(
    ILogger<RolesController> logger,
    IConfiguration configuration,
    RoleManager<IdentityRole> roleManager,
    UserManager<IdentityUser> userManager
  )
  {
    this._logger = logger;
    this.configuration = configuration;
    this.roleManager = roleManager;
    this.userManager = userManager;
  }

  public async Task<IActionResult> Index()
  {
    if (!(await this.roleManager.RoleExistsAsync(this.configuration["UserAdminOne:group"])))
    {
      await this.roleManager.CreateAsync(
        new IdentityRole(this.configuration["UserAdminOne:group"])
      );
    }
    IdentityUser identityUser = await this.userManager.FindByEmailAsync(this.configuration["UserAdminOne:email"]);
    if (identityUser == null)
    {
      identityUser = new();
      identityUser.UserName = this.configuration["UserAdminOne:email"];
      identityUser.Email = this.configuration["UserAdminOne:email"];
      IdentityResult identityResult = await this.userManager.CreateAsync(
      identityUser,
      this.configuration["UserAdminOne:password"]
    ); if (identityResult.Succeeded)
      {
        this._logger.LogInformation($"Administrator {identityUser.UserName} identified correctly.");
      }
      else
      {
        foreach (IdentityError item in identityResult.Errors)
        {
          this._logger.LogError($"Error description: {item.Description}");
        }
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
      if (idResult.Succeeded)
      {
        this._logger.LogInformation($"{identityUser.UserName}, the email is considered valid!");
      }
      else
      {
        foreach (IdentityError item in idResult.Errors)
        {
          this._logger.LogError($"Error description: {item.Description}");
        }
      }
    }

    // if the user belongs to the administrators group
    if (!(await userManager.IsInRoleAsync(
      identityUser,
      this.configuration["UserAdminOne:group"]
    )))
    {
      IdentityResult addToAdminResult = await userManager.AddToRoleAsync(
        identityUser,
        this.configuration["UserAdminOne:group"]
      );
      if (addToAdminResult.Succeeded)
      {
        Console.WriteLine($"{identityUser.UserName} successfully added to {this.configuration["UserAdminOne:group"]} group!");
      }
      else
      {
        foreach (IdentityError item in addToAdminResult.Errors)
        {
          this._logger.LogError($"Error description: {item.Description}");
        }
      }
    }
    return Redirect("/");
  }
}
