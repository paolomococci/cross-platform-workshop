using DummyRoster.Common;

var builder = WebApplication.CreateBuilder(args);

/* todo */
builder.WebHost.UseUrls("https://127.0.0.1:5002");
builder.Services.AddCors();

var app = builder.Build();

/* todo */
app.UseCors(
  configurePolicy: options => {
    options.WithMethods("GET");
    options.WithOrigins("https://127.0.0.1:5001");
  }
);

/* todo */
app.MapGet(
  "/api/forecast", 
  () => {
    return Enumerable.Range(1, 10).Select(
      index => new Forecast {
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
