using Microsoft.ML;

namespace AttitudeML.Common.Models;

public class SchemeModel
{
  public string Id { get; } = Guid.NewGuid().ToString();
  public MLContext? mlContext;

  public static PredictionEngine<DomainModel, PredictionModel> CreatePredictionEngine(
    DomainModel[] dataset,
    DomainModel disposition
  )
  {
    MLContext mLContext = new();
    // todo
    throw new NotImplementedException();
  }

  public static PredictionEngine<DomainModel, PredictionModel> CreatePredictionEngineAndSaveSchema(
    DomainModel[] dataset,
    DomainModel disposition,
    string schemePath
  )
  {
    MLContext mLContext = new();
    // todo
    throw new NotImplementedException();
  }
}
