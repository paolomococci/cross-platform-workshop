using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms.Text;
using static Microsoft.ML.DataOperationsCatalog;

namespace Liking.Common.Models;

public class AssetModel
{
  public string Id { get; } = Guid.NewGuid().ToString();

  public void CreateMLContext(
    string datasetPath,
    string schemaPath
  ) {
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
    IDataView testSetDataView = trainTestData.TestSet;
    /* process configuration step */
    TextFeaturizingEstimator textFeaturizingEstimator = mlContext.Transforms.Text.FeaturizeText(
      outputColumnName: "Features",
      inputColumnName: nameof(DatasetRawModel.Text)
    );
    /* training step */
    SdcaLogisticRegressionBinaryTrainer sdcaLogisticRegressionBinaryTrainer = mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(
      labelColumnName: "Label",
      featureColumnName: "Features"
    );
    var training = textFeaturizingEstimator.Append(sdcaLogisticRegressionBinaryTrainer);
    ITransformer transformer = training.Fit(trainSetDataView);
    /* evaluate step */
    IDataView dataViewPredictions = transformer.Transform(testSetDataView);
    CalibratedBinaryClassificationMetrics calibratedBinaryClassificationMetrics = mlContext.BinaryClassification.Evaluate(
      data: dataViewPredictions,
      labelColumnName: "Label",
      scoreColumnName: "Score"
    );
    System.Console.WriteLine($"Trainer: {sdcaLogisticRegressionBinaryTrainer.ToString()}");
    System.Console.WriteLine($"Metrics: {calibratedBinaryClassificationMetrics.ToString()}");
    /* persist step */
    mlContext.Model.Save(
      transformer,
      trainSetDataView.Schema,
      schemaPath
    );
    /* simple test step */
    DatasetRawModel datasetRawModel = new DatasetRawModel {
      Text = "I love testing apps!"
    };
    var predictionEngine = mlContext.Model.CreatePredictionEngine<DatasetRawModel, DatasetCookedModel>(transformer);
  }
}
