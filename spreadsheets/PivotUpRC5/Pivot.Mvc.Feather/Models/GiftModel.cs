namespace Pivot.Mvc.Feather.Models;

public class GiftModel
{
  public string Id { get; set; } = string.Empty;
  public DateOnly? Session { get; set; }
  public List<int>? HyperDots { get; set; }
}
