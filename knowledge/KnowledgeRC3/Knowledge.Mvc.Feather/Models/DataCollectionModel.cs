namespace Knowledge.Mvc.Feather.Models;

public class DataCollectionModel
{
  public string Id { get; } = DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss");
  public IFormFile? DatasetFormFile { get; set; }

  public string Unique(string filename) {
    var name = Path.GetFileName(filename);
    return Path.GetFileNameWithoutExtension(name) + this.Id + Path.GetExtension(name);
  }
}
