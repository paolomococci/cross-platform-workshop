namespace Template.Mvc.Feather.Models;

public class DataCollectionModel
{
  public IFormFile? Dataset { get; set; }

  public string SetTheDateInTheFilename()
  {
    if (this.Dataset != null)
    {
      var datasetName = Path.GetFileName(this.Dataset.FileName);
      var name = Path.GetFileName(datasetName);
      return Path.GetFileNameWithoutExtension(name) + $"_{DateTime.Now:yyyy-MM-dd_hh-mm-ss}" + Path.GetExtension(name);
    }
    return string.Empty;
  }
}