using Microsoft.ML;

namespace AttitudeML.Common.Models;

public class SchemeModel
{
  public string Id { get; } = Guid.NewGuid().ToString();

  public static ITransformer TrainingScheme(
    MLContext mlContext,
    IDataView trainingDataView
  )
  {
    throw new NotImplementedException();
  }

  public static IEstimator<ITransformer> MakePipeline()
  {
    throw new NotImplementedException();
  }

  private static PredictionEngine<DomainModel, PredictionModel> CreatePredictionEngine(
    string schemePath
  )
  {
    MLContext mLContext = new();
    ITransformer transformer = mLContext.Model.Load(
      schemePath,
      out var _
    );
    return mLContext.Model.CreatePredictionEngine<DomainModel, PredictionModel>(transformer);
  }

  public static PredictionModel Prediction(
    DomainModel domainModel,
    string schemePath
  )
  {
    Lazy<PredictionEngine<DomainModel, PredictionModel>> PredictEngine;
    PredictEngine = new Lazy<PredictionEngine<DomainModel, PredictionModel>>(
      () => CreatePredictionEngine(schemePath),
      true
    );
    return PredictEngine.Value.Predict(domainModel);
  }
}
