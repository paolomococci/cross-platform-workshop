using DummyRoster.Web;

  Host.CreateDefaultBuilder(
    args
  ).ConfigureWebHostDefaults(
    webBuilder => {
      webBuilder.UseStartup<Starting>();
    }
  ).Build().Run();
  