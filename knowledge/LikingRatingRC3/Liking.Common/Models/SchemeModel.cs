using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms.Text;
using static Microsoft.ML.DataOperationsCatalog;

namespace Liking.Common.Models;

public class SchemeModel
{
  public string Id { get; } = Guid.NewGuid().ToString();

  public void CreateMLContext(
    string datasetPath,
    string schemePath
  )
  {
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
      schemePath
    );
    /* simple test step */
    DatasetRawModel datasetRawModel = new DatasetRawModel
    {
      Text = "I love testing apps!"
    };
    // todo: specified argument was out of the range of valid values
    var predictionEngine = mlContext.Model.CreatePredictionEngine<DatasetRawModel, DatasetCookedModel>(transformer);
    DatasetCookedModel datasetCookedModelResult = predictionEngine.Predict(datasetRawModel);
    System.Console.WriteLine("--------------------> results of the test phase <--------------------");
    System.Console.WriteLine($"Text: {datasetRawModel.Text}");
    System.Console.WriteLine($"Prediction: {this.Evaluate(datasetCookedModelResult)}");
    System.Console.WriteLine($"Probability of expressing a negative feeling: {datasetCookedModelResult.Likelihood}");
    System.Console.WriteLine("--------------------> end of the test phase results <--------------------");
  }

  private void predictionEngineTest(
    MLContext mlContext
  ) {}

  private string Evaluate(
    DatasetCookedModel datasetCookedModel
  )
  {
    return Convert.ToBoolean(datasetCookedModel.Likelihood) ? "negative feeling" : "positive feeling";
  }
}
