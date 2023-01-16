namespace Pivot.Mvc.Feather.Models;

public class AssetModel
{
  public List<string> Labels { get; set; } = new();

  public void Add(string tag) {
    this.Labels.Add(tag);
  }

  public bool ItWasNotAdded(string? other)
  {
    if (other != null)
    {
      if (!this.Labels.Contains(other))
      {
        this.Labels.Add(other);
        return true;
      }
      return false;
    }
    return false;
  }
}
