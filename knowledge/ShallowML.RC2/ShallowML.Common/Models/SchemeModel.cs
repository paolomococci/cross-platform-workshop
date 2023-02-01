using Microsoft.ML;

namespace ShallowML.Common.Models;

public class SchemeModel
{
  public string Id { get; } = Guid.NewGuid().ToString();
  public MLContext? mlContext;

  public ReportModel CreateMLContext(
    string datasetPath
  )
  {
    this.mlContext = new MLContext();
    /* loading dataset step */
    IDataView dataView = mlContext.Data.LoadFromTextFile<DomainModel>(
      datasetPath,
      hasHeader: true
    );
    /*DomainModel[] domains = {
      new DomainModel() { Area = 12000.0F, Price = 35000.0F },
      new DomainModel() { Area = 15000.0F, Price = 47000.0F },
      new DomainModel() { Area = 11500.0F, Price = 37500.0F },
      new DomainModel() { Area = 14500.0F, Price = 41200.0F },
      new DomainModel() { Area = 14000.0F, Price = 40500.0F },
      new DomainModel() { Area = 9000.0F, Price = 27000.0F },
      new DomainModel() { Area = 10500.0F, Price = 32500.0F },
      new DomainModel() { Area = 12500.0F, Price = 35500.0F },
      new DomainModel() { Area = 15500.0F, Price = 47500.0F },
      new DomainModel() { Area = 11500.0F, Price = 37000.0F },
      new DomainModel() { Area = 14900.0F, Price = 41500.0F },
      new DomainModel() { Area = 14000.0F, Price = 40250.0F },
      new DomainModel() { Area = 9000.0F, Price = 26000.0F },
      new DomainModel() { Area = 10500.0F, Price = 33500.0F }
    };
    IDataView dataView = this.mlContext.Data.LoadFromEnumerable(domains);*/

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
    var priced = new DomainModel() { Area = 15500F };
    priced.Price = this.mlContext.Model.CreatePredictionEngine<DomainModel, PredictionModel>(scheme).Predict(priced).Price;

    return new ReportModel()
    {
      Name = this.Id,
      Area = priced.Area.ToString(),
      Price = priced.Price.ToString()
    };
  }
}
