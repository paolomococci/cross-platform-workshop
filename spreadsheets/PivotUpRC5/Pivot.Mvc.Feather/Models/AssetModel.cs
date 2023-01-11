namespace Pivot.Mvc.Feather.Models;

public class AssetModel : IComparable<AssetModel>
{
  public List<string> Assets { get; set; } = new();

  public void Add(string tag) {
    this.Assets.Add(tag);
  }

  public int CompareTo(AssetModel? other)
  {
    throw new NotImplementedException();
  }
}
