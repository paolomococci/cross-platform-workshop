namespace Pivot.Mvc.Feather.Models;

public class DataSheetModel
{
  public string Id { get; set; } = string.Empty;
  public List<CoordsModel> Items { get; set; } = new();

  public DataSheetModel(string id)
  {
    this.Id = id;
  }

  public DataSheetModel(
    string id,
    List<CoordsModel> items
  )
  {
    this.Id = id;
    this.Items = items;
  }
}
