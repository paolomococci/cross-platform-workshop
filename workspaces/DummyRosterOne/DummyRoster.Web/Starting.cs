using DummyRoster.Common.DataContext;

namespace DummyRoster.Web;

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

    applicationBuilder.Use(
      async (context, next) => {
        RouteEndpoint? routeEndpoint = context.GetEndpoint() as RouteEndpoint;
        if (routeEndpoint is not null)
        {
          Console.WriteLine($"Endpoint name: {routeEndpoint.DisplayName}");
          Console.WriteLine($"Endpoint route pattern: {routeEndpoint.RoutePattern.RawText}");
        }
        await next(context);
      }
    );

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
