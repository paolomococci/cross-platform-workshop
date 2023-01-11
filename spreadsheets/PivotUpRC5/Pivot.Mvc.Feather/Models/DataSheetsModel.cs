namespace Pivot.Mvc.Feather.Models;

public class DataSheetsModel
{
  public string Id { get; set; } = string.Empty;
  public List<CoordsModel>? Items { get; set; }

  public DataSheetsModel(string id)
  {
    this.Id = id;
  }

  public DataSheetsModel(
    string id,
    List<CoordsModel> items
  )
  {
    this.Id = id;
    this.Items = items;
  }
}
