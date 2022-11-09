namespace Dummyroster.Web;

public class Starting {
  public void ConfigureServices(
    IServiceCollection services
  ) {
    services.AddRazorPages();
  }

  public void Configure(
    IApplicationBuilder applicationBuilder,
    IWebHostEnvironment webHostEnvironment
  ) {
    if (!webHostEnvironment.IsDevelopment())
    {
      applicationBuilder.UseHsts();
    }
    applicationBuilder.UseRouting();
    applicationBuilder.UseHttpsRedirection();
    applicationBuilder.UseDefaultFiles();
    applicationBuilder.UseStaticFiles();
    applicationBuilder.UseEndpoints(
      endpoints => {
        endpoints.MapRazorPages();
        endpoints.MapGet(
          "/endpoint",
          () => "Endpoint at work!"
        );
      }
    );
  }
}
