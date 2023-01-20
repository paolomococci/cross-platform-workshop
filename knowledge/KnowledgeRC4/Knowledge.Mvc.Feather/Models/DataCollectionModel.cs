namespace Knowledge.Mvc.Feather.Models;

public class DataCollectionModel
{
  public string Id { get; set; } = string.Empty;
  public IFormFile? DatasetFormFile { get; set; }

  public DataCollectionModel() {
    this.Id = DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss");
  }

  public string AddDateToName()
  {
    if (this.DatasetFormFile != null)
    {
      var name = Path.GetFileName(
        this.DatasetFormFile.FileName
      );
      return String.Concat(
        Path.GetFileNameWithoutExtension(name),
        this.Id,
        Path.GetExtension(name)
      );
    }
    return string.Empty;
  }
}
