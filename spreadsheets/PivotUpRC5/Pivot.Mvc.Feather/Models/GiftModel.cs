namespace Pivot.Mvc.Feather.Models;

public class GiftModel
{
  public string Id { get; set; } = string.Empty;
  public List<CoordsModel>? coords { get; set; }
}
