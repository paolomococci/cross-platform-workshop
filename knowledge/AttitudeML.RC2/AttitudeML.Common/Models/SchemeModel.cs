using Microsoft.ML;

namespace AttitudeML.Common.Models;

public class SchemeModel
{
  public string Id { get; } = Guid.NewGuid().ToString();
  public MLContext? mlContext;

  public static PredictionEngine<DomainModel, PredictionModel> CreatePredictionEngine(
    DomainModel disposition
  )
  {
    MLContext mLContext = new();
    ITransformer transformer = mLContext.Model.Load();
    // todo
    throw new NotImplementedException();
  }

  public static PredictionEngine<DomainModel, PredictionModel> CreatePredictionEngineAndSaveSchema(
    DomainModel disposition
  )
  {
    MLContext mLContext = new();
    // todo
    throw new NotImplementedException();
  }
}
