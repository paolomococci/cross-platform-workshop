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
      if (!(await this.roleManager.RoleExistsAsync(this.configuration["UserAdmin:role"])))
    {
      await this.roleManager.CreateAsync(
        new IdentityRole(this.configuration["UserAdmin:role"])
      );
    }
    IdentityUser identityUser = await this.userManager.FindByEmailAsync(
      this.configuration["UserAdmin:email"]
    );
    if (identityUser is null)
    {
      identityUser = new();
      identityUser.UserName = this.configuration["UserAdmin:email"];
      identityUser.Email = this.configuration["UserAdmin:email"];
      IdentityResult identityResult = await this.userManager.CreateAsync(
        identityUser,
        this.configuration["UserAdmin:password"]
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
    if (!(await this.userManager.IsInRoleAsync(identityUser, this.configuration["UserAdmin:role"])))
    {
      IdentityResult identityResult = await this.userManager.AddToRoleAsync(
        identityUser,
        this.configuration["UserAdmin:role"]
      );
      if (identityResult.Succeeded)
      {
        Console.WriteLine(
          $"User: {identityUser.UserName} added as {this.configuration["UserAdmin:role"]} successfully."
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
