using Microsoft.ML;
using Liking.Common.Models;

namespace Liking.Common.Tests;

public class SchemeModelTest
{
  public static void PredictionEngineTest(
    MLContext mlContext,
    IDataView testSetDataView,
    ITransformer transformer,
    string sampleText
  )
  {
    DatasetRawModel datasetRawModel = new DatasetRawModel(Text: sampleText);
    // todo: specified argument was out of the range of valid values
    var predictionEngine = mlContext.Model.CreatePredictionEngine<DatasetRawModel, DatasetCookedModel>(
      transformer: transformer
    );
    DatasetCookedModel datasetCookedModelResult = predictionEngine.Predict(datasetRawModel);
    System.Console.WriteLine("--------------------> results of the test phase <--------------------");
    System.Console.WriteLine($"Text: {datasetRawModel.Text}");
    System.Console.WriteLine($"Prediction: {Evaluate(datasetCookedModelResult)}");
    System.Console.WriteLine($"Probability of expressing a negative feeling: {datasetCookedModelResult.Likelihood}");
    System.Console.WriteLine("--------------------> end of the test phase results <--------------------");
  }

  private static string Evaluate(
    DatasetCookedModel datasetCookedModel
  )
  {
    return Convert.ToBoolean(datasetCookedModel.Likelihood) ? "negative feeling" : "positive feeling";
  }
}
