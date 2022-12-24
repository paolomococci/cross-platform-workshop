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
      string adminRole = this.configuration["UserAdmin:role"] ?? "";
      string adminEmail = this.configuration["UserAdmin:email"] ?? "";
      string adminPassword = this.configuration["UserAdmin:password"] ?? "";
      if (!(await this.roleManager.RoleExistsAsync(adminRole)))
    {
      await this.roleManager.CreateAsync(
        new IdentityRole(adminRole)
      );
    }
    IdentityUser identityUser = await this.userManager.FindByEmailAsync(adminEmail);
    if (identityUser is null)
    {
      identityUser = new();
      identityUser.UserName = adminEmail;
      identityUser.Email = adminEmail;
      IdentityResult identityResult = await this.userManager.CreateAsync(
        identityUser,
        adminPassword
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
    if (!(await this.userManager.IsInRoleAsync(identityUser, adminRole)))
    {
      IdentityResult identityResult = await this.userManager.AddToRoleAsync(
        identityUser,
        adminRole
      );
      if (identityResult.Succeeded)
      {
        Console.WriteLine(
          $"User: {identityUser.UserName} added as {adminRole} successfully."
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
    return Redirect("/");
    }
    catch (System.Exception e)
    {
      System.Console.WriteLine(e.Message);
      return Redirect("/");
    }
  }
}
