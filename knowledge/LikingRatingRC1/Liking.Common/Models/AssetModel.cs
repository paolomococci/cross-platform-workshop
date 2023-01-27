using Microsoft.ML;

namespace Liking.Common.Models;

public class AssetModel
{
  public string Id { get; } = Guid.NewGuid().ToString();

  public void CreateMLContext(string datasetPath) {
    MLContext mlContext = new MLContext(seed: 1);
    IDataView dataView = mlContext.Data.LoadFromTextFile<DatasetRawModel>(
      datasetPath,
      hasHeader: true
    );
  }
}
