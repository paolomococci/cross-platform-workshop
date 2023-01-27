using Microsoft.ML;

namespace Liking.Common.Models;

public class AssetModel
{
  public string Id { get; } = Guid.NewGuid().ToString();

  public void CreateMLContext() {
    MLContext mlContext = new MLContext(seed: 1);
  }
}
