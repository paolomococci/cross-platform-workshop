using Microsoft.ML;
using Template.Common.Models;

namespace Template.Common.Tests;

public class SchemeModelTest
{
  public static void predictionEngineTest(
    MLContext mlContext,
    IDataView testSetDataView,
    ITransformer transformer
  )
  {
    DatasetRawModel datasetRawModel = new DatasetRawModel
    {
      Text = "I love testing apps!"
    };
  }

  private static string Evaluate(
    DatasetCookedModel datasetCookedModel
  )
  {
    return Convert.ToBoolean(datasetCookedModel.Likelihood) ? "negative feeling" : "positive feeling";
  }
}
