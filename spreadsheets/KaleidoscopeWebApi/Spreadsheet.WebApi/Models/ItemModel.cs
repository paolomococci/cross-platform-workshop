namespace Spreadsheet.WebApi.Models;

public class ItemModel
{
  public string Name { get; set; } = string.Empty;
  public int Orders { get; set; }
  public string Quarter { get; set; } = string.Empty;

  public ItemModel() {}

  public ItemModel(
    string Name
  ) {
    this.Name = Name;
  }
}
