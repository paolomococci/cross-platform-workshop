using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

/*builder.Services.AddDataProtection().UseCryptographicAlgorithms(
  new AuthenticatedEncryptorConfiguration {
    EncryptionAlgorithm = EncryptionAlgorithm.AES_256_CBC,
    ValidationAlgorithm = ValidationAlgorithm.HMACSHA256
  }
);*/

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
