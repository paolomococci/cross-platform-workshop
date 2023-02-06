using Microsoft.ML;
using Microsoft.ML.TorchSharp;

namespace AttitudeML.Common.Models;

public class SchemeModel
{
  public string Id { get; } = Guid.NewGuid().ToString();

  private PredictionEngine<DomainModel, PredictionModel> CreatePredictEngine(
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

  public PredictionModel Prediction(
    DomainModel domainModel,
    string schemePath
  )
  {
    Lazy<PredictionEngine<DomainModel, PredictionModel>> PredictEngine;
    PredictEngine = new Lazy<PredictionEngine<DomainModel, PredictionModel>>(
      () => CreatePredictEngine(schemePath),
      true
    );
    return PredictEngine.Value.Predict(domainModel);
  }

  public IEstimator<ITransformer> MakePipeline(
    MLContext mlContext
  )
  {
    return mlContext.Transforms.Conversion.MapValueToKey(
      outputColumnName: @"Sentiment",
      inputColumnName: @"Sentiment"
    ).Append(
      mlContext.MulticlassClassification.Trainers.TextClassification(
        labelColumnName: @"Sentiment", 
        sentence1ColumnName: @"SentimentText"
      )
    ).Append(
      mlContext.Transforms.Conversion.MapKeyToValue(
        outputColumnName:@"PredictedLabel", 
        inputColumnName:@"PredictedLabel"
      )
    );
  }

  public ITransformer TrainingScheme(
    MLContext mlContext,
    IDataView trainingDataView
  )
  {
    return MakePipeline(mlContext).Fit(trainingDataView);
  }
}
