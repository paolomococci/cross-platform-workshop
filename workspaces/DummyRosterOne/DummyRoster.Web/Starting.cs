namespace Dummyroster.Web;

public class Starting {
  public void ConfigureServices(
    IServiceCollection services
  ) {}

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
    applicationBuilder.UseEndpoints(
      endpoints => {
        endpoints.MapGet(
          "/",
          () => "Endpoint at work!"
        );
      }
    );
  }
}
