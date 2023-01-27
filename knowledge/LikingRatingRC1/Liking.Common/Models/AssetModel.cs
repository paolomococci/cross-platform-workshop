using Microsoft.ML;
using static Microsoft.ML.DataOperationsCatalog;

namespace Liking.Common.Models;

public class AssetModel
{
  public string Id { get; } = Guid.NewGuid().ToString();

  public void CreateMLContext(string datasetPath) {
    MLContext mlContext = new MLContext(seed: 1);
    /* loading step */
    IDataView dataView = mlContext.Data.LoadFromTextFile<DatasetRawModel>(
      datasetPath,
      hasHeader: true
    );
    /* configuration step */
    TrainTestData trainTestData = mlContext.Data.TrainTestSplit(
      dataView,
      testFraction: 0.2
    );
    IDataView trainSetDataView = trainTestData.TrainSet;
  }
}
