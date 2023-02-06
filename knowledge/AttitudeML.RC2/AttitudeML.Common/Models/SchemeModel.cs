using Microsoft.ML;
using Microsoft.ML.Trainers;
using Microsoft.ML.TorchSharp;
using Microsoft.ML.Data;

namespace AttitudeML.Common.Models;

public class SchemeModel
{
  public string Id { get; } = Guid.NewGuid().ToString();

  public static IEstimator<ITransformer> MakePipeline(
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

  public static ITransformer TrainingScheme(
    MLContext mlContext,
    IDataView trainingDataView
  )
  {
    return MakePipeline(mlContext).Fit(trainingDataView);
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
