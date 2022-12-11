using Outcome.Common;

var builder = WebApplication.CreateBuilder(args);

/* setting of the port from which the service will respond */
builder.WebHost.UseUrls("https://127.0.0.1:5002");
builder.Services.AddCors();

var app = builder.Build();

/* setting of the port from which requests will be allowed to be made with the methods listed */
app.UseCors(
  configurePolicy: options =>
  {
    options.WithMethods("GET");
    options.WithOrigins("https://127.0.0.1:5001");
  }
);

/* URI mapping and service implementation */
app.MapGet(
  "/api/forecast",
  () =>
  {
    return Enumerable.Range(0, 9).Select(
      index => new Forecast
      {
        NextDays = DateTime.Now.AddDays(index),
        Sample = Random.Shared.Next(0, 9),
        Foregone = Forecast.Forecasts[
          Random.Shared.Next(
            Forecast.Forecasts.Length
          )
        ]
      }
    ).ToArray();
  }
);

app.Run();
