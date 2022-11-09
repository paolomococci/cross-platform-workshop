using Dummyroster.Web;

  Host.CreateDefaultBuilder(
    args
  ).ConfigureWebHostDefaults(
    webBuilder => {
      webBuilder.UseStartup<Starting>();
    }
  ).Build().Run();
  