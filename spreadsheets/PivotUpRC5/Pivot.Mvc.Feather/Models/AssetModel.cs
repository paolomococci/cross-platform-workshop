namespace Pivot.Mvc.Feather.Models;

public class AssetModel : IComparable<AssetModel>
{
  public List<string>? Assets { get; set; }

  public void Add() {}

  public int CompareTo(AssetModel? other)
  {
    throw new NotImplementedException();
  }
}
