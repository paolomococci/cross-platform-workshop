using Microsoft.ML;

namespace ShallowML.Common.Models;

public class SchemeModel
{
  public string Id { get; } = Guid.NewGuid().ToString();
  public MLContext? mlContext;

  public ReportModel CreateMLContext(
    DomainModel[] dataset,
    DomainModel priced
  )
  {
    this.mlContext = new MLContext();
    /* loading dataset step */
    IDataView dataView = this.mlContext.Data.LoadFromEnumerable(dataset);

    /* create pipeline step */
    var pipeline = this.mlContext.Transforms.Concatenate(
      "Features",
      new[] { "Area" }
    ).Append(
      this.mlContext.Regression.Trainers.Sdca(
        labelColumnName: "Price",
        maximumNumberOfIterations: 50
      )
    );

    /* training step */
    var scheme = pipeline.Fit(dataView);

    /* prediction step */
    priced.Price = this.mlContext.Model.CreatePredictionEngine<DomainModel, PredictionModel>(scheme).Predict(priced).Price;

    return new ReportModel()
    {
      Name = this.Id,
      Area = priced.Area.ToString(),
      Price = priced.Price.ToString()
    };
  }
}
