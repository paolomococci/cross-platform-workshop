using Microsoft.ML;

namespace AttitudeML.Common.Models;

public class SchemeModel
{
  public string Id { get; } = Guid.NewGuid().ToString();

  public static PredictionEngine<DomainModel, PredictionModel> CreatePredictionEngine(
    DomainModel disposition,
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

  public static PredictionEngine<DomainModel, PredictionModel> CreatePredictionEngineAndSaveSchema(
    DomainModel disposition
  )
  {
    MLContext mLContext = new();
    // todo
    throw new NotImplementedException();
  }
}
