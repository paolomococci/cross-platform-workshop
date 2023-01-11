namespace Pivot.Mvc.Feather.Models;

public class AssetModel : IComparable<AssetModel>
{
  public List<string> Labels { get; set; } = new();

  public void Add(string tag) {
    this.Labels.Add(tag);
  }

  public int CompareTo(AssetModel? other)
  {
    if (other != null)
    {
      throw new NotImplementedException();
    }
    return 0;
  }
}
