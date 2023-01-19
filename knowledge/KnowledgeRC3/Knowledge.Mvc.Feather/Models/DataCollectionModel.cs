namespace Knowledge.Mvc.Feather.Models;

public class DataCollectionModel
{
  public string Id { get; } = DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss");
  public IFormFile? DatasetFilename { get; set; }
}
