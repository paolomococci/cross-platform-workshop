namespace Knowledge.Mvc.Feather.Models;

public class DataCollectionModel
{
  public string Id { get; } = DateTime.Now.ToString();
  public IFormFile? DatasetFilename { get; set; }
}
