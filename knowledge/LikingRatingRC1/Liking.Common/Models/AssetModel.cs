namespace Liking.Common.Models;

public class AssetModel
{
  public string Id { get; } = Guid.NewGuid().ToString();

  public void CreateMLContext() {}
}
